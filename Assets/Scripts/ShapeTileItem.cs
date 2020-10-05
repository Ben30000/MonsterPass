using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ShapeTileItem : Content
     , IPointerClickHandler
     , IPointerEnterHandler
, IPointerExitHandler
{

    private int bodyPartID;
    private string bodyPartType;
    private monpartDatabase partDatabase;

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
        //string bodyPartType = this.gameObject.transform.parent.gameObject.GetComponent<ColorTileItemList>().getBodyPartType();
        //string bodyPartType = "eye";

        if (bodyPartType == "eye")
        {
            //monster.eye.sprite = partDatabase.getEye(bodyPartID);
            monster.currEye = this.bodyPartID;
        }
        else if (bodyPartType == "ear")
        {
            //monster.ear.sprite = partDatabase.getEar(bodyPartID);
            monster.currEar = this.bodyPartID;

        }
        else if (bodyPartType == "horn")
        {
            //monster.horn.sprite = partDatabase.getHorn(bodyPartID);
            monster.currHorn = this.bodyPartID;
        }
        else if (bodyPartType == "tail")
        {
            //monster.tail.sprite = partDatabase.getTail(bodyPartID);
            monster.currTail = this.bodyPartID;
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

    public void setBodyPartID(string type, int ID, monpartDatabase partData)
    {
        this.bodyPartID = ID;
        this.bodyPartType = type;
        this.partDatabase = partData;

        if (type == "ear") {
            this.gameObject.GetComponent<Image>().sprite = partData.getEar(ID);
        }
        else if (type == "eye")
        {
            this.gameObject.GetComponent<Image>().sprite = partData.getEye(ID);
        }
        else if (type == "tail")
        {
            this.gameObject.GetComponent<Image>().sprite = partData.getTail(ID);
        }
        else if (type == "horn")
        {
            this.gameObject.GetComponent<Image>().sprite = partData.getHorn(ID);
        }
    }
    public int getBodyPartID()
    {
        return this.bodyPartID;
    }

    public void setBodyPartType(string type)
    {
        this.bodyPartType = type;
    }
    public string getBodyPartType()
    {
        return this.bodyPartType;
    }
}
