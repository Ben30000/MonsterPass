using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTileItemList : Content
{
    private string bodyPartType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
