using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    
    private int steelBeam_h_index = 0;
    private int steelBeam_v_index = 1;
    private int startPosition_index = 2;
    private int endPositon_index = 3;
    //private int steelBeam_h_index = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnBeams()
    {
        int index = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        Build_Platform.instance.selectBuildingMaterial_index = index;
        Build_Platform.instance.canBuild_steelBeam = true;
      
    }
}
