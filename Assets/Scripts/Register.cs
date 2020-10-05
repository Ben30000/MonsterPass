using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

public class Register : MonoBehaviour
{
    private ManageScenes Manager;
    private UserInfo UserInfo;
    private GameSparksApiCalls Api;

    public InputField Username;
    public InputField Email;
    public InputField Password;
    public InputField PasswordConfirm;
    public GameObject ErrorPrefab;
    public GameObject Canvas;
    // Start is called before the first frame update
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

    public void register()
    {
        string username = Username.text;
        string email = Email.text;
        string password = Password.text;
        string passwordconfirm = PasswordConfirm.text;

        if(username == "" || email == ""|| password == ""||passwordconfirm == "") {
            generateError("Missing Input");
            return;
        }
        if(password!=passwordconfirm){
            generateError("Password is not same");
            return;
        }

		// Register user and initiate userinfo
		new RegistrationRequest()
			.SetDisplayName(username)
			.SetUserName(username)
			.SetPassword(password)
			.Send((response) => {
				if(!response.HasErrors){
					UserInfo.setPlayerName(response.DisplayName);
					UserInfo.setUserId(response.UserId);
					UserInfo.setMonsters(new List<UserInfo.Monster>());
					UserInfo.setPreferences(new UserInfo.Configurable());
					Api.requestUserInfo();
					Manager.toRanchScreen();
				} else {
                    generateError("Username Taken");
				}
			});

    }
}
