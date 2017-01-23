﻿using UnityEngine;
using UnityEngine.UI;

public class GravityWarp : MonoBehaviour {

	public float gravityScale = 4.0f;

	public Text text;

	public Transform[] boxes;

	public static string gravity = "D";

	string lastGravDir;

	// Update is called once per frame
	void Update () {
		text.text = boxes[0].GetComponent<Rigidbody2D>().velocity.ToString();
		for (int i = 0; i < boxes.Length; i++) {
			if (Input.GetKey(KeyCode.UpArrow) || gravity == "U") {
				boxes[i].GetComponent<Rigidbody2D> ().gravityScale = -gravityScale;
				gravity = "U";
			}
			if (Input.GetKey (KeyCode.DownArrow) || gravity == "D") {
				boxes[i].GetComponent<Rigidbody2D> ().gravityScale = gravityScale;
				gravity = "D";
			}
			if (Input.GetKey (KeyCode.LeftArrow) || gravity == "L") {
				boxes[i].GetComponent<Rigidbody2D> ().gravityScale = 0;
				gravity = "L";
			}
			if (Input.GetKey (KeyCode.RightArrow) || gravity == "R") {
				boxes[i].GetComponent<Rigidbody2D> ().gravityScale = 0;
				gravity = "R";
			}
			if (Input.GetKey (KeyCode.Space)) {
				if (gravity == "0") {
					gravity = lastGravDir;
				} else {
					lastGravDir = gravity;
					gravity = "0";
					boxes[i].GetComponent<Rigidbody2D> ().gravityScale = 0;
				}
			}
			if (gravity == "L") {
				boxes[i].GetComponent<Rigidbody2D> ().AddForce(new Vector2(-gravityScale * 9.8f, 0));
			}
			if (gravity == "R") {
				boxes[i].GetComponent<Rigidbody2D> ().AddForce(new Vector2(gravityScale * 9.8f, 0));
			}
		}
	}
}
