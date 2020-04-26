using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
public class Start_Game : MonoBehaviour
{
   [HideInInspector]public string[] fileName;
    public GameObject SavedFiles, Back, Start,UI;
    private GameObject MainMenu;
   public List<string> files;
   public Dropdown dropdown;
   private void Awake()
   {
        dropdown.ClearOptions();
        MainMenu = GameObject.Find("MainMenu");
        UI = GameObject.Find("UI");
   }
    public void Load()
   {
        DirectoryInfo file = new DirectoryInfo("Saved Files/");
        string[] info = Directory.GetFiles("Saved Files/");
        int count = info.Length;
        print(count);
        foreach (string i in info)
        {
            string File = Path.GetFileNameWithoutExtension(i);
            files.Add(File);
        }
        MainMenu.SetActive(false);
        SavedFiles.SetActive(true);
        PopulateDropdown(); 

   }
    public void Design()
    {
        SceneManager.LoadScene("Build Level");
    }
    void PopulateDropdown()
    {
        dropdown.AddOptions(files);
    }
    public void StartGame()
    {
        UI.SetActive(false);
        int index = dropdown.value;
        string file = dropdown.options[index].text;
        ItemsInfo.instance.Load(ItemsInfo.instance.ItemContainer, "Saved Files/" + file + ".xml");
        GameObject startPos = GameObject.Find("startPosition(Clone)");
        GameObject Player = Resources.Load<GameObject>("Player");
        Instantiate(Player, startPos.transform.position, Quaternion.identity);
    }
    public void Return()
    {
        SavedFiles.SetActive(false);
        MainMenu.SetActive(true);

    }
}
