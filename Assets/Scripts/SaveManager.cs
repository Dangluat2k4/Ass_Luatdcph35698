using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private const string SAVE_1 = "save_1";
    private const string SAVE_2 = "save_2";
    private const string SAVE_3 = "save_3";

    public void Awake()
    {
        if(SaveManager.instance == null)
            SaveManager.instance = this;
    }
    public void Start()
    {
        this.LoadSaveGame();
    }
    void OnApplicationQuit()
    {
        this.SaveGamme();
    }
    protected virtual string GetSaveGame()
    {
        return SaveManager.SAVE_1;
    }
    public virtual void LoadSaveGame()
    {
        string stringSave = PlayerPrefs.GetString(this.GetSaveGame());
        Debug.Log("Load save game "+ stringSave);
    }
    public virtual void SaveGamme()
    {
        Debug.Log("SaveGame");
        string stringSave = "aaaaaaaaaaaa";
        PlayerPrefs.SetString(this.GetSaveGame(), stringSave);  
    }
}
