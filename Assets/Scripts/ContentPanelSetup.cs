using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentPanelSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        GameObject canvas = GameObject.Find("UI (Canvas)");
        float canvasWidth = canvas.GetComponent<RectTransform>().rect.width;
        float canvasHeight = canvas.GetComponent<RectTransform>().rect.height;
        Debug.Log("Canvas dimensions of " + canvasWidth + ", " + canvasHeight);

        

        // Save Wait Panel 

        //GameObject saveWaitPanel = GameObject.Find("SaveWaitPanel");
        //saveWaitPanel.SetActive(false);

        // Create Tabs

        GameObject referenceTab = GameObject.Find("TabbedWindowMain/Tab");
        //referenceTab.SetActive(false);

        // Width = 184


        // Outter Tabbed Window
        GameObject content1 = GameObject.Find("TabbedWindowMain");
        TabbedWindow theContent1 = content1.GetComponent<TabbedWindow>();
        theContent1.setPositionDimensionsAndType(0.5f, 0.05f, 0.0f, 0.9f, 0.35f, "TabbedWindow");
        theContent1.setColor(new Color(0.0f, 1.0f, 0.0f,0.20f));
        theContent1.activate();
        //    theContent1.deactivate();


        // Inner Tabbed Windows

        GameObject referenceTabbedWindow = GameObject.Find("TabbedWindowReference");
        TabbedWindow theReferenceTabbedWindow = referenceTabbedWindow.GetComponent<TabbedWindow>();
        theReferenceTabbedWindow.setPositionDimensionsAndType(0.0f, 0.0f, 0.0f, 1.0f, 0.86f, "TabbedWindow");
        theReferenceTabbedWindow.setColor(new Color(0.0f, 0.20f, 0.0f));
        theReferenceTabbedWindow.deactivate();




        TabbedWindow bodyTabbedWindow = Instantiate(referenceTabbedWindow, GameObject.Find("TabbedWindowMain").transform).GetComponent<TabbedWindow>();
        bodyTabbedWindow.setPositionDimensionsAndType(0.0f, 0.0f, 0.0f, 1.0f, 0.84f, "TabbedWindow");
        bodyTabbedWindow.setColor(new Color(0.0f, 0.5f, 0.5f));
        bodyTabbedWindow.deactivate();

        TabbedWindow eyesTabbedWindow = Instantiate(referenceTabbedWindow, GameObject.Find("TabbedWindowMain").transform).GetComponent<TabbedWindow>();
        eyesTabbedWindow.setPositionDimensionsAndType(0.0f, 0.0f, 0.0f, 1.0f, 0.84f, "TabbedWindow");
        eyesTabbedWindow.setColor(new Color(0.5f, 0.0f, 0.0f));
        eyesTabbedWindow.deactivate();
        
        TabbedWindow hornTabbedWindow = Instantiate(referenceTabbedWindow, GameObject.Find("TabbedWindowMain").transform).GetComponent<TabbedWindow>();
        hornTabbedWindow.setPositionDimensionsAndType(0.0f, 0.0f, 0.0f, 1.0f, 0.84f, "TabbedWindow");
        hornTabbedWindow.setColor(new Color(0.50f, 0.0f, 0.50f));
        hornTabbedWindow.deactivate();

        

        //theContent2.deactivate();





        // OUTTER TABBEDWINDOW TABS: BODY PART TABS

        Tab bodyTab = Instantiate(referenceTab, GameObject.Find("TabbedWindowMain").transform).GetComponent<Tab>();
        bodyTab.GetComponent<Tab>().setPositionDimensionsAndType(0.03f, 1.0f, 0.0f, 0.32f, 0.17f, "Tab");
        bodyTab.setColor(new Color(0.87f, 0.0f, 0.8f));
        bodyTab.setTitle("Body");
        bodyTab.setType("Tab");
        bodyTab.setContent(bodyTabbedWindow);
        bodyTab.activate();


        Tab eyeTab = Instantiate(referenceTab, GameObject.Find("TabbedWindowMain").transform).GetComponent<Tab>();
        eyeTab.GetComponent<Tab>().setPositionDimensionsAndType(0.50f, 1.0f, 0.0f, 0.32f, 0.17f, "Tab");
        eyeTab.setColor(new Color(0.9f, 0.8f, 0.0f));
        eyeTab.setTitle("Eyes");
        eyeTab.setType("Tab");
        eyeTab.setContent(eyesTabbedWindow);
        eyeTab.activate();

        

        Tab hornTab = Instantiate(referenceTab, GameObject.Find("TabbedWindowMain").transform).GetComponent<Tab>();
        hornTab.GetComponent<Tab>().setPositionDimensionsAndType(0.97f, 1.0f, 0.0f, 0.32f, 0.17f, "Tab");
        hornTab.setColor(new Color(0.1f, 0.8f, 0.0f));
        hornTab.setTitle("Horn");
        hornTab.setType("Tab");
        hornTab.setContent(hornTabbedWindow);
        hornTab.activate();

        
        



        // INNER TABBEDWINDOWS: SHAPE AND COLOR TABS

        // COLOR TABS
        Tab eyesColorTab = Instantiate(referenceTab, eyesTabbedWindow.getGameObject().transform).GetComponent<Tab>();
        eyesColorTab.GetComponent<Tab>().setPositionDimensionsAndType(0.03f, 0.990f, 0.0f, 0.22f, 0.141f, "Tab");
        eyesColorTab.setColor(new Color(0.8f, 0.2f, 0.4f));
        eyesColorTab.setTitle("Color");
        eyesColorTab.setType("Tab");
        //eyesColorTab.setContent(ColorList);
        eyesColorTab.activate();

        Tab bodyColorTab = Instantiate(referenceTab, bodyTabbedWindow.getGameObject().transform).GetComponent<Tab>();
        bodyColorTab.GetComponent<Tab>().setPositionDimensionsAndType(0.03f, 0.990f, 0.0f, 0.22f, 0.141f, "Tab");
        bodyColorTab.setColor(new Color(0.8f, 0.2f, 0.4f));
        bodyColorTab.setTitle("Color");
        bodyColorTab.setType("Tab");
        //bodyColorTab.setContent(ColorList);
        bodyColorTab.activate();

        Tab hornColorTab = Instantiate(referenceTab, hornTabbedWindow.getGameObject().transform).GetComponent<Tab>();
        hornColorTab.GetComponent<Tab>().setPositionDimensionsAndType(0.03f, 0.990f, 0.0f, 0.22f, 0.141f, "Tab");
        hornColorTab.setColor(new Color(0.8f, 0.2f, 0.4f));
        hornColorTab.setTitle("Color");
        hornColorTab.setType("Tab");
        //hornColorTab.setContent(ColorList);
        hornColorTab.activate();

        

        
        // SHAPE TABS
        Tab eyesShapeTab = Instantiate(referenceTab, eyesTabbedWindow.getGameObject().transform).GetComponent<Tab>();
        eyesShapeTab.GetComponent<Tab>().setPositionDimensionsAndType(0.26f, 0.990f, 0.0f, 0.22f, 0.141f, "Tab");
        eyesShapeTab.setColor(new Color(0.4f, 0.2f, 0.4f));
        eyesShapeTab.setTitle("Shape");
        eyesShapeTab.setType("Tab");
        //eyesShapeTab.setContent(ShapeList);
        eyesShapeTab.activate();

        Tab earsShapeTab = Instantiate(referenceTab, bodyTabbedWindow.getGameObject().transform).GetComponent<Tab>();
        earsShapeTab.GetComponent<Tab>().setPositionDimensionsAndType(0.31f, 0.990f, 0.0f, 0.22f, 0.141f, "Tab");
        earsShapeTab.setColor(new Color(0.2f, 0.2f, 0.8f));
        earsShapeTab.setTitle("Ear Shape");
        earsShapeTab.setType("Tab");
        //earsShapeTab.setContent(ShapeList);
        earsShapeTab.activate();

        Tab hornShapeTab = Instantiate(referenceTab, hornTabbedWindow.getGameObject().transform).GetComponent<Tab>();
        hornShapeTab.GetComponent<Tab>().setPositionDimensionsAndType(0.26f, 0.990f, 0.0f, 0.22f, 0.141f, "Tab");
        hornShapeTab.setColor(new Color(0.4f, 0.2f, 0.4f));
        hornShapeTab.setTitle("Shape");
        hornShapeTab.setType("Tab");
        //hornShapeTab.setContent(ShapeList);
        hornShapeTab.activate();

        Tab tailShapeTab = Instantiate(referenceTab, bodyTabbedWindow.getGameObject().transform).GetComponent<Tab>();
        tailShapeTab.GetComponent<Tab>().setPositionDimensionsAndType(0.59f, 0.990f, 0.0f, 0.22f, 0.141f, "Tab");
        tailShapeTab.setColor(new Color(0.2f, 0.8f, 0.4f));
        tailShapeTab.setTitle("Tail Shape");
        tailShapeTab.setType("Tab");
        //tailShapeTab.setContent(ShapeList);
        tailShapeTab.activate();












        /*
        // COLOR TILE ITEM LIST

        ColorTileItemList referenceColorTileItemList = GameObject.Find("ReferenceColorTileItemList").GetComponent<ColorTileItemList>();
        //referenceColorTileItemList.deactivate();

        ColorTileItemList eyesColorTileItemList = Instantiate(referenceColorTileItemList.getGameObject(), eyesTabbedWindow.getGameObject().transform).GetComponent<ColorTileItemList>();
        eyesColorTileItemList.setPositionDimensionsAndType(0.0f, 0.0f, 0.0f, 1.0f, 0.85f, "ColorTileItemList");
        eyesColorTileItemList.setBodyPartType("eye");

        ColorTileItemList bodyColorTileItemList = Instantiate(referenceColorTileItemList.getGameObject(), bodyTabbedWindow.getGameObject().transform).GetComponent<ColorTileItemList>();
        bodyColorTileItemList.setPositionDimensionsAndType(0.0f, 0.0f, 0.0f, 1.0f, 0.85f, "ColorTileItemList");
        bodyColorTileItemList.setBodyPartType("body");

        ColorTileItemList hornColorTileItemList = Instantiate(referenceColorTileItemList.getGameObject(), hornTabbedWindow.getGameObject().transform).GetComponent<ColorTileItemList>();
        hornColorTileItemList.setPositionDimensionsAndType(0.0f, 0.0f, 0.0f, 1.0f, 0.85f, "ColorTileItemList");
        hornColorTileItemList.setBodyPartType("horn");

        
        // COLOR TILE ITEMS

        ColorTileItem referenceColorTileItem = GameObject.Find("ReferenceColorTileItem").GetComponent<ColorTileItem>();
        referenceColorTileItem.deactivate();

        // RED
        ColorTileItem eyesRedColorTileItem = Instantiate(referenceColorTileItem.getGameObject(), eyesColorTileItemList.getGameObject().transform).GetComponent<ColorTileItem>();
        eyesRedColorTileItem.setPositionDimensionsAndType(0.06f, 0.770f, 0.0f, 0.2f, 0.2f, "ColorTileItem");
        eyesRedColorTileItem.setColor(new Color(1.0f, 0.0f, 0.0f));
        eyesRedColorTileItem.activate();
        ColorTileItem bodyRedColorTileItem = Instantiate(referenceColorTileItem.getGameObject(), bodyColorTileItemList.getGameObject().transform).GetComponent<ColorTileItem>();
        bodyRedColorTileItem.setPositionDimensionsAndType(0.06f, 0.770f, 0.0f, 0.2f, 0.2f, "ColorTileItem");
        bodyRedColorTileItem.setColor(new Color(1.0f, 0.0f, 0.0f));
        bodyRedColorTileItem.activate();
        ColorTileItem hornRedColorTileItem = Instantiate(referenceColorTileItem.getGameObject(), hornColorTileItemList.getGameObject().transform).GetComponent<ColorTileItem>();
        hornRedColorTileItem.setPositionDimensionsAndType(0.06f, 0.770f, 0.0f, 0.2f, 0.2f, "ColorTileItem");
        hornRedColorTileItem.setColor(new Color(1.0f, 0.0f, 0.0f));
        hornRedColorTileItem.activate();
        




        // GREEN

        ColorTileItem eyesGreenColorTileItem = Instantiate(referenceColorTileItem.getGameObject(), eyesColorTileItemList.getGameObject().transform).GetComponent<ColorTileItem>();
        eyesGreenColorTileItem.setPositionDimensionsAndType(0.3f, 0.770f, 0.0f, 0.2f, 0.2f, "ColorTileItem");
        eyesGreenColorTileItem.setColor(new Color(0.0f, 1.0f, 0.0f));
        eyesGreenColorTileItem.activate();
        ColorTileItem bodyGreenColorTileItem = Instantiate(referenceColorTileItem.getGameObject(), bodyColorTileItemList.getGameObject().transform).GetComponent<ColorTileItem>();
        bodyGreenColorTileItem.setPositionDimensionsAndType(0.3f, 0.770f, 0.0f, 0.2f, 0.2f, "ColorTileItem");
        bodyGreenColorTileItem.setColor(new Color(0.0f, 1.0f, 0.0f));
        bodyGreenColorTileItem.activate();
        ColorTileItem hornGreenColorTileItem = Instantiate(referenceColorTileItem.getGameObject(), hornColorTileItemList.getGameObject().transform).GetComponent<ColorTileItem>();
        hornGreenColorTileItem.setPositionDimensionsAndType(0.3f, 0.770f, 0.0f, 0.2f, 0.2f, "ColorTileItem");
        hornGreenColorTileItem.setColor(new Color(0.0f, 1.0f, 0.0f));
        hornGreenColorTileItem.activate();
        

        // BLUE

        ColorTileItem eyesBlueColorTileItem = Instantiate(referenceColorTileItem.getGameObject(), eyesColorTileItemList.getGameObject().transform).GetComponent<ColorTileItem>();
        eyesBlueColorTileItem.setPositionDimensionsAndType(0.54f, 0.770f, 0.0f, 0.2f, 0.2f, "ColorTileItem");
        eyesBlueColorTileItem.setColor(new Color(0.0f, 0.0f, 1.0f));
        eyesBlueColorTileItem.activate();
        ColorTileItem bodyBlueColorTileItem = Instantiate(referenceColorTileItem.getGameObject(), bodyColorTileItemList.getGameObject().transform).GetComponent<ColorTileItem>();
        bodyBlueColorTileItem.setPositionDimensionsAndType(0.54f, 0.770f, 0.0f, 0.2f, 0.2f, "ColorTileItem");
        bodyBlueColorTileItem.setColor(new Color(0.0f, 0.0f, 1.0f));
        bodyBlueColorTileItem.activate();
        ColorTileItem hornBlueColorTileItem = Instantiate(referenceColorTileItem.getGameObject(), hornColorTileItemList.getGameObject().transform).GetComponent<ColorTileItem>();
        hornBlueColorTileItem.setPositionDimensionsAndType(0.54f, 0.770f, 0.0f, 0.2f, 0.2f, "ColorTileItem");
        hornBlueColorTileItem.setColor(new Color(0.0f, 0.0f, 1.0f));
        hornBlueColorTileItem.activate();
       

        eyesColorTileItemList.deactivate();
        hornColorTileItemList.deactivate();
        bodyColorTileItemList.deactivate();

        






    */




        ColorSliderPanel referenceColorSliderPanel = GameObject.Find("ReferenceColorSliderPanel").GetComponent<ColorSliderPanel>();
        //referenceColorTileItemList.deactivate();

        ColorSliderPanel eyesColorSliderPanel = Instantiate(referenceColorSliderPanel.getGameObject(), eyesTabbedWindow.getGameObject().transform).GetComponent<ColorSliderPanel>();
        eyesColorSliderPanel.setPositionDimensionsAndType(0.0f, 0.0f, 0.0f, 1.0f, 0.85f, "ColorSliderPanel");
        eyesColorSliderPanel.setBodyPartType("eye");

        ColorSliderPanel bodyColorSliderPanel = Instantiate(referenceColorSliderPanel.getGameObject(), bodyTabbedWindow.getGameObject().transform).GetComponent<ColorSliderPanel>();
        bodyColorSliderPanel.setPositionDimensionsAndType(0.0f, 0.0f, 0.0f, 1.0f, 0.85f, "ColorSliderPanel");
        bodyColorSliderPanel.setBodyPartType("body");

        ColorSliderPanel hornColorSliderPanel = Instantiate(referenceColorSliderPanel.getGameObject(), hornTabbedWindow.getGameObject().transform).GetComponent<ColorSliderPanel>();
        hornColorSliderPanel.setPositionDimensionsAndType(0.0f, 0.0f, 0.0f, 1.0f, 0.85f, "ColorSliderPanel");
        hornColorSliderPanel.setBodyPartType("horn");






        eyesColorSliderPanel.deactivate();
        hornColorSliderPanel.deactivate();
        bodyColorSliderPanel.deactivate();













        // SHAPE TILE ITEMS LIST

        ShapeTileItemList referenceShapeTileItemList = GameObject.Find("ReferenceShapeTileItemList").GetComponent<ShapeTileItemList>();
        referenceShapeTileItemList.deactivate();


        ShapeTileItemList earsShapeTileItemList = Instantiate(referenceShapeTileItemList.getGameObject(), bodyTabbedWindow.getGameObject().transform).GetComponent<ShapeTileItemList>();
        earsShapeTileItemList.setPositionDimensionsAndType(0.0f, 0.0f, 0.0f, 1.0f, 0.85f, "ShapeTileItemList");
        //earsShapeTileItemList.setBodyPartType("eye");
        earsShapeTileItemList.setColor(new Color(1.0f, 1.0f, 1.0f, 0.7f));
        earsShapeTileItemList.initialize("ear");
        earsShapeTileItemList.deactivate();

        ShapeTileItemList tailShapeTileItemList = Instantiate(referenceShapeTileItemList.getGameObject(), bodyTabbedWindow.getGameObject().transform).GetComponent<ShapeTileItemList>();
        tailShapeTileItemList.setPositionDimensionsAndType(0.0f, 0.0f, 0.0f, 1.0f, 0.85f, "ShapeTileItemList");
        //tailShapeTileItemList.setBodyPartType("eye");
        tailShapeTileItemList.setColor(new Color(1.0f, 1.0f, 1.0f, 0.7f));
        tailShapeTileItemList.initialize("tail");
        tailShapeTileItemList.deactivate();
        
        ShapeTileItemList eyesShapeTileItemList = Instantiate(referenceShapeTileItemList.getGameObject(), eyesTabbedWindow.getGameObject().transform).GetComponent<ShapeTileItemList>();
        eyesShapeTileItemList.setPositionDimensionsAndType(0.0f, 0.0f, 0.0f, 1.0f, 0.85f, "ShapeTileItemList");
        //eyesShapeTileItemList.setBodyPartType("eye");
        eyesShapeTileItemList.setColor(new Color(1.0f, 1.0f, 1.0f, 0.7f));
        eyesShapeTileItemList.initialize("eye");
        eyesShapeTileItemList.deactivate();
        
        ShapeTileItemList hornShapeTileItemList = Instantiate(referenceShapeTileItemList.getGameObject(), hornTabbedWindow.getGameObject().transform).GetComponent<ShapeTileItemList>();
        hornShapeTileItemList.setPositionDimensionsAndType(0.0f, 0.0f, 0.0f, 1.0f, 0.85f, "ShapeTileItemList");
        //hornShapeTileItemList.setBodyPartType("eye");
        hornShapeTileItemList.setColor(new Color(1.0f, 1.0f, 1.0f, 0.7f));
        hornShapeTileItemList.initialize("horn");
        hornShapeTileItemList.deactivate();







        //
        // Set Content pointed to by each Tab
        //

        // Color tabs
        eyesColorTab.setContent(eyesColorSliderPanel);
        hornColorTab.setContent(hornColorSliderPanel);
        bodyColorTab.setContent(bodyColorSliderPanel);

        // Shape tabs
        earsShapeTab.setContent(earsShapeTileItemList);
        tailShapeTab.setContent(tailShapeTileItemList);
        eyesShapeTab.setContent(eyesShapeTileItemList);
        hornShapeTab.setContent(hornShapeTileItemList);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
