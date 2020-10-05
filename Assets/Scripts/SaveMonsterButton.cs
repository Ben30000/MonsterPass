using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;

using GameSparks.Core;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using UnityEngine.EventSystems;

public class SaveMonsterButton : Content, IPointerClickHandler
     , IPointerEnterHandler
, IPointerExitHandler
{
    UserInfo UserInfo;
    boardogInfo createdBoarDog;
    GameObject saveWaitPanel;

    // Start is called before the first frame update
    void Start()
    {
        UserInfo = GameObject.Find("UserInfo").GetComponent<UserInfo>();
        createdBoarDog = GameObject.Find("Boardog").GetComponent<boardogInfo>();

        saveWaitPanel = GameObject.Find("SaveWaitPanel");
        saveWaitPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void saveUsersMonster()
    {

        saveWaitPanel.SetActive(true);

        GSRequestData jsonData = new GSRequestData();
        jsonData.AddNumber("EYES", createdBoarDog.currEye);
        jsonData.AddNumber("EARS", createdBoarDog.currEar);
        jsonData.AddNumber("HORN", createdBoarDog.currHorn);
        jsonData.AddNumber("TAIL", createdBoarDog.currTail);
        string bodyColor = ColorUtility.ToHtmlStringRGB(createdBoarDog.currBodyColor);
        string eyeColor = ColorUtility.ToHtmlStringRGB(createdBoarDog.currEyeColor);
        string hornColor = ColorUtility.ToHtmlStringRGB(createdBoarDog.currHornColor);
        jsonData.AddString("COLOR", "#" + bodyColor + eyeColor + hornColor + "0");




        new LogEventRequest().SetEventKey("SaveMonster").SetEventAttribute("NAME", UserInfo.getPlayerName()).SetEventAttribute("ATTRIBUTES", jsonData).Send((response) => {
            if (!response.HasErrors)
            {
                Debug.Log("Monster Saved To GameSparks...");
                saveWaitPanel.SetActive(false);

            }
            else
            {
                Debug.Log("Error Saving Monster Data...");
            }
        });

    }





    public void OnPointerClick(PointerEventData eventData)
    {
        print("SAVE BUTTON PRESSED");
        saveUsersMonster();




    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hi!");
        gameObject.GetComponent<Image>().color = new Color(1.25f * gameObject.GetComponent<Image>().color.r, 1.25f * gameObject.GetComponent<Image>().color.g, 1.25f * gameObject.GetComponent<Image>().color.b);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //    print("Tab exited!");
        gameObject.GetComponent<Image>().color = new Color(0.8f * gameObject.GetComponent<Image>().color.r, 0.8f * gameObject.GetComponent<Image>().color.g, 0.8f * gameObject.GetComponent<Image>().color.b);
        //transform.parent.gameObject.GetComponent<ContentPanel>().setActiveTab(this.gameObject);
    }
}
