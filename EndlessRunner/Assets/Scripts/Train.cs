using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public float gameScrollSpeed = 0.15f;
    public GameObject explosionPrefab; 
    private void FixedUpdate()
    {
        if (PlayerController.isDead) return;
        this.transform.position += PlayerController.player.transform.forward * -gameScrollSpeed;      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Barrier")
        {
            Destroy(this.gameObject);
            GameObject explosion = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            Destroy(explosion, 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Crate")
        {
            Destroy(this.gameObject);
            GameObject explosion = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            Destroy(explosion, 1);

        }
    }
}
