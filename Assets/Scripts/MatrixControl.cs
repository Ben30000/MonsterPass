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

public class MatrixControl : MonoBehaviour
{
    private ManageScenes Manager;
    private UserInfo UserInfo;

    public GameObject Canvas;

    public GameObject MatrixItemPrefab;
    public GridLayoutGroup LayoutGroup;
    public ScrollRect ScrollView;
    public GameObject ScrollContent;

    public boardogInfo DisplayBoardog;

    private int interval;
    private long lastrecv;
    private bool loaded;

    private bool isFirstDog = true;

    void Start()
    {
        loaded = false;

        Manager = GameObject.Find("SceneManager").GetComponent<ManageScenes>();
        UserInfo = GameObject.Find("UserInfo").GetComponent<UserInfo>();

        foreach (UserInfo.Monster monster in UserInfo.getMonsters())
        {    
            genMonster(monster);
        }

        if(isFirstDog)
            DisplayBoardog.setActive(false);
        
		lastrecv = UserInfo.getPreferences().LastRecv;
		interval = UserInfo.getPreferences().Interval;

        loaded = true;
        //PopUp(3);
    }

    private long time;

    void Update()
    {
        IntervalCheck();
    }

    void IntervalCheck() {
        TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
        time = (long)t.TotalMilliseconds;

		int receiveSpan = interval;

		switch (receiveSpan) {
			// 4 hours
			case 0:
				receiveSpan = 14400000;
				//receiveSpan = 60000; 1 min
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

        if (loaded)
        {
            //Interval is now in terms of minutes since lastrecv is in terms of milliseconds
            if (lastrecv + receiveSpan <= time)
            {
                int numMonsters = (int)(time - lastrecv) / receiveSpan;

                List<UserInfo.Monster> monsters = UserInfo.getMonsters();
                for (int i = 0; i < numMonsters; i++)
                {
                    new LogEventRequest()
                        .SetEventKey("AddMonster")
                        .Send((response) =>
                        {
                            if (!response.HasErrors)
                            {
                                GSData gsData = response.BaseData.GetGSData("scriptData");
                                JObject jsonData = JObject.Parse(gsData.JSON);

                                JToken monster = jsonData["MONSTER"];

                                UserInfo.Monster item = new UserInfo.Monster(
                                    monster["USERID"].ToString(),
                                    monster["NAME"].ToString(),
                                    Convert.ToInt32(monster["ATTRIBUTES"]["EYES"].ToString()),
                                    Convert.ToInt32(monster["ATTRIBUTES"]["EARS"].ToString()),
                                    Convert.ToInt32(monster["ATTRIBUTES"]["HORN"].ToString()),
                                    Convert.ToInt32(monster["ATTRIBUTES"]["TAIL"].ToString()),
                                    monster["ATTRIBUTES"]["COLOR"].ToString());

                                //,
                                //monster["attributes"]["colorEyes"].ToString(),
                                //monster["attributes"]["colorHorn"].ToString());
                                monsters.Add(item);

                                UserInfo.setMonsters(monsters);

                                if(jsonData["Event"].ToString().Equals("0"))
                                {
                                    UserInfo.addNotification("Updated: " + monster["USERID"].ToString());
                                }
                                else
                                {
                                    UserInfo.addNotification("Received: " + monster["USERID"].ToString());
                                }

                                Debug.Log("Monster Loaded");
                            }
                            else {
                                Debug.Log("Monster Not loaded");
                            }
                        });
                }

                //Instantiate Notification

                lastrecv = time;
                UserInfo.getPreferences().LastRecv = time;
                new LogEventRequest()
                       .SetEventKey("SetLastRecv")
                       .SetEventAttribute("TIME", time)
                       .Send((response) =>
                       {
                           if (response.HasErrors){
                               Debug.Log("Error Time Received Not Saved");
                           }
                       });

            }
        }
    }

    void genMonster(UserInfo.Monster monster)
    {
        GameObject newItem = Instantiate(MatrixItemPrefab);
        newItem.transform.SetParent(ScrollContent.transform, false);
        newItem.GetComponent<BoardogButton>().updateCurBoardog(
            monster.userId,
            monster.name,
            monster.eyes,
            monster.ears,
            monster.horn,
            monster.tail,
            monster.color
            //monster.colorEyes,
            //monster.colorHorn
        );
        if(isFirstDog)
        {
            isFirstDog = false;
            DisplayBoardog.userID = monster.userId;
            DisplayBoardog.currEye = monster.eyes;
            DisplayBoardog.currEar = monster.ears;
            DisplayBoardog.currHorn = monster.horn;
            DisplayBoardog.currTail = monster.tail;
            DisplayBoardog.gsColor = monster.color;
        }
    }

    public void leftScroll()
    {
        ScrollView.velocity = new Vector2(-1000f, 0f);
    }

    public void rightScroll()
    {
        ScrollView.velocity = new Vector2(1000f, 0f);
    }
}

