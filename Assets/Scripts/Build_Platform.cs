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
    private float distance = 10f;
    public bool canBuild_steelBeam = false;
    [HideInInspector] public int selectBuildingMaterial_index;

    // Start is called before the first frame update
    void Start()
    {

        instance = this;
        Level = GameObject.Find("Level Design");

    }

    // Update is called once per frame
    void Update()
    {
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
                spawnBeam = Instantiate(materials[selectBuildingMaterial_index], materials[selectBuildingMaterial_index].transform.position, materials[selectBuildingMaterial_index].transform.rotation);
                spawnBeam.transform.SetParent(Level.transform);
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(UI_buttons[selectBuildingMaterial_index]);

            
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 100f);
            if (hit.collider != null)
            {
                //Destroy(hit.collider);
                Destroy(this.gameObject);
            }
        }

    }
} 
