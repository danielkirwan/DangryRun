using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    static public GameObject dummyTraveller;
    static public GameObject lastPlatform;

    public static List<GameObject> interactables;

    //public GameObject barrierPrefab;
    //public GameObject cratePrefab;
    //public GameObject heartrPrefab;
    //public GameObject speedDownPrefab;
    //public GameObject speedUpPrefab;
    //public GameObject trainrPrefab;
    //public GameObject wallPrefab;


    public GameObject[] prefabs;
    private static int numberOfHeartsSpawned; 
    private static int maxHeartsToSpawn = 1;
    private static int numberOfLives;

    private void Awake()
    {
        dummyTraveller = new GameObject("dummy");
        interactables = new List<GameObject>();

        foreach(GameObject obj in prefabs)
        {
            obj.SetActive(false);
            interactables.Add(obj);
        }
    }

    private void Update()
    {
        
        numberOfLives = PlayerPrefs.GetInt("lives");
    }
    private void FixedUpdate()
    {
        numberOfHeartsSpawned = GameObject.FindGameObjectsWithTag("Heart").Length;
        if(numberOfHeartsSpawned > 1)
        {
            GameObject[] hearts;
            hearts = GameObject.FindGameObjectsWithTag("Heart");

            //foreach (GameObject heartObj in hearts)
            //{
            //    heartObj.SetActive(false);
            //    Destroy(heartObj);
            //}

            for(int i =1; i < numberOfHeartsSpawned; i++)
            {
                hearts[i].SetActive(false);
                Destroy(hearts[i]);
            }

        }
    }

    public static void RunDummy()
    {
        GameObject p = Pool.singleton.GetRandom();
        if (p == null) return;

        if(lastPlatform != null)
        {
            if(lastPlatform.gameObject.tag == "platformTSection")
            {
                dummyTraveller.transform.position = lastPlatform.transform.position + PlayerController.player.transform.forward * 20f;
            }
            else
            {
                //move dummy 10f forward form the last platform that was placed down
                dummyTraveller.transform.position = lastPlatform.transform.position + PlayerController.player.transform.forward * 10f;
                
            }

      
            if (lastPlatform.tag == "stairsUp")
            {
                dummyTraveller.transform.Translate(0, 5, 0);
            }
        }

        lastPlatform = p;

        p.SetActive(true);
        p.transform.position = dummyTraveller.transform.position;
        p.transform.rotation = dummyTraveller.transform.rotation;

       
        SpawnObject(p);


        if (p.tag == "stairsDown")
        {
            dummyTraveller.transform.Translate(0, -5, 0);
            p.transform.Rotate(0, 180, 0);
            p.transform.position = dummyTraveller.transform.position;
        }
    }


    public static void SpawnObject(GameObject platform)
    {
        int length = interactables.Count;
        int randomNumber = Random.Range(0, length);

        GameObject obj = Instantiate(interactables[randomNumber], platform.transform.position, platform.transform.rotation);
        obj.SetActive(true);

        Transform newParent = platform.GetComponent<Transform>();
        obj.transform.SetParent(newParent);
        //Gets random x pos between -1 and 1, this will position the objects on one of the tracks
        int randomX = Random.Range(-1, 2);


        //get number of SpeedUps in scene
        int speedUpCount = GameObject.FindGameObjectsWithTag("SpeedUp").Length;
        //get number of speedDowns in scene
        int speedDownCount = GameObject.FindGameObjectsWithTag("SpeedDown").Length;
        //get number of bronzeRows
        int bronzeRowCount = GameObject.FindGameObjectsWithTag("BronzeRow").Length;
        //get number of silverRows
        int SilverRowCount = GameObject.FindGameObjectsWithTag("SilverRow").Length;
        //get number of goldRows
        int GoldRowCount = GameObject.FindGameObjectsWithTag("GoldRow").Length;

        #region Hearts     
        if (obj.gameObject.tag == "Heart" && numberOfLives < 3)
        {
                obj.transform.position = new Vector3(randomX, 0.5f, obj.transform.position.z);
        }
        else if (obj.gameObject.tag == "Heart" && numberOfLives == 3)
        {
            obj.SetActive(false);
            GameObject[] hearts;
            hearts = GameObject.FindGameObjectsWithTag("Heart");

            foreach (GameObject heartObj in hearts)
            {
                heartObj.SetActive(false);
                Destroy(heartObj);
            }
        }
        #endregion

        #region Speed
        if (obj.gameObject.tag == "SpeedUp")
        {
            if (speedUpCount <= 2)
            {
                obj.transform.position = new Vector3(randomX, obj.transform.position.y, obj.transform.position.z);
            }
            else
            {
                obj.SetActive(false);
                Destroy(obj);
            }
        }else if (obj.gameObject.tag == "SpeedDown")
        {
            if (speedDownCount <= 2)
            {
                obj.transform.position = new Vector3(randomX, obj.transform.position.y, obj.transform.position.z);
            }
            else
            {
                obj.SetActive(false);
                Destroy(obj);
            }
        }
        #endregion

        #region Coins
        if (obj.gameObject.tag == "BronzeRow")
        {
            if(bronzeRowCount <= 4)
            {
                obj.transform.position = new Vector3(randomX, obj.transform.position.y, obj.transform.position.z - 7.5f);
            }
            else
            {
                obj.SetActive(false);
                Destroy(obj);
            }
        }else if (obj.gameObject.tag == "SilverRow")
        {
            if (SilverRowCount <= 4)
            {
                obj.transform.position = new Vector3(randomX, obj.transform.position.y, obj.transform.position.z - 7.5f);
            }
            else
            {
                obj.SetActive(false);
                Destroy(obj);
            }
        }else if (obj.gameObject.tag == "GoldRow")
        {
            if (GoldRowCount <= 2)
            {
                obj.transform.position = new Vector3(randomX, obj.transform.position.y, obj.transform.position.z - 7.5f);
            }
            else
            {
                obj.SetActive(false);
                Destroy(obj);
            }
        }
        #endregion

        if (obj.gameObject.tag == "Crate" || obj.gameObject.tag == "Barrier" || obj.gameObject.tag == "Train")
        {
            obj.transform.position = new Vector3(randomX, obj.transform.position.y, obj.transform.position.z);
        }
    }


}
