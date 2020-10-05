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

public class LogOut : MonoBehaviour
{
    private ManageScenes Manager;
    private UserInfo UserInfo;
    private GameSparksApiCalls Api;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("SceneManager").GetComponent<ManageScenes>();
        UserInfo = GameObject.Find("UserInfo").GetComponent<UserInfo>();
        Api = GameObject.Find("GameSparks").GetComponent<GameSparksApiCalls>();
    }

    // Update is called once per frame
    public void logout()
    {
        new LogEventRequest()
            .SetEventKey("Logout")
            .Send((response) =>
            {
                UserInfo.setPlayerName(null);
                UserInfo.setUserId(null);
                UserInfo.setMonsters(null);
                UserInfo.setPreferences(null);

                Manager.setVolume(0);

                Manager.toTitleScreen();
            });
    }
}
