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

		GameObject food = Instantiate (foodPrefab, new Vector2 (x, y), Quaternion.identity);
		if (CheckOverlaps (food)) {
			Destroy (food);
			SpawnFood ();
		}
	}
		
	bool CheckOverlaps(GameObject food) {
		RectTransform rectTransF = food.GetComponent<RectTransform> (); 
		Score score = GetComponent<Score> (); 
		score = null; 
		if (!score) {
			return false;
		}
		RectTransform rectTransS = score.GetRectTransform ();

		// The position is offset with a half for some reason I cannot find. Just add 0.5f to x to the localposition. 
		Rect rectF = new Rect(rectTransF.localPosition.x+0.5f, rectTransF.localPosition.y, rectTransF.rect.width, rectTransF.rect.height);
		Rect rectS = new Rect(rectTransS.localPosition.x, rectTransS.localPosition.y, rectTransS.rect.width, rectTransS.rect.height);

		bool overlaps = rectF.Overlaps(rectS);

		return overlaps;
	}

}
