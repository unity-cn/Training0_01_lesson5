using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RoleWeapon")
        {
            gameObject.SetActive(false);
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
