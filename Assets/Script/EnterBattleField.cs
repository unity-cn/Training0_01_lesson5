using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBattleField : MonoBehaviour
{
    public GameObject EnterBattleFieldButton;

    public void Update()
    {
        EnterBattleFieldButton.SetActive(RoleManager.Instance.CanEnterBattle());
    }

    public void EnterBattle()
    {
        SceneManager.LoadScene("MainGame");
    }
}
