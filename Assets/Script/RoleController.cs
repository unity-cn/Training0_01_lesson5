using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public class RoleController : MonoBehaviour
{
	public Animator animator;
	// float rotationSpeed = 30;
	// Vector3 inputVec;
	// Vector3 targetDirection;
	public Camera mainCamera;
	public NavMeshAgent agent;
	private Transform roleTransform;
	private static readonly int Moving = Animator.StringToHash("Moving");
	private static readonly int Back = Animator.StringToHash("Back");
	private static readonly int Attack1Trigger = Animator.StringToHash("Attack1Trigger");

	//Warrior types
	// public enum Warrior{Karate, Ninja, Brute, Sorceress, Knight, Mage, Archer, TwoHanded, Swordsman, Spearman, Hammer, Crossbow};
	// public Warrior warrior;

	public void Init()
	{
		agent.radius = 0.5f;
		agent.areaMask = NavMesh.AllAreas &  ~(1 << NavMesh.GetAreaFromName("Bridge")) ;
		roleTransform = animator.gameObject.transform;

	}

	void Update()
	{
		if (Input.GetKey(KeyCode.W) && agent.isOnNavMesh)
		{
			animator.SetBool(Moving, true);
		}
		else if (Input.GetKey(KeyCode.S) && agent.isOnNavMesh)
		{
			animator.SetBool(Back, true);
		}
		else
		{
			animator.SetBool(Moving, false);
			animator.SetBool(Back, false);
		}

		if (Input.GetMouseButtonDown(0))
		{
			animator.SetTrigger(Attack1Trigger);
		}
		UpdateDirection();
		UpdateCamera();
		
		
	}

	void UpdateCamera()
	{
		Vector3 rolePos = roleTransform.position;
		Vector3 forwardNormal = roleTransform.forward.normalized;
		Vector3 cameraPos =  rolePos - forwardNormal * 10;
		cameraPos.y = 6;
		mainCamera.transform.position = cameraPos;

		Vector3 cameraLookAt = rolePos + forwardNormal * 5;
		mainCamera.transform.LookAt(cameraLookAt);
	}

	void UpdateDirection()
	{
		float h = Input.GetAxisRaw("Horizontal");
		roleTransform.Rotate(new Vector3(0,1,0), 2.0f*h);
		
	}

	public void ActiveBridge()
	{
		agent.areaMask = NavMesh.AllAreas;
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
