using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoleManager : MonoBehaviour
{
    public enum RoleType
    {
        None,
        Warrior,
        Mage
    }
    
    [Serializable]
    public class RolePrefabInfo
    {
        public RoleType type;
        public GameObject prefab;
    }

    public static RoleManager Instance;
    public List<RoleSelected> roles;
    public List<RolePrefabInfo> rolesPrefab;
    public Camera _camera;
    private static readonly int Attack1Trigger = Animator.StringToHash("Attack1Trigger");
    private RoleType _currentRoleType = RoleType.None;

    private void Start()
    {
        DontDestroyOnLoad(this);
        Instance = this;
    }

    public static RoleManager GetRoleManager()
    {
        return Instance;
    }

    public bool CanEnterBattle()
    {
        return _currentRoleType != RoleType.None;
    }

    public GameObject CreateSelectedRole(Transform parent)
    {
        foreach (RolePrefabInfo rolePrefabInfo in rolesPrefab)
        {
            if (_currentRoleType == rolePrefabInfo.type)
            {
                return Instantiate(rolePrefabInfo.prefab, parent);
            }
        }

        return Instantiate(rolesPrefab[0].prefab);
    }

    public void ActiveAnimator(RoleSelected target)
    {
        foreach (RoleSelected selected in roles)
        {
            if (target == selected)
            {
                selected.animator.SetTrigger(Attack1Trigger);
                selected.banner.SetActive(true);
                _currentRoleType = selected.type;
            }
            else
            {
                selected.banner.SetActive(false);
            }
        }
        
    }
}
