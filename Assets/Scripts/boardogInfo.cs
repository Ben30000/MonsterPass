using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Anima2D;
using System;
using System.Text;
using UnityEngine.SceneManagement;
using GameSparks.Api.Requests;
using GameSparks.Core;

public class boardogInfo : MonoBehaviour
{
    //This is a comment
    //These are references to the game objects that must be changed
    public SpriteMeshInstance baseBod;
    public SpriteRenderer eye;
    public SpriteRenderer ear;
    public SpriteRenderer tail;
    public SpriteRenderer horn;

    public Color currBodyColor;
    public Color currEyeColor;
    public Color currHornColor;

    //these should be updated to match the boardog's data from GameSparks
    public string userID = "";
    public int currEye;
    public int currEar;
    public int currTail;
    public int currHorn;

    public string gsColor; //the color string from gamesparks



    //this is the database of images that we reference
    monpartDatabase partData;

    void Start()
    {
        //find location of the monsterpart database
        partData = GameObject.FindWithTag("MonsterParts").GetComponent<monpartDatabase>();


        string activeSceneName = SceneManager.GetActiveScene().name;

        if (activeSceneName == "monsterEditingScreen")
        {

            int isItNew = 1;

            new LogEventRequest()
               .SetEventKey("GetMonster")
               .Send((response) =>
               {
                   if (!response.HasErrors)
                   {
                       //Debug.Log("Monster loaded successfully");




                       if (response.ScriptData.GetGSData("MONSTER") != null)
                       {

                       }
                       // get the attribute JSON
                       GSData attrib = response.ScriptData.GetGSData("MONSTER").GetGSData("ATTRIBUTES");
                       if (attrib == null)
                       {
                           //Debug.Log("NO MONSTER INIITIALIZED");

                       }
                       currEye = (int)attrib.GetNumber("EYES");
                       currEar = (int)attrib.GetNumber("EARS");
                       currTail = (int)attrib.GetNumber("TAIL");
                       currHorn = (int)attrib.GetNumber("HORN");

                       gsColor = attrib.GetString("COLOR");

                       if (this.gsColor.Length == 6 || this.gsColor.Length == 7 || this.gsColor.Length == 19)
                       {
                           isItNew = 1;
                       }
                       else
                       {
                           StringBuilder sb = new StringBuilder(gsColor);
                           isItNew = Int32.Parse(sb[19].ToString());
                       }









                       if (gsColor.Length == 6 || gsColor.Length == 7)
                       {
                           //
                           // To support the old format of a single color for every body part
                           //
                           ColorUtility.TryParseHtmlString(gsColor, out currBodyColor);
                           ColorUtility.TryParseHtmlString(gsColor, out currEyeColor);
                           ColorUtility.TryParseHtmlString(gsColor, out currHornColor);
                       }
                       else
                       {
                           // 
                           // New format of per body part color
                           //

                           StringBuilder sb = new StringBuilder(gsColor);
                           string bodyColorString = sb[0].ToString() + sb[1].ToString() + sb[2].ToString() + sb[3].ToString() + sb[4].ToString() + sb[5].ToString() + sb[6].ToString();
                           string eyeColorString = sb[0].ToString() + sb[7].ToString() + sb[8].ToString() + sb[9].ToString() + sb[10].ToString() + sb[11].ToString() + sb[12].ToString();
                           string hornColorString = sb[0].ToString() + sb[13].ToString() + sb[14].ToString() + sb[15].ToString() + sb[16].ToString() + sb[17].ToString() + sb[18].ToString();

                           ColorUtility.TryParseHtmlString(bodyColorString, out currBodyColor);
                           ColorUtility.TryParseHtmlString(eyeColorString, out currEyeColor);
                           ColorUtility.TryParseHtmlString(hornColorString, out currHornColor);

                       }






                       // Check if a monster has been created for this user
                       // If not, randomize features

                       if (isItNew == 1)
                       {

                           System.Random randomGeneratorDouble = new System.Random();
                           System.Random randomGeneratorInt = new System.Random();
                           
                           currEye = randomGeneratorInt.Next(partData.numberEyes + 1);
                           currEar = randomGeneratorInt.Next(partData.numberEars + 1);
                           currTail = randomGeneratorInt.Next(partData.numberTails + 1);
                           currHorn = randomGeneratorInt.Next(partData.numberHorns + 1);

                           currBodyColor = new Color((float)randomGeneratorDouble.NextDouble(), (float)randomGeneratorDouble.NextDouble(), (float)randomGeneratorDouble.NextDouble(), 1.0f);
                           currEyeColor = new Color((float)randomGeneratorDouble.NextDouble(), (float)randomGeneratorDouble.NextDouble(), (float)randomGeneratorDouble.NextDouble(), 1.0f);
                           currHornColor = new Color((float)randomGeneratorDouble.NextDouble(), (float)randomGeneratorDouble.NextDouble(), (float)randomGeneratorDouble.NextDouble(), 1.0f);

                       }





                   }
                   else
                   {
                       Debug.Log("Couldn't load monster");
                   }
               });


        }



        //setup color from data
        //currColor = ...
        baseBod.color = currBodyColor;
        tail.color = currBodyColor;
        ear.color = currBodyColor;
        eye.color = currEyeColor;
        horn.color = currHornColor;


        //setup eye,ear,tail, and horn from data
        //currEye = ...
        eye.sprite = partData.getEye(currEye);
        ear.sprite = partData.getEar(currEar);
        tail.sprite = partData.getEye(currTail);
        horn.sprite = partData.getHorn(currHorn);


    }

