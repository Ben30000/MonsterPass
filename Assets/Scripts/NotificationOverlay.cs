using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationOverlay : MonoBehaviour
{
    private ManageScenes Manager;
    private UserInfo UserInfo;

    public GameObject MenuOrgPos, MenuActPos, MenuPanel; // Reference to the positions
    public float moveSpeed;

    // Private control logic
    private bool openMenu;
    private bool movePanel;
    private float tempPos;

    public GameObject NotificationPrefab;
    public Text NotificationText;
    public VerticalLayoutGroup LayoutGroup;
    public ScrollRect ScrollView;
    public GameObject ScrollContent;

    // Start is called before the first frame update
    // Starts with menu closed
    void Start()
    {
        Manager = GameObject.Find("SceneManager").GetComponent<ManageScenes>();
        UserInfo = GameObject.Find("UserInfo").GetComponent<UserInfo>();

        MenuPanel.transform.position = MenuOrgPos.transform.position;
        openMenu = false;
        movePanel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(UserInfo.checkNewNotifications())
        {
            for(int i = ScrollContent.transform.childCount - 1; i>=0; i--)
            {
                GameObject child = ScrollContent.transform.GetChild(i).gameObject;
                Destroy(child);
            }
            foreach(string note in UserInfo.getNotifications())
            {
                genNotification(note);
            }
            NotificationText.text = UserInfo.getNotifications().Count.ToString();
            if(NotificationText.text == "0")
                NotificationText.text = "";
        }

        // If menu should be open and panel is moving, open with interpolated transform
        // Otherwise close with interpolated transform
        // Do nothing if the panel is already in position
        if(openMenu && movePanel){
            // Move the transform of menu to open
            MenuPanel.transform.position = Vector3.Lerp(
                MenuPanel.transform.position, 
                MenuActPos.transform.position, 
                moveSpeed * Time.deltaTime // Allows for a gradual acceleration 
                );

            // Check if transition is small from previous
            if(MenuPanel.transform.localPosition.x == tempPos) {
                movePanel = false;
                MenuPanel.transform.position = MenuActPos.transform.position;
                tempPos = -9999999999.99f;
            }
            if(movePanel) tempPos = MenuPanel.transform.position.x;
        } else {
            // Move the tranform of the menu to close
            MenuPanel.transform.position = Vector3.Lerp(
                MenuPanel.transform.position, 
                MenuOrgPos.transform.position, 
                moveSpeed * Time.deltaTime // Allows for a gradual acceleration 
                );
            
            // Check if transition is small since previous
            if(MenuPanel.transform.localPosition.x == tempPos) {
                movePanel = false;
                MenuPanel.transform.position = MenuOrgPos.transform.position;
                tempPos = -9999999999.99f;
            }
            if(movePanel) tempPos = MenuPanel.transform.position.x;
        }
    }

    // Method for starting the update movement
    public void toggleMenuPanel()
    {
        openMenu = !openMenu;
        movePanel = true;

        if(!openMenu)
            UserInfo.setNotifications(new List<string>());
    }

    public void openMenuPanel()
    {
        openMenu = true;
        movePanel = true;
    }

    public void closeMenuPanel()
    {
        openMenu = false;
        movePanel = true;

        UserInfo.setNotifications(new List<string>());
    }

    public void genNotification(string message)
    {
        GameObject newItem = Instantiate(NotificationPrefab);
        newItem.transform.SetParent(ScrollContent.transform, false);
        newItem.GetComponentInChildren<Text>().text = message;
    }
}
