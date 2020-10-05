using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShapeTileItemList : Content
{
    private string bodyPartType;
    private List<ShapeTileItem> shapeTileItemList;
    private int shapeTileItemsPerRow = 4;
    private int shapeTileItemsRowCount = 3;
    private float shapeTileWidth = 0.25f;
    private float shapeTileHeight = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        //this.bodyPartType = "eye";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initialize(string type)
    {
        this.bodyPartType = type;
        this.shapeTileItemList = new List<ShapeTileItem>();

        // Generate all the body part shape tiles for this body part type and add them to this ShapeTileItemList's shapeTileList

        monpartDatabase partData = GameObject.FindWithTag("MonsterParts").GetComponent<monpartDatabase>();

        int bodyPartCount = 1;
        if (type == "ear")
        {
            bodyPartCount = partData.numberEars;
        } else if (type == "horn")
        {
            bodyPartCount = partData.numberHorns;
        } else if (type == "eye")
        {
            bodyPartCount = partData.numberEyes;
        } else if (type == "tail")
        {
            bodyPartCount = partData.numberTails;
        }

        ShapeTileItem referenceShapeTileItem = GameObject.Find("ReferenceShapeTileItem").GetComponent<ShapeTileItem>();
        //bodyPartCount = 9;
        float initialHorizontalOffset = 0.05f;
        float horizontalSpacing = 0.2f;

        for (int k = 1; k <= bodyPartCount; k++)
        {

            if ( (float)((k - 1) % shapeTileItemsPerRow) == 0.0f )
            {
                //initialHorizontalOffset = 0.05f;
                horizontalSpacing = 0.0f;
            }
            ShapeTileItem newShape = Instantiate(referenceShapeTileItem, this.gameObject.transform);
            newShape.setPositionDimensionsAndType(  initialHorizontalOffset  + (shapeTileWidth + 0.05f)*( (float)(k - 1) % (float)shapeTileItemsPerRow), -0.04f + 1.0f - (float)Math.Floor((float)((k - 1) / shapeTileItemsPerRow)) / (float)shapeTileItemsRowCount, 0.0f,
                shapeTileWidth, shapeTileHeight, "ShapeTileItem");
            newShape.setColor(new Color(1.0f, 1.0f, 1.0f, 1.0f));
            newShape.setBodyPartID(type,k,partData);
            newShape.activate();
            shapeTileItemList.Add(newShape);
        }

        //referenceShapeTileItem.deactivate();
        
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
