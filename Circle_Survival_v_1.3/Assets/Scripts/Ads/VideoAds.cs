using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class VideoAds : MonoBehaviour
{
    public void Awake()
    {

        if (Advertisement.isSupported)
            Advertisement.Initialize("4145159", false);
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}
