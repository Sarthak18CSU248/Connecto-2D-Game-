using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.UI;

public class ItemsInfo : MonoBehaviour
{

    public GameObject ItemContainer;
    [HideInInspector]public GameObject file_Name;
    public static ItemsInfo instance;

    private void Awake()
    { 
        instance =this;
        file_Name = GameObject.Find("fileName");
    }

    public class Items
    {
        public string prefabName;
        public Vector3 position;

        public Items() { }
        public Items(Transform item)
        {
            prefabName = item.name.Replace("(Clone)", string.Empty);
            position = item.position;
        }

    }

    public class LevelInfo
    {//Stores info about all the cubes

        public List<Items> itemList;
        public LevelInfo()
        {

        }
        public LevelInfo(GameObject rootObject)
        {
            itemList = new List<Items>();
            foreach(Transform child in rootObject.transform)
            {
                itemList.Add(new Items(child));
            }
        }
        public void reload(GameObject rootObject)
        {
            foreach(var items_load in itemList)
            {
                GameObject prefab = Resources.Load<GameObject>(items_load.prefabName);
                GameObject item = Instantiate(prefab,items_load.position,Quaternion.identity) as GameObject;
            }
        }

    }

    void Save(GameObject rootObject,string fileName)
    {
        LevelInfo levelInfo = new LevelInfo(rootObject);
        XmlSerializer serializer = new XmlSerializer(typeof(LevelInfo));
        TextWriter writer = new StreamWriter(fileName);
        serializer.Serialize(writer, levelInfo);
        writer.Close();
        print("Objects saved into XML file\n");
        
    }

    public void Load(GameObject rootObject, string fileName)
    {

        XmlSerializer serializer = new XmlSerializer(typeof(LevelInfo));
        TextReader reader = new StreamReader(fileName);
        LevelInfo levelInfo = serializer.Deserialize(reader) as LevelInfo;
        levelInfo.reload(rootObject);
        reader.Close();
        print("Objects loaded from XML file\n");
    }
    public void SaveFile()
    {
        Save(ItemContainer,"Saved Files/"+file_Name.GetComponent<InputField>().text + ".xml");
    }
    /*private void OnGUI()
    {
        if (GUI.Button(new Rect(30, 60, 150, 30), "Save Level"))
        {
            Save(ItemContainer, file_Name.GetComponent<InputField>().text+".xml");
        }
        if (GUI.Button(new Rect(30, 90, 150, 30), "Load Level"))
        {
            Load(ItemContainer, file_Name.GetComponent<InputField>().text + ".xml");
        }
        
    }*/


}
