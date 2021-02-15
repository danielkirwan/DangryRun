using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Barrier")
        {
            Destroy(this.gameObject);
        }else if(collision.gameObject.tag == "Crate")
        {
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "SpeedUp" || collision.gameObject.tag == "SpeedDown")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Crate")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "SpeedUp" || other.gameObject.tag == "SpeedDown")
        {
            Destroy(this.gameObject);
        }
    }



}
