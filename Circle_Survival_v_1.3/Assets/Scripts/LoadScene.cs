using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public Image LoadBar;
    public Text BarTxt;
    public int SceneID;
    void Start()
    {
        StartCoroutine(LoadSceneCor());
    }

    IEnumerator LoadSceneCor()
    {
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(SceneID);
        while (!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f;
            LoadBar.fillAmount = progress;
            BarTxt.text = "LOADING : " + string.Format("{0:0}%", progress * 100f);

            yield return 0;
        }
    }
}
