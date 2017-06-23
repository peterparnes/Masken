﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Masken : MonoBehaviour {

	public GameObject tailPrefab; 

	public KeyCode rightKey; 
	public KeyCode leftKey; 
	public KeyCode upKey; 
	public KeyCode downKey; 

	private float speed = 0.1f;
	Vector2 vector = Vector2.zero;
	Vector2 moveVector;

	List<Transform> tail = new List<Transform>();

	bool eat = false;

	Food foodScript; 

	// Use this for initialization
	void Start () {
		foodScript = GetComponent<Food> ();

		InvokeRepeating("Movement", 0.3f, speed);
	}

	bool vertical = true;
	bool horizontal = true;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (rightKey) && horizontal) {
			horizontal = false;
			vertical = true;
			vector = Vector2.right;
		} else if (Input.GetKey (upKey) && vertical) {
			horizontal = true;
			vertical = false;
			vector = Vector2.up;
		} else if (Input.GetKey (downKey) && vertical) {
			horizontal = true;
			vertical = false;
			vector = -Vector2.up;
		} else if (Input.GetKey (leftKey) && horizontal) {
			horizontal = false;
			vertical = true;
			vector = -Vector2.right;
		}
		moveVector = vector / 3f;
	}

	void Movement() {
		Vector2 ta = transform.position;
		if (eat) {
			if (speed > 0.002){
				speed = speed - 0.002f;
			}
			GameObject g =(GameObject)Instantiate(tailPrefab, ta, Quaternion.identity);
			tail.Insert(0, g.transform);
			// Debug.Log(speed);
			eat = false;
		}
		else if (tail.Count > 0) {
			tail.Last().position = ta;
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}
		transform.Translate(moveVector);
	}
		
	void OnTriggerEnter2D(Collider2D c) {
		if (c.name.StartsWith ("Food")) {
			eat = true;
			Destroy (c.gameObject);

			if (foodScript) {
				foodScript.SpawnFood ();
			}

		} else { // Game Over 
			Time.timeScale=0;
		}
	}
}
