using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardAds : MonoBehaviour
{
    public ShopControl shop;
    private int coinsAdd;
    public int RewTimer;

    public GameObject RewPanel;
    public Text textCoin;

    public void Awake()
    {
        // PlayerPrefs.DeleteKey("RewTimer");

        if (!PlayerPrefs.HasKey("RewTimer"))
            PlayerPrefs.SetInt("RewTimer", 0);
        else
            RewTimer = PlayerPrefs.GetInt("RewTimer");



        if (Advertisement.isSupported)
            Advertisement.Initialize("4145159", false);
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");

                RandomCoins();
                shop.coins += coinsAdd;
                PlayerPrefs.SetInt("_Coins", shop.coins);

                RewTimer++;
                PlayerPrefs.SetInt("RewTimer", RewTimer);

                RewPanel.SetActive(true);

                textCoin.text = "crystals : " + coinsAdd.ToString();
                /*if (PlayerPrefs.GetInt("RewTimer") >= 3)
                {
                    PlayerPrefs.DeleteKey("RewTimer");
                }*/


                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    public void Back_to_Shop()
    {
        RewPanel.SetActive(false);
    }

    private void RandomCoins()
    {
        int rand = Random.Range(1, 100);

        if (rand <= 50)
        {
            coinsAdd = Random.Range(1, 5);
        }
        else if (rand > 50 && rand <= 85)
        {
            coinsAdd = Random.Range(6, 10);
        }
        else if (rand > 85)
        {
            coinsAdd = Random.Range(11, 15);
        }
    }
}
