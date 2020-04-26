using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prefab_Managers : MonoBehaviour
{
    public static Prefab_Managers instance;
    public GameObject prefab;
    public string id = System.Guid.NewGuid().ToString();
    public List<Transform> prefabInstances = new List<Transform>();

    private void Start()
    {
        instance = this;
        GameObject.Find("Start").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(StartGame);
    }
    public void StartGame()
    {
        ES3.Save<int>(id + "count", prefabInstances.Count);
        ES3.Save<List<Transform>>(id,prefabInstances);
        SceneManager.LoadScene("Main Game");

    }
    public void LoadGame()
    {
        int count = ES3.Load<int>(id + "count", 0);
        if (count > 0)
        {
            // For each prefab we want to load, instantiate a prefab.
            for (int i = 0; i < count; i++)
                InstantiatePrefab();
            // Load our List of Transforms into our prefab array.
            ES3.LoadInto<List<Transform>>(id, prefabInstances);
        }
    }
    public GameObject InstantiatePrefab()
    {
        var go = Instantiate(prefab);
        prefabInstances.Add(go.transform);
        return go;
    }

    public void instantiateBeams()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y,10f));

        if (Input.GetMouseButtonUp(0))
        {
            //Instantiate(prefab,prefab.transform.position,prefab.transform.rotation);
            var go = InstantiatePrefab();
            go.transform.position = targetPosition;
            go.transform.rotation = prefab.transform.rotation;

            //UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(UI_buttons[selectBuildingMaterial_index]);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(this.prefab, 0f);
            //UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(UI_buttons[selectBuildingMaterial_index]);
        }


    }
}
