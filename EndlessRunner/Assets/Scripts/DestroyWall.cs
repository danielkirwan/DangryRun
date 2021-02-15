using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public GameObject[] bricks;
    List<Rigidbody> bricksRb = new List<Rigidbody>();
    List<Vector3> brickPos = new List<Vector3>();
    List<Quaternion> brickRotations = new List<Quaternion>();
    Collider col;
    public GameObject explosion;


    private void Awake()
    {
        col = this.GetComponent<Collider>();
        foreach(GameObject b in bricks)
        {
            bricksRb.Add(b.GetComponent<Rigidbody>());
            brickPos.Add(b.transform.localPosition);
            brickRotations.Add(b.transform.localRotation);
        }
    }
    //Resets the position and rotation of the bricks to the original values as stored in AWAKE
    private void OnEnable()
    {
        col.enabled = true;
        for(int i=0;i < bricks.Length; i++)
        {
            bricks[i].transform.localPosition = brickPos[i];
            bricks[i].transform.localRotation = brickRotations[i];
            bricksRb[i].isKinematic = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Spell")
        {
            GameObject expolsionObj = Instantiate(explosion, collision.contacts[0].point, Quaternion.identity);
           
            Destroy(expolsionObj, 2.5f);
            col.enabled = false;

            foreach(Rigidbody r in bricksRb)
            {
                r.isKinematic = false;
            }
            PlayerController.sfx[5].Play();
        }
    }

}
