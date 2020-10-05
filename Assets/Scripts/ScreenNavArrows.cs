using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenNavArrows : MonoBehaviour {

    public GameObject box;
    public GameObject boxArray;
    public GameObject levelText;
    public int maxLevel = 3;
    private int currLevel = 0;
    private Vector3 targetPos;
    private float boxWidth;
    public float speed = 1.0f;

    // Use this for initialization
    void Start () {
        boxWidth = box.GetComponent<BoxCollider2D>().size.x;
        targetPos = new Vector3(-99f, -99f, -99f);
        levelText.GetComponent<Text>().text = currLevel.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        float step = speed * Time.deltaTime; // calculate distance to move
        if(targetPos.x != -99)
        {
          //  Debug.Log("This shouldn't run until a button is pushed.'");
            boxArray.transform.position = Vector3.MoveTowards(boxArray.transform.position, targetPos, step);
        }
       



    }


    public void moveLeft()
    {
        // Debug.Log("Left");
        if (currLevel > 0)
        {
            currLevel--;
            levelText.GetComponent<Text>().text = currLevel.ToString();
            targetPos = new Vector3(boxArray.transform.position.x + boxWidth, boxArray.transform.position.y, boxArray.transform.position.z);
        }
        
    }


    public void moveRight()
    {
        // Debug.Log("Right");
        if (currLevel < maxLevel - 1)
        {
            currLevel++;
            levelText.GetComponent<Text>().text = currLevel.ToString();
            targetPos = new Vector3(boxArray.transform.position.x - boxWidth, boxArray.transform.position.y, boxArray.transform.position.z);
        }
    }

    public void owoPress()
    {
        string sceneName = "puzzle" + currLevel;
        SceneManager.LoadScene(sceneName);
    }


}
