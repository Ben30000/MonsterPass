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
    // Start is called before the first frame update
    void Start()
    {
        aTab1 = GameObject.Find("aTab");
        aTab1.SetActive(true);

        aTab1.GetComponent<RectTransform>().position = new Vector3(aTab1.GetComponent<RectTransform>().position.x, aTab1.GetComponent<RectTransform>().position.y +  4.0f, aTab1.GetComponent<RectTransform>().position.z);
        aTab2 = (GameObject)Instantiate(GameObject.Find("aTab"),this.transform);
        aTab2.SetActive(true);
        aTab2.GetComponent<RectTransform>().position = new Vector3(aTab2.GetComponent<RectTransform>().position.x, aTab2.GetComponent<RectTransform>().position.y - 10.0f, aTab2.GetComponent<RectTransform>().position.z);
        
        print("ContentPanel: start()");
        //aTab = (GameObject)(Resources.Load("Tab",typeof(GameObject)));
        //aTab.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Content Panel entered");
    }
}
