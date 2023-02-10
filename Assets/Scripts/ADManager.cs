using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class ADManager : MonoBehaviour
{
    public bool adsShownig;
    private BannerView bannerView;

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
    }

    public void RequestBanner()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";


        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);
    }
}
