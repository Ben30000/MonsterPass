using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

public class Tab : Content
     , IPointerClickHandler
//   , IDragHandler
     , IPointerEnterHandler
, IPointerExitHandler
{

    // Variable: parentTabbedWindow, the parent TabbedWindow of this Tab


    // Variable: content, the Content pointed to by this Tab
    private string title;
    public Content content;
    // Variable: contentType, the type of Content pointed to by this Tab. 1 = ScrollingItemList
    private string type;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void setContent(Content content)
    {
        this.content = content;
    }
    
    public Content getContent()
    {
        return this.content;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        print("Tab clicked");
        transform.parent.gameObject.GetComponent<TabbedWindow>().setActiveTab(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //print("Tab entered!");
        gameObject.GetComponent<Image>().color = new Color(1.25f * gameObject.GetComponent<Image>().color.r, 1.25f * gameObject.GetComponent<Image>().color.g, 1.25f * gameObject.GetComponent<Image>().color.b);
        //transform.parent.gameObject.GetComponent<ContentPanel>().setActiveTab(this.gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    //    print("Tab exited!");
        gameObject.GetComponent<Image>().color = new Color(0.8f * gameObject.GetComponent<Image>().color.r, 0.8f * gameObject.GetComponent<Image>().color.g, 0.8f * gameObject.GetComponent<Image>().color.b);
        //transform.parent.gameObject.GetComponent<ContentPanel>().setActiveTab(this.gameObject);
    }

    public string getTitle()
    {
        return this.title;
    }

    public void setTitle(string title)
    {
        this.title = title;
        gameObject.transform.GetChild(0).GetComponent<Text>().text = this.title;
        gameObject.transform.GetChild(0).GetComponent<Text>().color = new Color(1.0f,1.0f,1.0f);
    }

    

    
}
