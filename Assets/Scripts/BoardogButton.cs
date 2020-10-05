using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardogButton : MonoBehaviour
{
    private boardogInfo DisplayBoardog;
    //private boardogInfo YourBoardog;
    public boardogInfo CurBoardog;

    // Start is called before the first frame update
    void Start()
    {
        DisplayBoardog = GameObject.Find("Received Boardog").GetComponent<boardogInfo>();
    }

    public void updateDisplayBoardog()
    {
        DisplayBoardog.userID = CurBoardog.userID;
        DisplayBoardog.currEye = CurBoardog.currEye;
        DisplayBoardog.currEar = CurBoardog.currEar;
        DisplayBoardog.currHorn = CurBoardog.currHorn;
        DisplayBoardog.currTail = CurBoardog.currTail;
        DisplayBoardog.gsColor = CurBoardog.gsColor;

        /*
        YourBoardog.currEye = CurBoardog.currEye;
        YourBoardog.currEar = CurBoardog.currEar;
        YourBoardog.currHorn = CurBoardog.currHorn;
        YourBoardog.currTail = CurBoardog.currTail;
        YourBoardog.gsColor = CurBoardog.gsColor;
        */
        //DisplayBoardog.gsColorEyes = CurBoardog.gsColorEyes;
        //DisplayBoardog.gsColorHorn = CurBoardog.gsColorHorn;
    }

    public void updateCurBoardog(
        string userId,
        string name,
        int eyes,
        int ears,
        int horn,
        int tail,
        string color
        //,string colorEyes,
        //string colorHorn
        )
    {
        CurBoardog = this.gameObject.GetComponentInChildren<boardogInfo>();
        CurBoardog.userID = userId;
        CurBoardog.currEye = eyes;
        CurBoardog.currEar = ears;
        CurBoardog.currHorn = horn;
        CurBoardog.currTail = tail;
        CurBoardog.gsColor = color;
        //CurBoardog.gsColorEyes = colorEyes;
        //CurBoardog.gsColorHorn = colorHorn;

    }
}
