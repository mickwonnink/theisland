using UnityEngine;
using System.Collections;



public class gameHandler : MonoBehaviour {

    //Player struct
    struct PlayerInfo
    {
        int playerNumber;
        int amountGrain;
        int amountWood;
        int amountDiamond;
        int maxStorage;

    }

    //distance between island parts
    float horizontalDistance = 40;
    float verticleDistance = 35;

    //main camera
    GameObject mainViewCam = null;

    //settings
    float maxViewSize = 25;
    float minViewSize = 3;
    float yStartPos = 215;

    int amountOfPlayers = 4; //amount of player playing
    int currentPlayer = 1; //player number of player that needs to play his turn.

    //

	// Use this for initialization
	void Start () {

        mainViewCam = GameObject.Find("Camera");

        //island prefabs
        GameObject woodland = (GameObject)Resources.Load("woodLand") as GameObject;
        GameObject beachLand = (GameObject)Resources.Load("beachLand") as GameObject;

        int line1 = 3;
        int line2 = 9;
        int line3 = 19;
        int line4 = 27;

        //spawn island
        for (int i = 0; i < 8 * amountOfPlayers; i++)
        {
            GameObject islandPart = null;
            if (i == 0)
            {
                islandPart = (GameObject)Instantiate(beachLand, new Vector3(0, 1000, yStartPos), Quaternion.identity);
            }
            else
            {
                if (i < line1)
                {
                    islandPart = (GameObject)Instantiate(woodland, new Vector3(-(horizontalDistance * i), 1000, yStartPos), Quaternion.identity);
                }
                else if (i < line2)
                {
                    islandPart = (GameObject)Instantiate(woodland, new Vector3(-(horizontalDistance * 0.5f) - (horizontalDistance * i) + (line1 * horizontalDistance), 1000, yStartPos + verticleDistance), Quaternion.identity);
                }
                else if (i < line3)
                {
                    islandPart = (GameObject)Instantiate(woodland, new Vector3(-(horizontalDistance * i) + (line2 * horizontalDistance), 1000, yStartPos + (verticleDistance * 2)), Quaternion.identity);
                }
                else if (i < line4)
                {
                    islandPart = (GameObject)Instantiate(woodland, new Vector3(-(horizontalDistance * 1.5f) - (horizontalDistance * i) + (line3 * horizontalDistance), 1000, yStartPos + (verticleDistance * 3)), Quaternion.identity);
                }
                else
                {
                    islandPart = (GameObject)Instantiate(woodland, new Vector3(-(horizontalDistance) - (horizontalDistance * i) + (line4 * horizontalDistance), 1000, yStartPos + (verticleDistance * 4)), Quaternion.identity);
                }

            }
            islandPart.transform.localScale = islandPart.transform.localScale * 25;
        }

    }

    float zoomFactor = 0;
    Vector3 lastPos = new Vector3();
    float mouseSensetivity = 1;

	
	// Update is called once per frame
	void Update () {


        float d = Input.GetAxis("Mouse ScrollWheel");
        if (d != 0)
        {
            if (d > 0)
            {
                if (mainViewCam.GetComponent<Camera>().fieldOfView < maxViewSize)
                {
                    mainViewCam.GetComponent<Camera>().fieldOfView += d * 8;
                }
            }
            else
            {
                if (mainViewCam.GetComponent<Camera>().fieldOfView > minViewSize)
                {
                    mainViewCam.GetComponent<Camera>().fieldOfView += d * 8;
                }
            }
        }
        Vector3 deltamouse = new Vector3();
        if (Input.GetMouseButton(1))
        {
            if (lastPos.x == 0 && lastPos.y == 0)
            {
                lastPos = Input.mousePosition;
            }
            else
            {
                deltamouse = Input.mousePosition - lastPos;
            }
            deltamouse *= -Mathf.Lerp(0.05f, 0.5f, Mathf.InverseLerp(minViewSize, maxViewSize, mainViewCam.GetComponent<Camera>().fieldOfView));

            
            mainViewCam.transform.Translate(deltamouse.x * mouseSensetivity, deltamouse.y * mouseSensetivity, 0);

            lastPos = Input.mousePosition;
            //mainViewCam.transform.position -= deltamouse;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            lastPos = new Vector3();
        }

    }
}
