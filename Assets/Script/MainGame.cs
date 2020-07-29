using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainGame : MonoBehaviour
{
    public GameObject PlayerObject;
    public Camera mainCamera;
    public GameObject Bridge;
    public GameObject FinalUI;
    private GameObject role;
    
    
    // Start is called before the first frame update
    void Start()
    {
        role = RoleManager.Instance.CreateSelectedRole(PlayerObject.transform);
        role.tag = "Role";
        RoleController controller = role.AddComponent<RoleController>();
        controller.agent = role.AddComponent<NavMeshAgent>();
        controller.animator = role.GetComponent<Animator>();
        controller.mainCamera = mainCamera;
        controller.Init();
        Bridge.SetActive(false);
        FinalUI.SetActive(false);
    }

    public void OnTrickActive()
    {
        Bridge.SetActive(true);
        role.GetComponent<RoleController>().ActiveBridge();
    }

    public void Win()
    {
        role.GetComponent<RoleController>().enabled = false;
        FinalUI.SetActive(true);
    }
}
