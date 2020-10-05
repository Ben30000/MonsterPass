using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using Newtonsoft.Json.Linq;

using GameSparks.Core;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

public class GameSparksApiCalls : MonoBehaviour
{
    private static GameSparksApiCalls Api = null;
    private ManageScenes Manager;
    private UserInfo UserInfo;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        if(Api == null)
        {
            Api = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("SceneManager").GetComponent<ManageScenes>();
        UserInfo = GameObject.Find("UserInfo").GetComponentInChildren<UserInfo>();
    }

    public bool registerUser(string displayName, string username, string password)
    {
        bool isAuthenticated = false;

        // Register user and initiate userinfo
        new RegistrationRequest()
            .SetDisplayName(displayName)
            .SetUserName(username)
            .SetPassword(password)
            .Send((response) => {
                if(!response.HasErrors){
                    UserInfo.setPlayerName(response.DisplayName);
                    UserInfo.setUserId(response.UserId);
                    requestUserInfo();
                    isAuthenticated = true;
                }
            });

        return isAuthenticated;
    }

    public bool signinUser(string username, string password)
    {
        bool isAuthenticated = false;

        // Make an API request for authentication with given fields
        // Listen in for response
        new AuthenticationRequest()
            .SetUserName(username)
            .SetPassword(password)
            .Send((response) => {
                if(!response.HasErrors){
                    UserInfo.setPlayerName(response.DisplayName);
                    UserInfo.setUserId(response.UserId);
                    requestUserInfo();
                    isAuthenticated = true;
                }
            });

        return isAuthenticated;
    }

    public bool eventLogging(/* Event and Info */)
    {
        new LogEventRequest()
            .SetEventKey("Something")
            .SetEventAttribute("Something", 10)
            .Send((response) => {
                GSData gsData = response.BaseData.GetGSData("scriptData");
                JObject jsonData = JObject.Parse(gsData.JSON);
            });

        return false;
    }

	// Make a request for user preferences, and update the userinfo
    public bool requestUserInfo () {
		bool isUpdated = false;

		new LogEventRequest()
			.SetEventKey ("GetPlayerPrefs")
			.Send ((response) => {
				if (!response.HasErrors) {
					GSData gsData = response.BaseData.GetGSData("scriptData");
					GSData prefs = gsData.GetGSData ("PLAYER").GetGSData ("PREFERENCES");

					int interval = (int) prefs.GetNumber ("INTERVAL");
					int music = (int) prefs.GetNumber ("MUSIC");
					int volume = (int) prefs.GetNumber ("VOLUME");
					long lastRecv = (long) prefs.GetNumber ("LASTRECV");

					Debug.Log ("User Loaded Prefs: " + interval + " " + music + " " + volume + " " + lastRecv);
					UserInfo.setPreferences (new UserInfo.Configurable (interval, music, volume, lastRecv));

					Manager.setVolume ((float) volume / 100);
					Manager.setMusic (music);

					isUpdated = true;
				}
			});

		return isUpdated;
    }

    // Disconnect the user when logging out session
    public bool disconnect()
    {
        //Spark.getPlayer().disconnect(true);
        //Manager.toTitleScreen();
        // Probably a log event action
        return false;
    }

    // Check if enough time has passed to receive a new monster, do so if true
    public void CheckForReceive() {
		TimeSpan myTime = DateTime.UtcNow - new DateTime(1970, 1, 1);
		long myMillis = (long) myTime.TotalMilliseconds;
		long lastMillis = UserInfo.getPreferences().LastRecv;
		int receiveSpan = UserInfo.getPreferences().Interval;

		switch (receiveSpan) {

			// 4 hours
			case 0:
				receiveSpan = 14400000;
				break;

			// 8 hours
			case 1:
				receiveSpan = 28800000;
				break;

			// 12 hours
			case 2:
				receiveSpan = 43200000;
				break;

			default:
				receiveSpan = 0;
				break;
		}

		Debug.Log ("Old: " + lastMillis + "   New: " + myMillis);

		// Enough time has passed, receive a new monster!
		if (myMillis - lastMillis > receiveSpan) {
			Debug.Log ("New monster time!\n");
			new LogEventRequest()
				.SetEventKey("AddMonster")
				.Send((response) =>
				{
					if (!response.HasErrors)
					{
						GSData gsMonster = response.BaseData.GetGSData("scriptData").GetGSData("MONSTER");

                        /*
                        Debug.Log("        ***         USERNAME        *****");
                        Debug.Log(gsMonster.GetString("NAME"));
                        */

						Debug.Log ("New monster got!\n");
                        

						List<UserInfo.Monster> monList = UserInfo.getMonsters();
						monList.Add (new UserInfo.Monster (
							gsMonster.GetString ("USERID"),
							gsMonster.GetString ("NAME"),
							(int) gsMonster.GetGSData ("ATTRIBUTES").GetNumber ("EYES"),
							(int) gsMonster.GetGSData ("ATTRIBUTES").GetNumber ("EARS"),
							(int) gsMonster.GetGSData ("ATTRIBUTES").GetNumber ("HORN"),
							(int) gsMonster.GetGSData ("ATTRIBUTES").GetNumber ("TAIL"),
							gsMonster.GetGSData ("ATTRIBUTES").GetString ("COLOR")
						));

                        //Debug.Log(" $$$$$$$$$$$$$$$$$$$$$$$$$$ Color attribute:  " + gsMonster.GetGSData("ATTRIBUTES").GetString("COLOR"));
						UserInfo.setMonsters (monList);
					}
				});
		}
    }
    

}
