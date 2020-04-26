using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save_Level : MonoBehaviour
{
    [SerializeField] private GameObject[] materials;
    private int items;
    public string Coin_id;
    public string Platform_id;
    public List<Transform> platform = new List<Transform>();
    public List<Transform> wall = new List<Transform>();
    public List<Transform> coin = new List<Transform>();
    public void save_Level()
    {
        int count = 1;
        int items = GameObject.Find("Level Design").transform.childCount;
        GameObject level_Material = GameObject.Find("Level Design");
        for (int i=0;i<count;i++)
        {
            switch(level_Material.transform.GetChild(i).gameObject.transform.name)
            {
                case "Beam_H":
                    platform.Add(level_Material.transform.GetChild(i).gameObject.transform);
                    break;
                case "Wall":
                    wall.Add(level_Material.transform.GetChild(i).gameObject.transform);
                    break;
                case "Coin":
                    coin.Add(level_Material.transform.GetChild(i).gameObject.transform);
                    break;
            }
        }
    }

    public void Load_Level()
    {
        foreach(Transform t in platform)
        {
            Instantiate(materials[0]);
        }
    }
}