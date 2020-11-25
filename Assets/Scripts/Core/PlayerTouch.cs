using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour
{
    public int playerSpeed;
    public bool shouldMove = true;

    private float maxDistance = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && shouldMove)
        {
            transform.position += Camera.main.transform.forward * (Time.deltaTime * playerSpeed);
        }
    }
}
