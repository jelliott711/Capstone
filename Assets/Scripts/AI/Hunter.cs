﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour {

    SideScrollingPlayer target;
    RoomManager roomManager;
	private bool reacting = false;
	private Vector3 reactPos;
	public bool paused = false;
	// Use this for initialization
	void Start () {
        target = FindObjectOfType<SideScrollingPlayer>();
        roomManager = FindObjectOfType<RoomManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate ()
    {
		if (!StateSaver.gameState.paused && !paused)
        {
			Vector3 goingTo = reacting ? reactPos : target.transform.position;
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(goingTo.x, goingTo.y, 0), 0.03f);
        }
    }
		
	public void ReactToBark (Vector3 point)
	{
		if (!reacting) {
			print ("hunt reaact");
			reactPos = point;
			reacting = true;
			StartCoroutine ("Reacting");
		}
	}

	IEnumerator Reacting ()
	{
		yield return new WaitForSeconds (5.0f);
		reacting = false;
	}
}
