using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleSelected : MonoBehaviour
{

    public GameObject banner;
    public RoleManager.RoleType type;
    public Animator animator;
    private Camera _camera;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;
        banner.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){ 
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 999999, LayerMask.GetMask(new []{"Roles"}))
            && hit.transform == transform)
            {
                Debug.Log(animator.name);
                RoleManager.Instance.ActiveAnimator(this);
            }
        }
    }

    //Placeholder functions for Animation events
    void Hit()
    {
    }

    void FootR()
    {
    }

    void FootL()
    {
    }
}
