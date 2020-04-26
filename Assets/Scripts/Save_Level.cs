using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save_Level : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUI.Button(new Rect(30, 60, 150, 30), "Save Level"))
        {

            ItemsInfo.instance.SaveFile();
        }
    }

}