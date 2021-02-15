using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float gameScrollSpeed = 0.1f;
    private void FixedUpdate()
    {
        if (PlayerController.isDead) return;
        this.transform.position += PlayerController.player.transform.forward * -gameScrollSpeed;
        if (PlayerController.currentPlatform == null) return;
        //to avoid possible issues with the y float being too large to store if the player is playing for a long time
        if(PlayerController.currentPlatform.tag == "stairsUp")
        {
            this.transform.Translate(0, -0.06f, 0);
        }
        if (PlayerController.currentPlatform.tag == "stairsDown")
        {
            this.transform.Translate(0, 0.06f, 0);
        }
    }
}
