using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Game : MonoBehaviour
{
    private int count = 1;
    public void StartGame()
    {
        DontDestroyOnLoad(GameObject.Find("Level Design"));
        SceneManager.LoadScene("Main Game");
        //ES3.Save<SceneManager>("Level", SceneManager.GetActiveScene().name);
        count++;
    }
    
}
