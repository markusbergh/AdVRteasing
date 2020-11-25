using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public float rotateSpeed = 20;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(Vector3.zero, Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
