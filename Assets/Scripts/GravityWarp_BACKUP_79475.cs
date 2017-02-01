﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GravityWarp : MonoBehaviour {

	public float gravityScale = 4.0f;

	public Text text;

	public Transform[] resources;

	 public List<Transform> boxes = new List<Transform>();

	 public List<Transform> glues = new List<Transform>();

	public float thrust;

<<<<<<< HEAD
	public static string gravity = "D";
=======
	public string gravity = "D";
>>>>>>> abcc5ed04cbb8732721142f1de8f1a685984f6ce

	string playerscript;
	string lastGravDir;
	// Use this for initialization
	void Start () {
		playerscript = gameObject.GetComponent<Player>().gravity;
	}

	// Update is called once per frame
	void Update () {
		doGravity();
		if(Camera.main.GetComponent<GlueControl>().glueCount > 0) {
			doGlueGravity();
		}
	}

	void doGlueGravity() {
		foreach(Transform glue in glues){
			if(glue != null) {
					if (Input.GetKey(KeyCode.UpArrow) || gravity == "U") {
						glue.GetComponent<Rigidbody2D> ().gravityScale = -gravityScale;
						gravity = "U";
					}
					if (Input.GetKey (KeyCode.DownArrow) || gravity == "D") {
						glue.GetComponent<Rigidbody2D> ().gravityScale = gravityScale;
						gravity = "D";
					}
					if (Input.GetKey (KeyCode.LeftArrow)) {
						glue.GetComponent<Rigidbody2D> ().gravityScale = 0;
						gravity = "R";
					}
					if (Input.GetKey (KeyCode.RightArrow)) {
						glue.GetComponent<Rigidbody2D> ().gravityScale = 0;
						gravity = "L";
					}
					if (gravity == "L") {
						glue.GetComponent<Rigidbody2D> ().AddForce(new Vector2(4.0f * thrust, 0));
					}
					if (gravity == "R") {
						glue.GetComponent<Rigidbody2D> ().AddForce(new Vector2(-4.0f * thrust, 0));
					}
			}
		}
	}

	void doGravity() {
		foreach(Transform box in boxes){
			if(box != null) {
				if(!(box.GetComponent<Glue>().isGlued())) {
					if (Input.GetKey(KeyCode.UpArrow) || gravity == "U") {
						box.GetComponent<Rigidbody2D> ().gravityScale = -gravityScale;
						gravity = "U";
					}
					if (Input.GetKey (KeyCode.DownArrow) || gravity == "D") {
						box.GetComponent<Rigidbody2D> ().gravityScale = gravityScale;
						gravity = "D";
					}
					if (Input.GetKey (KeyCode.LeftArrow)) {
						box.GetComponent<Rigidbody2D> ().gravityScale = 0;
						gravity = "R";
					}
					if (Input.GetKey (KeyCode.RightArrow)) {
						box.GetComponent<Rigidbody2D> ().gravityScale = 0;
						gravity = "L";
					}
					if (gravity == "L") {
						box.GetComponent<Rigidbody2D> ().AddForce(new Vector2(4.0f * thrust, 0));
					}
					if (gravity == "R") {
						box.GetComponent<Rigidbody2D> ().AddForce(new Vector2(-4.0f * thrust, 0));
					}
				}
			}
		}
	}
}