using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    string GooglePlayID = "3961981";
    string AppleID = "3961980";

    bool TestMode = true;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(GooglePlayID, TestMode);
    }

    void DisplayAd()
    {
        Advertisement.Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
