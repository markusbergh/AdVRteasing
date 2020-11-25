using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLettersFall : MonoBehaviour
{
    private bool hasFallen = false;
    private bool isLooking = false;

    private float duration = 1.0f;
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = duration;

        // Turn off all bodies for gravity
        foreach (Transform child in transform)
            child.GetComponent<Rigidbody>().useGravity = false;
    }

    void MakeThemFall() {
        if (gameObject.GetComponent<LookAtPlayer>() != null) {
            // Shouldn't really follow player anymore
            gameObject.GetComponent<LookAtPlayer>().willLookAtPlayer = false;
        }

        // Turn on all bodies for gravity
        foreach (Transform child in transform)
            child.GetComponent<Rigidbody>().useGravity = true;
    }

    void Update()
    {
        if (isLooking && !hasFallen) {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0) {
                hasFallen = true;

                MakeThemFall();
            }
        }
    }

    public void OnEnter()
    {
        if (!hasFallen)
        {
            isLooking = true;
        }
    }

    public void OnExit()
    {
        if (!hasFallen)
        {
            isLooking = false;

            // Reset time
            timeLeft = duration;
        }
    }
}
