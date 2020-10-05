using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Content : MonoBehaviour
{
    // Width and Height are normalized, , filling the Content objects' parent panel/canvas
    // WidthOffset and HeightOffset are derived from the contents' parent object
    public float width, height, widthOffset, heightOffset;
    public Vector3 position;
    private Vector3 scale;
    private Color color;
    private string type;
    private bool active;

    // Start is called before the first frame update
    void Start()
    {

        this.scale = new Vector3(1.0f, 1.0f, 1.0f);
        gameObject.GetComponent<RectTransform>().localScale = this.scale;

        this.position = new Vector3(0.0f, 0.0f,0.0f);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(position.x,position.y);
        
        this.color = new Color(1.0f, 0.0f, 1.0f);
        gameObject.GetComponent<Image>().color = this.color;
        
        
        Debug.Log("Content panel's parent has width of " + gameObject.transform.parent.gameObject.GetComponent<RectTransform>().rect.width);
        Debug.Log("Content panel's parent has height of " + gameObject.transform.parent.gameObject.GetComponent<RectTransform>().rect.height);

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setDimensions(float w, float h)
    {
        this.width = w;
        this.height = h;
        this.widthOffset = 0.5f * gameObject.transform.parent.gameObject.GetComponent<RectTransform>().rect.width;
        this.heightOffset = 0.5f * gameObject.transform.parent.gameObject.GetComponent<RectTransform>().rect.height;
        gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-1.0f*(1.0f - width) * widthOffset, -1.0f*(1.0f - height) * heightOffset);
        gameObject.GetComponent<RectTransform>().offsetMin = new Vector2((1.0f - width) * widthOffset, (1.0f - height) * heightOffset);
        

    }
    
    float getWidth()
    {
        return this.width;
    }
    float getHeight()
    {
        return this.height;
    }
    
    public void setPositionDimensionsAndType(float x, float y, float z,  float w, float h, string type)
    {
        this.position.x = x;
        this.position.y = y;
        this.position.z = z;

        this.width = w;
        this.height = h;


        // Must set dimensions to start
        this.widthOffset = 0.5f * gameObject.transform.parent.gameObject.GetComponent<RectTransform>().rect.width;
        this.heightOffset = 0.5f * gameObject.transform.parent.gameObject.GetComponent<RectTransform>().rect.height;
        gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-1.0f * (1.0f - width) * widthOffset, -1.0f * (1.0f - height) * heightOffset);
        gameObject.GetComponent<RectTransform>().offsetMin = new Vector2((1.0f - width) * widthOffset, (1.0f - height) * heightOffset);

        // Then must set position
        float gapWidth = (1.0f - this.width) * widthOffset;
        float gapHeight = (1.0f - this.height) * heightOffset;
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2((2.0f*this.position.x - 1.0f) * gapWidth, (2.0f*this.position.y - 1.0f)*gapHeight);

        this.type = type;
    }

    public void setColor(Color color)
    {
        this.color = color;
        gameObject.GetComponent<Image>().color = this.color;
    }
    public Color getColor()
    {
        return this.color;
    }

    public void setType(string type)
    {
        this.type = type;
    }

    public string getType()
    {
        return this.type;
    }

    public GameObject getGameObject()
    {
        return this.gameObject;
    }
    
    public void activate()
    {
        this.active = true;
        this.gameObject.SetActive(true);
    }

    public void deactivate()
    {
        this.active = false;
        this.gameObject.SetActive(false);
    }

    public bool isActive()
    {
        return this.active;
    }
}
