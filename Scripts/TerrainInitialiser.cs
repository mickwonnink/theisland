using UnityEngine;
using System.Collections;

public class TerrainInitialiser : MonoBehaviour {

    Color myOriginColor = new Color();

	// Use this for initialization
	void Start () {
        myOriginColor = gameObject.GetComponent<Renderer>().material.color;
	}

    public void OnCollisionExit(Collision col)
    {
        gameObject.GetComponent<Renderer>().material.color = myOriginColor;
    }

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log("ONCOLLISIONENTER");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
