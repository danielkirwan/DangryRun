using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject floatUpTextPrefab;
    GameObject canvas;
    private Animator rotationSpeed;

    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        rotationSpeed = GetComponent<Animator>();
        rotationSpeed.speed = 1f;
    }

    private void Update()
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
        if(other.gameObject.tag == "Player")
        {
            PlayerController.sfx[10].Play();
            GameObject scoreText = Instantiate(floatUpTextPrefab);
            scoreText.transform.SetParent(canvas.transform);
            //converts the screen point in 3D to 2D for the UI
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
            Vector3 moveText = new Vector3(0, 0, -10);
            scoreText.transform.position = screenPoint + moveText;
        }

        if (other.gameObject.tag == "Barrier" || other.gameObject.tag == "Crate")
        {
            Destroy(this.gameObject);
        }
    }

}
