using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePhrase : MonoBehaviour
{
    // Reference to the Prefab.
    public GameObject phrasePrefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (5, 10, -40) and 180 degrees rotation.
        Quaternion zeroRotation = Quaternion.identity;
        Quaternion rotation = Quaternion.Euler(0f, 180f, 0f);

        Instantiate(phrasePrefab, new Vector3(5, 10, -40), rotation);
    }
}
