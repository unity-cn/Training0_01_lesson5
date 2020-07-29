using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickTo : MonoBehaviour
{
    private NavMeshAgent _agent;
    public Camera mainCamera;
        
    void Start() {
        _agent = GetComponent<NavMeshAgent>();
    }
        
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
                
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit)) {
                _agent.destination = hit.point;
            }
        }
    }
}
