using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonTransitions : MonoBehaviour {
    private GameSparksApiCalls Api;

	// Use this for initialization
	void Start () {
        Api = GameObject.Find("GameSparks").GetComponent<GameSparksApiCalls>();
		
	}

    //move user to login screen
    public void toTitleScreen()
    {
        SceneManager.LoadScene("titleScreen");
    }

    //move user to login screen
    public void toSignIn()
    {
        SceneManager.LoadScene("signinScreen");
    }

    //move user to register screen
    public void toRegister()
    {
        SceneManager.LoadScene("registerScreen");
    }

    //move user to ranch screen
    public void toRanchScreen()
    {
        SceneManager.LoadScene("ranchScreen");
    }

    //move user to settings
    public void toSettingsScreen()
    {
        SceneManager.LoadScene("settingsScreen");
    }

    //move user to monster creation screen
    public void toMonsterEditingScreen()
    {
        SceneManager.LoadScene("monsterEditingScreen");
    }
}
