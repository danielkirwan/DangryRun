using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{

    string googlePLayId = "3961981";
    string appleId = "3961980";
    string placementID = "Banner";
    //bool testMode = true;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Advertisement.Initialize(appleId);
            StartCoroutine(ShowBannerWhenReady());
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            Advertisement.Initialize(googlePLayId);
            StartCoroutine(ShowBannerWhenReady());
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            Advertisement.Initialize(googlePLayId);
            StartCoroutine(ShowBannerWhenReady());
        }
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementID))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(placementID);
        
    }

}
