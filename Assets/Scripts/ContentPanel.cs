using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContentPanel : MonoBehaviour
     //, IPointerClickHandler 
     //, IDragHandler
     , IPointerEnterHandler
//, IPointerExitHandler
// ... And many more available!
{
    public GameObject aTab1;
    public GameObject aTab2;


    // Tab points to the actual object that will be rendered / updated within this content panel
    public GameObject activeTab;
    public GameObject[] tabs;
    //public GameObject[] selectableItems;
    //public ContentPanel contentPanel;

    // Visible Content is the part of content panel where any object can be drawn
    // visibleContent is simply a panel, used to provide a local anchoring point to whatever is drawn there
    public GameObject visibleContent;

    // Start is called before the first frame update
    void Start()
    {
        //      GameObject referenceTab = (gameObject.transform.Find("referenceTab")).gameObject;
        //GameObject referenceTab = GameObject.Find("referenceTab");
        //referenceTab.SetActive(false);


        // aTab1 = (GameObject)Instantiate(referenceTab, this.transform);
        //aTab1.SetActive(true);
        //aTab1.GetComponent<RectTransform>().localPosition = new Vector3(-50.0f, 175.0f, aTab1.GetComponent<RectTransform>().position.z);
        //aTab1.GetComponent<RectTransform>().sizeDelta = new Vector2(0.1f*aTab1.GetComponent<RectTransform>().rect.width, 0.1f*aTab1.GetComponent<RectTransform>().rect.height);
        //referenceTab.GetComponent<RectTransform>().position = new Vector3(aTab1.GetComponent<RectTransform>().position.x, aTab1.GetComponent<RectTransform>().position.y +  4.0f, aTab1.GetComponent<RectTransform>().position.z);
        //aTab2 = (GameObject)Instantiate(referenceTab, this.transform);
        //aTab2.SetActive(true);
        //aTab2.GetComponent<RectTransform>().localPosition = new Vector3(-250.0f, 175.0f, aTab2.GetComponent<RectTransform>().position.z);

        print("ContentPanel: start()");
        //aTab = (GameObject)(Resources.Load("Tab",typeof(GameObject)));
        //aTab.SetActive(true);

        //    GameObject aContentList = GameObject.Find("ContentList");
        //   aContentList.GetComponent<RectTransform>().localPosition = new Vector3(0.0f, 0.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        //print("ATab2 has width " + aTab2.GetComponent<Tab>().getWidth());

    }

    public void setActiveTab(GameObject activeTab)
    {
        this.activeTab = activeTab;
    }
    public GameObject getActiveTab()
    {
        return this.activeTab;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Content Panel entered");
    }
}
