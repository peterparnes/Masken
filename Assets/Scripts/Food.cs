using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Food : MonoBehaviour {

	public GameObject foodPrefab;
	public Transform rightWall;
	public Transform leftWall;
	public Transform topWall;
	public Transform bottonWall;

	// Use this for initialization
	void Start () {
		SpawnFood();
	}
		
	public void SpawnFood() {
		int x = (int)Random.Range (leftWall.position.x, rightWall.position.x);
		int y = (int)Random.Range (bottonWall.position.y, topWall.position.y);

		Instantiate (foodPrefab, new Vector2 (x, y), Quaternion.identity);
	}

}
