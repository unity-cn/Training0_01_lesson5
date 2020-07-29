using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trick : MonoBehaviour
{
    public GameObject MainGame;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Role"))
        {
            MainGame.SendMessage("OnTrickActive");
        }
    }
}
