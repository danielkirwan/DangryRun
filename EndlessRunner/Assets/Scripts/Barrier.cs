using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public Collider collider;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            collider.enabled = !collider.enabled;
        }
    }

    private void OnEnable()
    {
        collider.enabled = collider.enabled;
    }
}
