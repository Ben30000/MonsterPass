using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSliderPanel : Content
{
    
    private string bodyPartType;
    GameObject redSlider, greenSlider, blueSlider;
    float redValue, greenValue, blueValue;
    boardogInfo bDog;

    // Start is called before the first frame update
    void Start()
    {
        
        redSlider = this.transform.Find("RedSlider").gameObject;
        greenSlider = this.transform.Find("GreenSlider").gameObject;
        blueSlider = this.transform.Find("BlueSlider").gameObject;

        bDog = GameObject.Find("Boardog").GetComponent<boardogInfo>();

        if (bodyPartType == "body")
        {
            redValue = bDog.currBodyColor.r;
            greenValue = bDog.currBodyColor.g;
            blueValue = bDog.currBodyColor.b;
        }
        else if (bodyPartType == "eye")
        {
            redValue = bDog.currEyeColor.r;
            greenValue = bDog.currEyeColor.g;
            blueValue = bDog.currEyeColor.b;
        }
        else if (bodyPartType == "horn")
        {
            redValue = bDog.currHornColor.r;
            greenValue = bDog.currHornColor.g;
            blueValue = bDog.currHornColor.b;
        }

        redSlider.GetComponent<Slider>().value = redValue;
        greenSlider.GetComponent<Slider>().value = greenValue;
        blueSlider.GetComponent<Slider>().value = blueValue;
    }

    // Update is called once per frame
    void Update()
    {

        // Fetch colors from slider bars and update boardog

        redValue = redSlider.GetComponent<Slider>().value;
        greenValue = greenSlider.GetComponent<Slider>().value;
        blueValue = blueSlider.GetComponent<Slider>().value;


        if (bodyPartType == "body")
        {
            bDog.currBodyColor.r = redValue;
            bDog.currBodyColor.g = greenValue;
            bDog.currBodyColor.b = blueValue;
        }
        else if (bodyPartType == "eye")
        {
            bDog.currEyeColor.r = redValue;
            bDog.currEyeColor.g = greenValue;
            bDog.currEyeColor.b = blueValue;
        }
        else if (bodyPartType == "horn")
        {
            bDog.currHornColor.r = redValue;
            bDog.currHornColor.g = greenValue;
            bDog.currHornColor.b = blueValue;
        }


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
