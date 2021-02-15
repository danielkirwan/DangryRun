using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRow : MonoBehaviour
{

    int leftPos = -1;
    int centerPos = 0;
    int rightPos = 1;
    int[] leftAndRightPos = new int[] { -1,1 };

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
        if(collision.gameObject.tag == "SilverRow")
        {
            if(this.transform.position.x == leftPos)
            {
                this.transform.position = new Vector3(centerPos, this.transform.position.y, this.transform.position.z);
            }else if(this.transform.position.x == centerPos)
            {
                int randomNumber = Random.Range(0, leftAndRightPos.Length);
                this.transform.position = new Vector3(randomNumber, this.transform.position.y, this.transform.position.z);
            }
            else if (this.transform.position.x == rightPos)
            {
                this.transform.position = new Vector3(centerPos, this.transform.position.y, this.transform.position.z);
            }
        }else if(collision.gameObject.tag == "GoldRow")
        {
            if (this.transform.position.x == leftPos)
            {
                this.transform.position = new Vector3(centerPos, this.transform.position.y, this.transform.position.z);
            }
            else if (this.transform.position.x == centerPos)
            {
                int randomNumber = Random.Range(0, leftAndRightPos.Length);
                this.transform.position = new Vector3(randomNumber, this.transform.position.y, this.transform.position.z);
            }
            else if(this.transform.position.x == rightPos)
            {
                this.transform.position = new Vector3(centerPos, this.transform.position.y, this.transform.position.z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SilverRow")
        {
            if (this.transform.position.x == leftPos)
            {
                this.transform.position = new Vector3(centerPos, this.transform.position.y, this.transform.position.z);
            }
            else if (this.transform.position.x == centerPos)
            {
                int randomNumber = Random.Range(0, leftAndRightPos.Length);
                this.transform.position = new Vector3(randomNumber, this.transform.position.y, this.transform.position.z);
            }
            else if (this.transform.position.x == rightPos)
            {
                this.transform.position = new Vector3(centerPos, this.transform.position.y, this.transform.position.z);
            }
        }
        else if (other.gameObject.tag == "GoldRow")
        {
            if (this.transform.position.x == leftPos)
            {
                this.transform.position = new Vector3(centerPos, this.transform.position.y, this.transform.position.z);
            }
            else if (this.transform.position.x == centerPos)
            {
                int randomNumber = Random.Range(0, leftAndRightPos.Length);
                this.transform.position = new Vector3(randomNumber, this.transform.position.y, this.transform.position.z);
            }
            else if (this.transform.position.x == rightPos)
            {
                this.transform.position = new Vector3(centerPos, this.transform.position.y, this.transform.position.z);
            }
        }
    }

}
