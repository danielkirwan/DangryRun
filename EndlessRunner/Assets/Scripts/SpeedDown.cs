using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : MonoBehaviour
{

    private Animator rotationSpeed;
    public MeshRenderer mesh;
    private float minGameSpeed = 1f;
    private float currentGameSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = GetComponent<Animator>();
        rotationSpeed.speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale >= 1.5f && Time.timeScale <= 1.9f)
        {
            rotationSpeed.speed = 0.5f;
        }
        else if (Time.timeScale >= 2f && Time.timeScale <= 2.4f)
        {
            rotationSpeed.speed = 0.3f;
        }
        else if (Time.timeScale >= 2.5f && Time.timeScale <= 3f)
        {
            rotationSpeed.speed = 0.2f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Time.timeScale > minGameSpeed)
            {
                PlayerController.sfx[9].Play();
                Time.timeScale -= 0.2f;
                mesh.enabled = false;
                PlayerPrefs.SetFloat("GameSpeed", currentGameSpeed);
            }
        }else if(other.gameObject.tag == "Barrier" || other.gameObject.tag == "Crate")
        {
            Destroy(this.gameObject);
        }else if(other.gameObject.tag == "SpeedUp")
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SpeedUp")
        {
            Destroy(this.gameObject);
        }
    }


    private void OnEnable()
    {
        if (mesh != null)
        {
            mesh.enabled = true;
        }
    }
}
