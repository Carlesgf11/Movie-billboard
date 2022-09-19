using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum AppLenguage { SPANISH, ENGLISH, MAX_LENGUAGES }

public class GameManager : MonoBehaviour
{
    public Movie movie;
    public Actor currenActor;

    AppLenguage appLenguage;
    public int Lenguaje { get { return (int)appLenguage; } }
    //Patron singleton
    static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject go = new GameObject("Game manager");
                instance = go.AddComponent<GameManager>();
                instance.SetAppLenguage(PlayerPrefs.GetInt(Constants.LENGUAGE_KEY));
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    public void SetAppLenguage(int lenguage)
    {
        appLenguage = (AppLenguage)lenguage;
        PlayerPrefs.SetInt(Constants.LENGUAGE_KEY, lenguage);
    }

    public void ChangeScene(int indexBuild)
    {
        SceneManager.LoadScene(indexBuild);
    }
}
