using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Masken : MonoBehaviour {

	public GameObject tailPrefab; 

	public float MinimumDelayTime = 0.002f; 
	public float DelayDecreaseTime = 0.005f;
	public float InitialDelayTime = 0.1f;

	private float speed ;
	Vector2 moveVector;

	List<Transform> tail = new List<Transform>();

	bool eat = false;

	Food foodScript; 

	// Use this for initialization
	void Start () {
		foodScript = GetComponent<Food> ();

		speed = InitialDelayTime;
		InvokeRepeating("Movement", 0.3f, speed);
	}
		
	// Update is called once per frame
	void Update () {
		
	}

	public void SetMovementVector(Vector2 vector) {
		moveVector = vector;
	}

	void Movement() {
		Vector2 ta = transform.position;
		if (eat) {
			IncreaseSpeed ();

			GameObject g =(GameObject)Instantiate(tailPrefab, ta, Quaternion.identity);
			tail.Insert(0, g.transform);
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

	void IncreaseSpeed() {
		// speed += 0.002f;

		if (speed > MinimumDelayTime){
			speed = speed - DelayDecreaseTime;

			Debug.Log(speed);

		}
		CancelInvoke ();

		InvokeRepeating("Movement", speed, speed);
	}
}
