using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public bool willLookAtPlayer = true;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (willLookAtPlayer)
        {
            transform.LookAt(target);
        }
    }
}