    // Update is called once per frame
    void Update()
    {

        string activeSceneName = SceneManager.GetActiveScene().name;

        eye.sprite = partData.getEye(currEye);
        ear.sprite = partData.getEar(currEar);
        tail.sprite = partData.getTail(currTail);
        horn.sprite = partData.getHorn(currHorn);
        /*
        Debug.Log("EYE " + currEye);
        Debug.Log("EAR " + currEar);
        Debug.Log("TAIL " + currTail);
        Debug.Log("HORN " + currHorn);
        */
        //
        // If on editing screen don't fetch colors from GS as the monster has not yet been saved
        //
        if (activeSceneName != "monsterEditingScreen")
        {


            if (gsColor.Length == 6 || gsColor.Length == 7)
            {
                //
                // To support the old format of a single color for every body part
                //
                ColorUtility.TryParseHtmlString(gsColor, out currBodyColor);
                ColorUtility.TryParseHtmlString(gsColor, out currEyeColor);
                ColorUtility.TryParseHtmlString(gsColor, out currHornColor);
            }
            else
            {
                // 
                // New format of per body part color
                //
                //Debug.Log("More than one color detected!");
                // Debug.Log("Color string is " + gsColor);
                StringBuilder sb = new StringBuilder(gsColor);
                string bodyColorString = sb[0].ToString() + sb[1].ToString() + sb[2].ToString() + sb[3].ToString() + sb[4].ToString() + sb[5].ToString() + sb[6].ToString();
                string eyeColorString = sb[0].ToString() + sb[7].ToString() + sb[8].ToString() + sb[9].ToString() + sb[10].ToString() + sb[11].ToString() + sb[12].ToString();
                string hornColorString = sb[0].ToString() + sb[13].ToString() + sb[14].ToString() + sb[15].ToString() + sb[16].ToString() + sb[17].ToString() + sb[18].ToString();

                ColorUtility.TryParseHtmlString(bodyColorString, out currBodyColor);
                ColorUtility.TryParseHtmlString(eyeColorString, out currEyeColor);
                ColorUtility.TryParseHtmlString(hornColorString, out currHornColor);

            }


        }

        baseBod.color = currBodyColor;
        tail.color = currBodyColor;
        ear.color = currBodyColor;
        eye.color = currEyeColor;
        horn.color = currHornColor;



    }

    public void setActive(bool active)
    {
        this.gameObject.SetActive(active);
    }

    public bool getActive()
    {
        return this.isActiveAndEnabled;
    }

    /*
    int parseGsData(GSData responseData)
    {

        if (responseData == null)
            return -1;
        // get the attribute JSON
        GSData attrib = responseData.GetGSData("ATTRIBUTES");
        if (attrib == null)
            return -1;

        UserBoardog.currEye = (int)attrib.GetNumber("EYES");
        UserBoardog.currEar = (int)attrib.GetNumber("EARS");
        UserBoardog.currTail = (int)attrib.GetNumber("TAIL");
        UserBoardog.currHorn = (int)attrib.GetNumber("HORN");

        UserBoardog.gsColor = attrib.GetString("COLOR");
        ColorUtility.TryParseHtmlString(UserBoardog.gsColor, out UserBoardog.currBodyColor);


        return 0;
    }

    */

}
