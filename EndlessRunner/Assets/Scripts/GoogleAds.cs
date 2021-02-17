using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class GoogleAds : MonoBehaviour
{

    string app_ID = "ca-app-pub-1169852078227629~9040099077";
    string googleAdsAndriodIDLive = "ca-app-pub-1169852078227629/2245807626";
    //string bannderAdTest = "ca-app-pub-3940256099942544/6300978111";
    //public Text text;
    //adding comment

    private BannerView bannerView;

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(app_ID);
        this.RequestBanner();
    }

    private void RequestBanner()
    {
        
        if(Application.platform == RuntimePlatform.Android)
        {
            // Create a 320x50 banner at the bottom of the screen.
            this.bannerView = new BannerView(googleAdsAndriodIDLive, AdSize.Banner, AdPosition.Bottom);

            // Called when an ad request has successfully loaded.
            this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            this.bannerView.OnAdOpening += this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            this.bannerView.OnAdClosed += this.HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;

            Invoke("ShowBannerAd", 2);
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            // Create a 320x50 banner at the top of the screen.
            this.bannerView = new BannerView(googleAdsAndriodIDLive, AdSize.Banner, AdPosition.Bottom);

            // Called when an ad request has successfully loaded.
            this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            this.bannerView.OnAdOpening += this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            this.bannerView.OnAdClosed += this.HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;

            Invoke("ShowBannerAd", 2);
        }
    }

    private void ShowBannerAd()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);

        this.bannerView.Show();
    }




    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
       // text.text = "Ad loaded";
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //text.text = "Ad failed to load loaded";
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
