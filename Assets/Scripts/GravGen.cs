﻿using UnityEngine;

public class GravGen : MonoBehaviour
{

    Animator anim;

    public Transform door;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            print("Enter");
            anim.SetBool("explode", true);
            door.GetComponent<Door>().ActivateLink(1);
            GravityWarp.gravity = "D";
            Camera.main.GetComponent<GravityWarp>().gravityControlEnabled = false;
        }

    }
}