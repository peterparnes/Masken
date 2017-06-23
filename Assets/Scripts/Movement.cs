using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	Masken masken;

	public KeyCode rightKey = KeyCode.RightArrow; 
	public KeyCode leftKey = KeyCode.LeftArrow; 
	public KeyCode upKey = KeyCode.UpArrow; 
	public KeyCode downKey = KeyCode.DownArrow; 

	Vector2 vector = Vector2.zero;

	// Use this for initialization
	void Start () {
		masken = GetComponent<Masken> ();
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
		masken.SetMovementVector(vector / 3f);
	}
}
