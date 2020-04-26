using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class ItemsInfo : MonoBehaviour
{

    public GameObject ItemContainer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    void Load(GameObject rootObject, string fileName)
    {

        XmlSerializer serializer = new XmlSerializer(typeof(LevelInfo));
        TextReader reader = new StreamReader(fileName);
        LevelInfo levelInfo = serializer.Deserialize(reader) as LevelInfo;
        levelInfo.reload(rootObject);
        reader.Close();
        print("Objects loaded from XML file\n");
    }
    private void OnGUI()
    {
        if(GUI.Button(new Rect(30,60,150,30),"Save State"))
        {
            Save(ItemContainer, "savefile.xml");
        }
        if (GUI.Button(new Rect(30, 90, 150, 30), "Load State"))
        {
            Load(ItemContainer, "savefile.xml");
        }
    }


}
