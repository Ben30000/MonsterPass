using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameSparks.Api.Requests;
using GameSparks.Core;
using System.Text;

public class RenderBoardog : MonoBehaviour
{
    public boardogInfo UserBoardog;
    public boardogInfo ReceivedBoardog;

    void Start() {

        UserBoardog.setActive(false);
        // Set the User's Boardog
        new LogEventRequest()
                .SetEventKey("GetMonster")
                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        Debug.Log ("Monster loaded successfully");
                        UserBoardog.setActive(true);
                        if (parseGsData (response.ScriptData.GetGSData("MONSTER")) != 0)
                            Debug.Log ("Invalid response format");


                    }
                    else
                    {
                       Debug.Log("Couldn't load monster");
                    }
                });
    }

    int parseGsData(GSData responseData)
    {
		
        if (responseData == null)
            return -1;
        // get the attribute JSON
        GSData attrib = responseData.GetGSData ("ATTRIBUTES");
        if (attrib == null)
            return -1;

        UserBoardog.currEye = (int) attrib.GetNumber ("EYES");
        UserBoardog.currEar = (int) attrib.GetNumber ("EARS");
        UserBoardog.currTail = (int) attrib.GetNumber ("TAIL");
        UserBoardog.currHorn = (int) attrib.GetNumber ("HORN");

        UserBoardog.gsColor = attrib.GetString ("COLOR");

        /*
        if (UserBoardog.gsColor.Length == 6 || UserBoardog.gsColor.Length == 7)
        {
            //
            // To support the old format of a single color for every body part
            //
            ColorUtility.TryParseHtmlString(UserBoardog.gsColor, out UserBoardog.currBodyColor);
            ColorUtility.TryParseHtmlString(UserBoardog.gsColor, out UserBoardog.currEyeColor);
            ColorUtility.TryParseHtmlString(UserBoardog.gsColor, out UserBoardog.currHornColor);
        }
        else
        {
            // 
            // New format of per body part color
            //
            //Debug.Log("More than one color detected!");
            // Debug.Log("Color string is " + gsColor);
            StringBuilder sb = new StringBuilder(UserBoardog.gsColor);
            string bodyColorString = sb[0].ToString() + sb[1].ToString() + sb[2].ToString() + sb[3].ToString() + sb[4].ToString() + sb[5].ToString() + sb[6].ToString();
            string eyeColorString = sb[0].ToString() + sb[7].ToString() + sb[8].ToString() + sb[9].ToString() + sb[10].ToString() + sb[11].ToString() + sb[12].ToString();
            string hornColorString = sb[0].ToString() + sb[13].ToString() + sb[14].ToString() + sb[15].ToString() + sb[16].ToString() + sb[17].ToString() + sb[18].ToString();

            ColorUtility.TryParseHtmlString(bodyColorString, out UserBoardog.currBodyColor);
            ColorUtility.TryParseHtmlString(eyeColorString, out UserBoardog.currEyeColor);
            ColorUtility.TryParseHtmlString(hornColorString, out UserBoardog.currHornColor);

        }
        */
        ColorUtility.TryParseHtmlString (UserBoardog.gsColor, out UserBoardog.currBodyColor);


        return 0;
    }

    public void setUserBoardog()
    {

        UserBoardog.currEar = 2;
        UserBoardog.currEye = 1;
        UserBoardog.currHorn = 1;
        UserBoardog.currTail = 1;
        UserBoardog.gsColor = "#00ff00";
        //UserBoardog.gsColorEyes = "#ff0000";
        //UserBoardog.gsColorHorn = "#ff0000";

    }

    public void setReceivedBoardog(int eyes, int ears, int horn, int tail, string color)
    {

        ReceivedBoardog.currEye = eyes;
        ReceivedBoardog.currEar = ears;
        ReceivedBoardog.currHorn = horn;
        ReceivedBoardog.currTail = tail;
        ReceivedBoardog.gsColor = color;
        //ReceivedBoardog.gsColorEyes = color;
        //ReceivedBoardog.gsColorHorn = color;

    }
}
