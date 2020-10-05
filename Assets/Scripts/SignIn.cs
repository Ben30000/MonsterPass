using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using GameSparks.Core;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

using Newtonsoft.Json.Linq;

public class SignIn : MonoBehaviour
{
    private ManageScenes Manager;
    private UserInfo UserInfo;
    private GameSparksApiCalls Api;

    public InputField Username;
    public InputField Password;
    public GameObject ErrorPrefab;
    public GameObject Canvas;

    void Start()
    {
        Manager = GameObject.Find("SceneManager").GetComponent<ManageScenes>();
        UserInfo = GameObject.Find("UserInfo").GetComponent<UserInfo>();
        Api = GameObject.Find("GameSparks").GetComponent<GameSparksApiCalls>();
    }

    private void generateError(string message)
    {
        GameObject obj = Instantiate (ErrorPrefab);
        obj.transform.SetParent(Canvas.transform, false);
        Text text = obj.GetComponentInChildren<Text>();
        text.text = message;
    }


    public void signin()
    {
        string username = Username.text;
        string password = Password.text;
        if(username == "" || password == "") {
            generateError("Missing Username or Password");
            return;
        }

        new AuthenticationRequest()
            .SetUserName(username)
            .SetPassword(password)
            .Send((response) => {
                if(!response.HasErrors){
                    UserInfo.setPlayerName(response.DisplayName);
                    UserInfo.setUserId(response.UserId);
                    Api.requestUserInfo();
                    fetchMonsters();
                } else {
                    generateError("Incorrect Username or Password");
                }
            });
    }

    private void fetchMonsters()
    {
        List<UserInfo.Monster> monsters = new List<UserInfo.Monster>();
        new LogEventRequest()
            .SetEventKey("GetMonsters")
            .Send((response) => {
                GSData gsData = response.BaseData.GetGSData("scriptData");
                JObject jsonData = JObject.Parse(gsData.JSON);

                foreach(JToken monster in jsonData["MONSTERS"])
                {
                    UserInfo.Monster item = new UserInfo.Monster(
						monster["userid"].ToString(),
						monster["name"].ToString(),
						Convert.ToInt32(monster["attributes"]["eyes"].ToString()),
						Convert.ToInt32(monster["attributes"]["ears"].ToString()),
						Convert.ToInt32(monster["attributes"]["horn"].ToString()),
						Convert.ToInt32(monster["attributes"]["tail"].ToString()),
						monster["attributes"]["color"].ToString()
                    );
                    monsters.Add(item);
                }

                UserInfo.setMonsters(monsters);
                Manager.toRanchScreen();
            });
    }
}
