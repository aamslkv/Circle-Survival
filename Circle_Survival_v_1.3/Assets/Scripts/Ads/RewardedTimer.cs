using System;
using UnityEngine.UI;
using UnityEngine;

public class RewardedTimer : MonoBehaviour
{
    public float msToWait;
    public Text Timer;
    public GameObject panel;
    private Button RewardButton;

    public GameObject AdManager;
    public RewardAds rewardAds;

    private ulong lastOpen;

    void Awake()
    {
        rewardAds = AdManager.GetComponent<RewardAds>();

        //PlayerPrefs.DeleteKey("lastOpen");

        if (!PlayerPrefs.HasKey("lastOpen"))
        {    
            PlayerPrefs.SetString("lastOpen", lastOpen.ToString());
        }
    }

    void Start()
    {
        RewardButton = GetComponent<Button>();
        lastOpen = ulong.Parse(PlayerPrefs.GetString("lastOpen"));
        //Timer = GetComponentInChildren<Text>();

        if (!isReady())
        {
            RewardButton.interactable = false;
            panel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!RewardButton.IsInteractable())
        {
            if (isReady())
            {
                RewardButton.interactable = true;
                panel.SetActive(false);
                Timer.text = "watch ad";
                return;
            }
            ulong diff = ((ulong)DateTime.Now.Ticks - lastOpen);
            ulong m = diff / TimeSpan.TicksPerMillisecond;
            float seconleft = (float)(msToWait - m) / 1000.0f;

            string t = "";

            t += ((int)seconleft / 3600).ToString() + " : ";
            seconleft -= ((int)seconleft / 3600) * 3600;
            t += ((int)seconleft / 60).ToString("00") + " : ";
            t += ((int)seconleft % 60).ToString("00") + "";

            Timer.text = t;
        }
    }

    public void Click()
    {
        
        rewardAds.ShowRewardedAd();
        print(PlayerPrefs.GetInt("RewTimer") % 3);
        if ((PlayerPrefs.GetInt("RewTimer") % 3) == 2)
        {
            lastOpen = (ulong)DateTime.Now.Ticks;
            PlayerPrefs.SetString("lastOpen", lastOpen.ToString());
            RewardButton.interactable = false;
            panel.SetActive(true);
        }
    }

    private bool isReady()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastOpen);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float seconleft = (float)(msToWait - m) / 1000.0f;

        if (seconleft < 0)
        {
            Timer.text = "watch ad";
            return true;
        }
        return false;
    }
}
