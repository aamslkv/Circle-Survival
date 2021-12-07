using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySkins : MonoBehaviour
{
    public ShopControl shop;
    public GameObject sure_panel;
    public int _buttonId = 0;

    private UI_SoundMainMenu soundEffector;

    [Header("Buy_slot_1")]
    public GameObject _check_1;
    public GameObject _close_1;
    public GameObject _cost_1;
    public int _value_1;
    public string _buy_1 = "no";

    [Header("Buy_slot_2")]
    public GameObject _check_2;
    public GameObject _close_2;
    public GameObject _cost_2;
    public int _value_2;
    public string _buy_2 = "no";

    [Header("buy_slot_3")]
    public GameObject _check_3;
    public GameObject _close_3;
    public GameObject _cost_3;
    public int _value_3;
    public string _buy_3 = "no";

    [Header("buy_slot_4")]
    public GameObject _check_4;
    public GameObject _close_4;
    public GameObject _cost_4;
    public int _value_4;
    public string _buy_4 = "no";

    [Header("buy_slot_5")]
    public GameObject _check_5;
    public GameObject _close_5;
    public GameObject _cost_5;
    public int _value_5;
    public string _buy_5 = "no";

    [Header("buy_slot_6")]
    public GameObject _check_6;
    public GameObject _close_6;
    public GameObject _cost_6;
    public int _value_6;
    public string _buy_6 = "no";



    void Start()
    {
         /*PlayerPrefs.DeleteKey("_Buy_1"); 
         PlayerPrefs.DeleteKey("_Buy_2");
         PlayerPrefs.DeleteKey("_Buy_3");
         PlayerPrefs.DeleteKey("_Buy_4"); 
         PlayerPrefs.DeleteKey("_Buy_5");
         PlayerPrefs.DeleteKey("_Buy_6");
         PlayerPrefs.DeleteKey("_SkinManager");*/

        soundEffector = FindObjectOfType<UI_SoundMainMenu>();

        _buy_1 = PlayerPrefs.GetString("_Buy_1", _buy_1);
        _buy_2 = PlayerPrefs.GetString("_Buy_2", _buy_2);
        _buy_3 = PlayerPrefs.GetString("_Buy_3", _buy_3);
        _buy_4 = PlayerPrefs.GetString("_Buy_4", _buy_4);
        _buy_5 = PlayerPrefs.GetString("_Buy_5", _buy_5);
        _buy_6 = PlayerPrefs.GetString("_Buy_6", _buy_6);

        if ((_buy_1 == "yes") && (_close_1 != null))
        {
            _close_1.SetActive(false);
            //_cost_1.SetActive(false);
}

        if ((_buy_2 == "yes") && (_close_2 != null))
        {
            _close_2.SetActive(false);
            _cost_2.SetActive(false);
        }

        if ((_buy_3 == "yes") && (_close_3 != null))
        {
            _close_3.SetActive(false);
            _cost_3.SetActive(false);
        }

        if ((_buy_4 == "yes") && (_close_4 != null))
        {
            _close_4.SetActive(false);
            _cost_4.SetActive(false);
        }

        if ((_buy_5 == "yes") && (_close_5 != null))
        {
            _close_5.SetActive(false);
            _cost_5.SetActive(false);
        }

        if ((_buy_6 == "yes") && (_close_6 != null))
        {
            _close_6.SetActive(false);
            _cost_6.SetActive(false);
        }
    }


    void Update()
    {
        if (PlayerPrefs.GetString("_SkinManager", StaticCoins._SkinManager) == "")
        {
            _check_1.SetActive(true);
            _check_2.SetActive(false);
            _check_3.SetActive(false);
            _check_4.SetActive(false);
            _check_5.SetActive(false);
            _check_6.SetActive(false);
        }
        else if (PlayerPrefs.GetString("_SkinManager", StaticCoins._SkinManager) == "default")
        {
            _check_1.SetActive(true);
            _check_2.SetActive(false);
            _check_3.SetActive(false);
            _check_4.SetActive(false);
            _check_5.SetActive(false);
            _check_6.SetActive(false);
        }
        else if (PlayerPrefs.GetString("_SkinManager", StaticCoins._SkinManager) == "swastika")
        {
            _check_1.SetActive(false);
            _check_2.SetActive(true);
            _check_3.SetActive(false);
            _check_4.SetActive(false);
            _check_5.SetActive(false);
            _check_6.SetActive(false);
        }
        else if (PlayerPrefs.GetString("_SkinManager", StaticCoins._SkinManager) == "chmo")
        {
            _check_1.SetActive(false);
            _check_2.SetActive(false);
            _check_3.SetActive(true);
            _check_4.SetActive(false);
            _check_5.SetActive(false);
            _check_6.SetActive(false);
        }
        else if (PlayerPrefs.GetString("_SkinManager", StaticCoins._SkinManager) == "neon")
        {
            _check_1.SetActive(false);
            _check_2.SetActive(false);
            _check_3.SetActive(false);
            _check_4.SetActive(true);
            _check_5.SetActive(false);
            _check_6.SetActive(false);
        }
        else if (PlayerPrefs.GetString("_SkinManager", StaticCoins._SkinManager) == "lolipop")
        {
            _check_1.SetActive(false);
            _check_2.SetActive(false);
            _check_3.SetActive(false);
            _check_4.SetActive(false);
            _check_5.SetActive(true);
            _check_6.SetActive(false);
        }
        else if (PlayerPrefs.GetString("_SkinManager", StaticCoins._SkinManager) == "arbuz")
        {
            _check_1.SetActive(false);
            _check_2.SetActive(false);
            _check_3.SetActive(false);
            _check_4.SetActive(false);
            _check_5.SetActive(false);
            _check_6.SetActive(true);
        }
    }

    public void Buy_slot_1()
    {
       /* if ((shop.coins >= _value_1) && (_buy_1 == "no"))
        {
            sure_panel.SetActive(true);
            _buttonId = 1;
        }

        if ((shop.coins <= _value_1) && (_buy_1 == "no"))
        {
            soundEffector.Play_errorSound();
        }

        if (_buy_1 == "yes")
        {
            soundEffector.Play_swichSound();
            StaticCoins._SkinManager = "default";
            PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);
        }*/

        soundEffector.Play_swichSound();
        StaticCoins._SkinManager = "default";
        PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);
    }

    /*public void Sure_buy_1()
    {
        shop.coins -= _value_1;
        StaticCoins._Coins = shop.coins;
        PlayerPrefs.SetInt("_Coins", StaticCoins._Coins);

        StaticCoins._SkinManager = "default";
        PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);

        _buy_1 = "yes";
        PlayerPrefs.SetString("_Buy_1", _buy_1);

        if (_close_1 != null)
        {
            _close_1.SetActive(false);
        }
    }*/

    public void Buy_slot_2()
    {
        if ((shop.coins >= _value_2) && (_buy_2 == "no"))
        {
            sure_panel.SetActive(true);
            _buttonId = 2;
        }

        if ((shop.coins < _value_2) && (_buy_2 == "no"))
        {
            soundEffector.Play_errorSound();
        }

        if (_buy_2 == "yes")
        {
            soundEffector.Play_swichSound();
            StaticCoins._SkinManager = "swastika";
            PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);  
        }
    }

    public void Sure_buy_2()
    {
        shop.coins -= _value_2;
        StaticCoins._Coins = shop.coins;
        PlayerPrefs.SetInt("_Coins", StaticCoins._Coins);

        StaticCoins._SkinManager = "swastika";
        PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);

        _buy_2 = "yes";
        PlayerPrefs.SetString("_Buy_2", _buy_2);

        if (_close_2 != null)
        {
            _close_2.SetActive(false);
            _cost_2.SetActive(false);
        }
    }

    public void Buy_slot_3()
    {
        if ((shop.coins >= _value_3) && (_buy_3 == "no"))
        {
            sure_panel.SetActive(true);
            _buttonId = 3;
        }

        if ((shop.coins < _value_3) && (_buy_3 == "no"))
        {
            soundEffector.Play_errorSound();
        }

        if (_buy_3 == "yes")
        {
            soundEffector.Play_swichSound();
            StaticCoins._SkinManager = "chmo";
            PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);
        }
    }

    public void Sure_buy_3()
    {
        shop.coins -= _value_3;
        StaticCoins._Coins = shop.coins;
        PlayerPrefs.SetInt("_Coins", StaticCoins._Coins);

        StaticCoins._SkinManager = "chmo";
        PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);

        _buy_3 = "yes";
        PlayerPrefs.SetString("_Buy_3", _buy_3);

        if (_close_3 != null)
        {
            _close_3.SetActive(false);
            _cost_3.SetActive(false);
        }
    }

    public void Buy_slot_4()
    {
        if ((shop.coins >= _value_4) && (_buy_4 == "no"))
        {
            sure_panel.SetActive(true);
            _buttonId = 4;
        }

        if ((shop.coins < _value_4) && (_buy_4 == "no"))
        {
            soundEffector.Play_errorSound();
        }

        if (_buy_4 == "yes")
        {
            soundEffector.Play_swichSound();
            StaticCoins._SkinManager = "neon";
            PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);
        }
    }

    public void Sure_buy_4()
    {
        shop.coins -= _value_4;
        StaticCoins._Coins = shop.coins;
        PlayerPrefs.SetInt("_Coins", StaticCoins._Coins);

        StaticCoins._SkinManager = "neon";
        PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);

        _buy_4 = "yes";
        PlayerPrefs.SetString("_Buy_4", _buy_4);

        if (_close_4 != null)
        {
            _close_4.SetActive(false);
            _cost_4.SetActive(false);
        }
    }

    public void Buy_slot_5()
    {
        if ((shop.coins >= _value_5) && (_buy_5 == "no"))
        {
            sure_panel.SetActive(true);
            _buttonId = 5;
        }

        if ((shop.coins < _value_5) && (_buy_5 == "no"))
        {
            soundEffector.Play_errorSound();
        }

        if (_buy_5 == "yes")
        {
            soundEffector.Play_swichSound();
            StaticCoins._SkinManager = "lolipop";
            PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);
        }
    }

    public void Sure_buy_5()
    {
        shop.coins -= _value_5;
        StaticCoins._Coins = shop.coins;
        PlayerPrefs.SetInt("_Coins", StaticCoins._Coins);

        StaticCoins._SkinManager = "lolipop";
        PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);

        _buy_5 = "yes";
        PlayerPrefs.SetString("_Buy_5", _buy_5);

        if (_close_5 != null)
        {
            _close_5.SetActive(false);
            _cost_5.SetActive(false);
        }
    }

    public void Buy_slot_6()
    {
        if ((shop.coins >= _value_6) && (_buy_6 == "no"))
        {
            sure_panel.SetActive(true);
            _buttonId = 6;
        }

        if ((shop.coins < _value_6) && (_buy_6 == "no"))
        {
            soundEffector.Play_errorSound();
        }

        if (_buy_6 == "yes")
        {
            soundEffector.Play_swichSound();
            StaticCoins._SkinManager = "arbuz";
            PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);
        }
    }

    public void Sure_buy_6()
    {
        shop.coins -= _value_6;
        StaticCoins._Coins = shop.coins;
        PlayerPrefs.SetInt("_Coins", StaticCoins._Coins);

        StaticCoins._SkinManager = "arbuz";
        PlayerPrefs.SetString("_SkinManager", StaticCoins._SkinManager);

        _buy_6 = "yes";
        PlayerPrefs.SetString("_Buy_6", _buy_6);

        if (_close_6 != null)
        {
            _close_6.SetActive(false);
            _cost_6.SetActive(false);
        }
    }

    public void YES()
    {
        if (_buttonId == 1)
        {
            //Sure_buy_1();
            //sure_panel.SetActive(false);
            return;
        }
        else if (_buttonId == 2)
        {
            Sure_buy_2();
            sure_panel.SetActive(false);
        }
        else if (_buttonId == 3)
        {
            Sure_buy_3();
            sure_panel.SetActive(false);
        }
        else if (_buttonId == 4)
        {
            Sure_buy_4();
            sure_panel.SetActive(false);
        }
        else if (_buttonId == 5)
        {
            Sure_buy_5();
            sure_panel.SetActive(false);
        }
        else if (_buttonId == 6)
        {
            Sure_buy_6();
            sure_panel.SetActive(false);
        }
    }

    public void NO()
    {
        _buttonId = 0;
        sure_panel.SetActive(false);
    }
}
