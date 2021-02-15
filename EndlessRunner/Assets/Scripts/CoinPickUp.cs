using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{

    MeshRenderer[] meshRenderers;
    public MeshRenderer myMesh;
    public GameObject floatUpTextPrefab;
    //public GameObject particlePrefab;
    private Animator rotationSpeed;
    GameObject canvas;

    private void Start()
    {
        meshRenderers = this.GetComponentsInChildren<MeshRenderer>();
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
            if(this.tag == "BronzeCoin")
            {
                GameData.singleton.UpdateScore(10);
            }else if (this.tag == "SilverCoin")
            {
                GameData.singleton.UpdateScore(20);
            }
            else if(this.tag == "GoldCoin")
            {
                GameData.singleton.UpdateScore(30);
            }

            PlayerController.sfx[1].Play();
            GameObject scoreText = Instantiate(floatUpTextPrefab);
            //scoreText.transform.parent = canvas.transform;
            scoreText.transform.SetParent(canvas.transform);
            //GameObject particleEffect = Instantiate(particlePrefab, this.transform.position, Quaternion.identity);
            //Destroy(particleEffect, 1);
            //converts the screen point in 3D to 2D for the UI
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
            Vector3 moveText = new Vector3(0, 0, -10);
            scoreText.transform.position = screenPoint + moveText;

            foreach(MeshRenderer mr in meshRenderers)
            {
                mr.enabled = false;
            }

            myMesh.enabled = false;
        }
    }

    private void OnEnable()
    {
        if(meshRenderers != null)
        {
            foreach (MeshRenderer mr in meshRenderers)
            {
                mr.enabled = true;
            }
        }

        if(myMesh != null)
        {
            myMesh.enabled = true;
        }

    }

}
