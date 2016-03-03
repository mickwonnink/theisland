using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScreenInitialiser : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(skipIntroScreen());
	}

    IEnumerator skipIntroScreen() {
        yield return new WaitForSeconds(0.5f);
        loadFirstGameScene();
    }

    void loadFirstGameScene()
    {
        SceneManager.LoadScene("main_start_screen");
    }

}
