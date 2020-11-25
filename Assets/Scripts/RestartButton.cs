using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public string sceneName = "Demo";

    private GameObject cameraRig;

    void Start()
    {
        cameraRig = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnRestartTriggerEnter()
    {
        cameraRig.GetComponent<PlayerTouch>().shouldMove = false;
    }

    public void OnRestartTriggerExit()
    {
        cameraRig.GetComponent<PlayerTouch>().shouldMove = true;
    }
}
