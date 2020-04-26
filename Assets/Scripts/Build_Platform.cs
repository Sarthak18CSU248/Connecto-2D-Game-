using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_Platform : MonoBehaviour
{
    [SerializeField] private GameObject[] UI_buttons;
    public static Build_Platform instance;
    private GameObject Level;
    [SerializeField] private GameObject[] materials;
    [HideInInspector] public GameObject spawnBeam;
    private Vector3 mousePosition = Vector3.zero;
    private Vector3 targetPosition;
    //[SerializeField] private GameObject targetObject = null;
    private float distance = 10f;
    public bool canBuild_steelBeam = false;
    [HideInInspector] public int selectBuildingMaterial_index;
    public GameObject start, end;

    // Start is called before the first frame update
    void Start()
    {

        instance = this;
        Level = GameObject.Find("Level Design");

    }

    // Update is called once per frame
    void Update()
    {
        start = GameObject.FindGameObjectWithTag("start");
        end = GameObject.FindGameObjectWithTag("end");
        if (canBuild_steelBeam)
        {
            instantiateBeams();
            
        }

    }
    public void instantiateBeams()
    {
        mousePosition = Input.mousePosition;
        targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distance));
        materials[selectBuildingMaterial_index].transform.position = targetPosition;

        if (Input.GetMouseButtonUp(0))
        {
            if (start != null && end != null)
            {
                if (selectBuildingMaterial_index != 2 && selectBuildingMaterial_index != 3)
                {
                    spawnBeam = Instantiate(materials[selectBuildingMaterial_index], materials[selectBuildingMaterial_index].transform.position, materials[selectBuildingMaterial_index].transform.rotation);
                    //Prefab_Managers.instance.prefabInstances.Add(materials[selectBuildingMaterial_index].transform);
                    spawnBeam.transform.SetParent(Level.transform);
                    UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(UI_buttons[selectBuildingMaterial_index]);
                    
                }
                else
                {
                    Debug.Log("Already Exist");
                    UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(UI_buttons[selectBuildingMaterial_index]);
                }
            }
            else
            {
               spawnBeam = Instantiate(materials[selectBuildingMaterial_index], materials[selectBuildingMaterial_index].transform.position, materials[selectBuildingMaterial_index].transform.rotation);
               //Prefab_Managers.instance.prefabInstances.Add(materials[selectBuildingMaterial_index].transform);
               spawnBeam.transform.SetParent(Level.transform);
               UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(UI_buttons[selectBuildingMaterial_index]);
                
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(this.spawnBeam, 0f);
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(UI_buttons[selectBuildingMaterial_index]);
        }


    }

} 
