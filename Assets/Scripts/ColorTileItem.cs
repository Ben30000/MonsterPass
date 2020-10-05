using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ColorTileItem : Content
     , IPointerClickHandler
     , IPointerEnterHandler
, IPointerExitHandler
{

    //private Color color;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    public Color getColor()
    {
        return this.color;
    }

    public void setColor(Color color)
    {
        this.color = color;
        this.gameObject.GetComponent<Image>().color = color;
    }
    */



    public void OnPointerClick(PointerEventData eventData)
    {
        print("TileItem clicked");


        boardogInfo monster = GameObject.Find("Boardog").GetComponent<boardogInfo>();

        // Get body part type
        string bodyPartType = this.gameObject.transform.parent.gameObject.GetComponent<ColorTileItemList>().getBodyPartType();
        //string bodyPartType = "eye";

        if (bodyPartType == "eye")
        {
            monster.currEyeColor = this.getColor();
        }
        else if (bodyPartType == "body")
        {
            monster.currBodyColor = this.getColor();

        }
        else if (bodyPartType == "horn")
        {
            monster.currHornColor = this.getColor();
        }
        


        //transform.parent.gameObject.GetComponent<TabbedWindow>().setActiveTab(this);
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
