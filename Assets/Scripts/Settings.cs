using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GameSparks.Core;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

public class Settings : MonoBehaviour
{
    private ManageScenes Manager;
    private UserInfo UserInfo;

    public Dropdown ReceivingInterval;
    public Dropdown MusicOptions;
    public Slider MusicVolume;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("SceneManager").GetComponent<ManageScenes>();
        UserInfo = GameObject.Find("UserInfo").GetComponent<UserInfo>();

        ReceivingInterval.value = UserInfo.getPreferences().Interval;
        MusicOptions.value = UserInfo.getPreferences().Music;
        MusicVolume.value = (float) UserInfo.getPreferences().Volume / 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateSettings()
    {
        UserInfo.setPreferences(new UserInfo.Configurable(
            ReceivingInterval.value,
            MusicOptions.value,
            (int) (MusicVolume.value * 100),
            UserInfo.getPreferences().LastRecv
        ));
        
        new LogEventRequest()
            .SetEventKey("SetPlayerPrefs")
            .SetEventAttribute("INTERVAL", ReceivingInterval.value)
            .SetEventAttribute("MUSIC", MusicOptions.value)
            .SetEventAttribute("VOLUME", (int) (MusicVolume.value * 100))
            .Send((response) => {
                if(response.HasErrors) Debug.Log("Update Unsuccessful");
            });
    }

    public void changeMusic()
    {
        if(Manager.getMusic() != MusicOptions.options[MusicOptions.value].text)
        {
            UserInfo.Configurable pref = UserInfo.getPreferences();
            pref.Music = MusicOptions.value;
            UserInfo.setPreferences(pref);
            Manager.setMusic(MusicOptions.value);
        }
    }

    public void changeVolume()
    {
        if(Manager.getVolume() != MusicVolume.value)
        {
            UserInfo.Configurable pref = UserInfo.getPreferences();
            pref.Music = (int) (MusicVolume.value * 100);
            UserInfo.setPreferences(pref);
            Manager.setVolume(MusicVolume.value);
        }
    }
}
