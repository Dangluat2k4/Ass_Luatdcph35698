using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingGame : MonoBehaviour
{
    public GameObject higntCoin;
    public void hightCoin()
    {
        Debug.Log(" setting");
        higntCoin.SetActive(true);
        Time.timeScale = 0;
    }
    public void Exit()
    {
        Debug.Log("Exit");
        higntCoin.SetActive(false);
        Time.timeScale = 1;
    }
    public void PlayerAgain()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
 