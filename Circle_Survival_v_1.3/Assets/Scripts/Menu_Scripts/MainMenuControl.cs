using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControl : MonoBehaviour
{
    public GameObject _ShopPanel;
    public GameObject _SettingPanel;
    public GameObject _GameName;
    public GameObject _MenuBttn;
    public GameObject _HigtScore;

    public Slider musicSlider, uiSlider, joystickSlider;
    public Text musicText, uiText, joystickText;

    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetInt("MusicVolume", 1);
        }

        if (!PlayerPrefs.HasKey("UIVolume"))
        {
            PlayerPrefs.SetInt("UIVolume", 1);
        }

        if (!PlayerPrefs.HasKey("JoystickValue"))
        {
            PlayerPrefs.SetInt("JoystickValue", 1);
        }

        musicSlider.value = PlayerPrefs.GetInt("MusicVolume");
        uiSlider.value = PlayerPrefs.GetInt("UIVolume");
        joystickSlider.value = PlayerPrefs.GetInt("JoystickValue");
    }

    void Update()
    {
        PlayerPrefs.SetInt("MusicVolume", (int)musicSlider.value);
        PlayerPrefs.SetInt("UIVolume", (int)uiSlider.value);
        PlayerPrefs.SetInt("JoystickValue", (int)joystickSlider.value);

        musicText.text = musicSlider.value.ToString();
        uiText.text = uiSlider.value.ToString();

        if (joystickSlider.value == 0)
            joystickText.text = "small";
        else if (joystickSlider.value == 1)
            joystickText.text = "middle";
        else if (joystickSlider.value == 2)
            joystickText.text = "large";
    }

    public void Play_Button()
    {
        SceneManager.LoadScene(2);
    }

    public void Setting_Button()
    {
        _SettingPanel.SetActive(true);
        _GameName.SetActive(false);
        _MenuBttn.SetActive(false);
        _HigtScore.SetActive(false);
    }
    public void Back_from_setting()
    {
        _SettingPanel.SetActive(false);
        _GameName.SetActive(true);
        _MenuBttn.SetActive(true);
        _HigtScore.SetActive(true);
    }

    public void Shop_Button()
    {
        _ShopPanel.SetActive(true);
        _GameName.SetActive(false);
        _MenuBttn.SetActive(false);
        _HigtScore.SetActive(false);
    }

    public void Back_from_store()
    {
        _ShopPanel.SetActive(false);
        _GameName.SetActive(true);
        _MenuBttn.SetActive(true);
        _HigtScore.SetActive(true);
    }
}
