using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    [HideInInspector]public GameObject Player,startPos;
    private GameObject spawner;
    public void spawnBeams()
    {
        int index = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        if(index==2)
        {
            GameObject Button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            Button.GetComponent<Button>().interactable = false;


        }
        else if(index==3)
        {
            GameObject Button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            Button.GetComponent<Button>().interactable = false;
        }
        Build_Platform.instance.selectBuildingMaterial_index = index;
        Build_Platform.instance.canBuild_steelBeam = true;
    }
    public void startGame()
    {
        GameObject.Find("UI Materials").SetActive(false);
        startPos = GameObject.Find("startPosition(Clone)");
        Player = Resources.Load<GameObject>("Player");
        if (startPos != null)
            Instantiate(Player, startPos.transform.position, Quaternion.identity);
    }

    public void FinishSelection()
    {
        GameObject.Find("Spawner").GetComponent<Build_Platform>().enabled = false;
    }
}
