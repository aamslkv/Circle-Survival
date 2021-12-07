using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopControl : MonoBehaviour
{
    public GameObject textValue;

    public int coins;


    void Start()
    {
        coins = PlayerPrefs.GetInt("_Coins", StaticCoins._Coins);
        
    }
    void Update()
    {
        textValue.GetComponent<Text>().text = coins.ToString();
    }

    public void DefaultSkin()
    {

            StaticCoins._SkinManager = "default";
            PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);
        
    }
    public void Sale_1()
    {
        if (coins >= 100)
        {
            coins -= 100;
            StaticCoins._Coins = coins;

            PlayerPrefs.SetInt("_Coins", StaticCoins._Coins);


            StaticCoins._SkinManager = "swastika";
            PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);
        }
    }

    public void Sale_2()
    {
        if (coins >= 50)
        {
            coins -= 50;
            StaticCoins._Coins = coins;

            PlayerPrefs.SetInt("_Coins", StaticCoins._Coins);


            StaticCoins._SkinManager = "chmo";
            PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);
        }
    }


}
