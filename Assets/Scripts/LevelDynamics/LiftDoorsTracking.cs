﻿using UnityEngine;
using System.Collections;

public class LiftDoorsTracking : MonoBehaviour {

	public float doorSpeed = 7f;

	private Transform leftOuterDoor;
	private Transform rightOuterDoor;
	private Transform leftInnerDoor;
	private Transform rightInnerDoor;
	private float leftClosedPositionX;
	private float rightClosedPositionX;

	void Awake()
	{
		leftOuterDoor = GameObject.Find ("door_exitOuter_left_001").transform;
		rightOuterDoor = GameObject.Find ("door_exitOuter_right_001").transform;
		leftInnerDoor = GameObject.Find ("door_exitInner_left_001").transform;
		rightInnerDoor = GameObject.Find ("door_exitInner_right_001").transform;

		leftClosedPositionX = leftInnerDoor.position.x;
		rightClosedPositionX = rightInnerDoor.position.x;
		
	}

	void MoveDoors(float newLeftXTarget, float newRightXTarget)
	{
		float newX = Mathf.Lerp (leftInnerDoor.position.x, newLeftXTarget, doorSpeed * Time.deltaTime);
		leftInnerDoor.position = new Vector3 (newX, leftInnerDoor.position.y, leftInnerDoor.position.z);

		newX = Mathf.Lerp (rightInnerDoor.position.x, newRightXTarget, doorSpeed * Time.deltaTime);
		rightInnerDoor.position = new Vector3 (newX, rightInnerDoor.position.y, rightInnerDoor.position.z);
	}

	public void DoorFollowing()
	{
		MoveDoors (leftOuterDoor.position.x, rightOuterDoor.position.x);
	}

	public void CloseDoors()
	{
		MoveDoors (leftClosedPositionX, rightClosedPositionX);
	}
}
