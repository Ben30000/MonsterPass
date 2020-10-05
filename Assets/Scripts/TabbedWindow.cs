using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabbedWindow : Content
{
    private List<Tab> tabs;
    private Tab activeTab;
    private Content contentArea;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setActiveTab(Tab tab)
    {
        // Deactivate previous activeTab's Content
        if (this.activeTab != null)
        {
            this.activeTab.getContent().deactivate();
            Text oldActiveTabText = this.activeTab.gameObject.transform.Find("TabText").GetComponent<Text>();
            oldActiveTabText.fontSize = oldActiveTabText.fontSize - 8;
            oldActiveTabText.color = new Color(1.0f, 1.0f, 1.0f);
            this.activeTab.setPositionDimensionsAndType(this.activeTab.position.x, this.activeTab.setPositionDimensionsAndType.y, this.activeTab.setPositionDimensionsAndType.z,
                this.activeTab.setPositionDimensionsAndType.w, this.activeTab.setPositionDimensionsAndType.h, "Tab");
        }
        // Set activeTab to tab and Activate this new activeTab's Content
        this.activeTab = tab;
        Text newActiveTabText = this.activeTab.gameObject.transform.Find("TabText").GetComponent<Text>();
        newActiveTabText.fontSize = newActiveTabText.fontSize + 8;
        newActiveTabText.color = new Color(0.010f, 0.9940f, 0.050f);
        this.activeTab.getContent().activate();

    }
    public void setContentArea(Content content)
    {
        this.contentArea.gameObject.SetActive(false);
        this.contentArea = content;
        this.contentArea.gameObject.SetActive(true);
    }
    public Content getContentArea()
    {
        return this.contentArea;
    }

    public void addTab(Tab tab)
    {
        if (tabs == null)
        {
            tabs = new List<Tab>();
        }

        tabs.Add(tab);
    }

    public List<Tab> getTabs()
    {
        return this.tabs;
    }


}
