using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    bool deactivating = false;

    private void OnCollisionExit(Collision collision)
    {
        if (PlayerController.isDead) return;
        if(collision.gameObject.tag == "Player" && !deactivating)
        {
            Invoke("SetInactive", 4.0f);
            deactivating = true;
        }
    }

    void SetInactive()
    {
        this.gameObject.SetActive(false);
        deactivating = false;
    }
}
