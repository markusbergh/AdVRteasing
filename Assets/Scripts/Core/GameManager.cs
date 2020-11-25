using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string sceneName = "Demo";

    private GameObject[] gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        AddWhiteMaterialToAdvertisingObjects();
    }

    void Update()
    {
        if (Input.GetTouch(0).tapCount == 2)
        {
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(sceneName);
    }

    void AddWhiteMaterialToAdvertisingObjects()
    {
        Material whiteMaterial = Resources.Load("Material/White", typeof(Material)) as Material;

        gameObjects = GameObject.FindGameObjectsWithTag("AdvertisingSpace");

        foreach (GameObject advertisingGameObject in gameObjects)
        {
            MeshRenderer[] meshRenderers = advertisingGameObject.GetComponentsInChildren<MeshRenderer>();

            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                meshRenderer.material = whiteMaterial;
            }
        }
    }
}
