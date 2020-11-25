using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour
{
    public int playerSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        if (yAxis == 1.0f) {
            transform.position += Camera.main.transform.forward * (Time.deltaTime * playerSpeed);
        } else if (yAxis == -1.0f) {
            transform.position -= Camera.main.transform.forward * (Time.deltaTime * playerSpeed);
        }

    }
}
