﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GravityWarp : MonoBehaviour
{

    public static float gravityScale = 4.0f; // Amount of gravity to apply.
    public List<Transform> boxes = new List<Transform>();
    public List<Transform> glues = new List<Transform>();
    public List<Transform> tutGlues = new List<Transform>();
    public List<Transform> clutter = new List<Transform>();

    public Transform[] bloods;
    public float thrust; // For horizontal movement. Multiplies gravityScale.
    public static string gravity = "D"; // The current gravity direction.

    public Transform player;
    public GameObject menu;
    public bool playerDead = false;
    public bool gravityControlEnabled = false;

    GameObject checkpointText;
    GameObject pauseTimerText;
    GameObject deathTimerText;
    bool blood = false;
    bool hasRemote;
    
    public float changetmr =0.0f;
    float reTimer = 0f;
    float deathTimer = 0f;
    int gravityCount = 0;

    public float checktmr = 0f;
    public float coolDown = 0f;    
    public bool time = true;
    public float leveltmr =0f;

    void Start() {
        checkpointText = menu.transform.FindChild("txtCheck").gameObject;
        deathTimerText = menu.transform.FindChild("DeathPanel").FindChild("deathTimerText").gameObject;
        pauseTimerText = menu.transform.FindChild("PausePanel").FindChild("pauseTimerText").gameObject;
    }

    void Update()
    {   
        changetmr += Time.deltaTime;
        if(time){
            leveltmr += Time.deltaTime;
            pauseTimerText.GetComponent<Text>().text = "Current Level Time: "+ string.Format("{0:N2}",leveltmr);
            deathTimerText.GetComponent<Text>().text = "Your Time: "+ string.Format("{0:N2}",leveltmr);  
        }
        if(checktmr >0){
            checktmr -= Time.deltaTime;
        }else{
            checkpointText.SetActive(false);
        }
        // Check for gravity change.
        if (gravityControlEnabled)
        {
            if (InputManager.gravityControlScheme == 1) {
                InputHandler();
            }
            if (!hasRemote)
            {
                hasRemote = true;
            }
        }
        else if (hasRemote)
        {
            hasRemote = false;
        }

        /* Updates box gravity. The player is also added to this list by Player.cs */
        BoxGravity();
        // If some glue exists, update glue gravity.
        GlueGravity();
        ClutterGravity();
        if (playerDead)
        {   
            time = false;
            gravityControlEnabled = false;
            if (!blood)
            {
                if (gravity == "U")
                {
                    Transform bloodSplatter = GameObject.Instantiate(bloods[3]);
                    bloodSplatter.position = player.position;
                }
                else if (gravity == "D")
                {
                    Transform bloodSplatter = GameObject.Instantiate(bloods[1]);
                    bloodSplatter.position = player.position;
                }
                else if (gravity == "L")
                {
                    Transform bloodSplatter = GameObject.Instantiate(bloods[0]);
                    bloodSplatter.position = player.position;
                }
                else if (gravity == "R")
                {
                    Transform bloodSplatter = GameObject.Instantiate(bloods[2]);
                    bloodSplatter.position = player.position;
                }
                blood = true;
                
            }
            if (deathTimer < 1f)
            {
                deathTimer += Time.deltaTime;

            }
            else{
                menu.GetComponent<MenuHandler>().ShowDeath();
            }
        }
    }

    /* Handles user input for gravity change. */
    void InputHandler()
    {
        if (gravityCount < 6)
        {
            if (Input.GetKey(InputManager.gravityUp) && gravity != "U")
            {
                gravity = "U";
                gravityCount++;
                reTimer = 0f;
                player.GetComponent<Player>().antiPhase();
                changetmr =0.0f;
            }
            if (Input.GetKey(InputManager.gravityDown) && gravity != "D")
            {
                gravity = "D";
                gravityCount++;
                reTimer = 0f;
                player.GetComponent<Player>().antiPhase();
                changetmr =0.0f;
            }
            if (Input.GetKey(InputManager.gravityLeft) && gravity != "L")
            {
                gravity = "L";
                gravityCount++;
                reTimer = 0f;
                player.GetComponent<Player>().antiPhase();
                changetmr =0.0f;
            }
            if (Input.GetKey(InputManager.gravityRight) && gravity != "R")
            {
                gravity = "R";
                gravityCount++;
                reTimer = 0f;
                player.GetComponent<Player>().antiPhase();
                changetmr =0.0f;
            }
            if (gravityCount > 0)
            {
                reTimer += Time.deltaTime;
                if (reTimer > 2f)
                {
                    reTimer = 0;
                    gravityCount = 0;
                }
            }
            
        }
        else
        {
            if (coolDown > 2f)
            {
                coolDown = 0f;
                gravityCount = 0;
            }
            else
            {
                coolDown += Time.deltaTime;
            }
        }

    }

    /* Controls gravity for all items in the glues list. */
    void GlueGravity()
    {

         foreach (Transform glue in tutGlues)
        {
            if (glue != null)
            {
                switch (gravity)
                {
                    case "U":
                        glue.GetComponent<Rigidbody2D>().gravityScale = -gravityScale;
                        break;
                    case "D":
                        glue.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                        break;
                    case "L":
                        glue.GetComponent<Rigidbody2D>().gravityScale = 0;
                        glue.GetComponent<Rigidbody2D>().AddForce(new Vector2(-gravityScale * thrust, 0));
                        break;
                    case "R":
                        glue.GetComponent<Rigidbody2D>().gravityScale = 0;
                        glue.GetComponent<Rigidbody2D>().AddForce(new Vector2(gravityScale * thrust, 0));
                        break;
                }
            }
        }

        foreach (Transform glue in glues)
        {
            if (glue != null)
            {
                switch (gravity)
                {
                    case "U":
                        glue.GetComponent<Rigidbody2D>().gravityScale = -gravityScale;
                        break;
                    case "D":
                        glue.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                        break;
                    case "L":
                        glue.GetComponent<Rigidbody2D>().gravityScale = 0;
                        glue.GetComponent<Rigidbody2D>().AddForce(new Vector2(-gravityScale * thrust, 0));
                        break;
                    case "R":
                        glue.GetComponent<Rigidbody2D>().gravityScale = 0;
                        glue.GetComponent<Rigidbody2D>().AddForce(new Vector2(gravityScale * thrust, 0));
                        break;
                }
            }
        }
    }

    /* Controls gravity for all items in the boxes list. */
    void BoxGravity()
    {
        foreach (Transform box in boxes)
        {
            if (box != null)
            {
                if (!(box.GetComponent<Glue>().isGlued()))
                {
                    switch (gravity)
                    {
                        case "U":
                            box.GetComponent<Rigidbody2D>().gravityScale = -gravityScale;
                            break;
                        case "D":
                            box.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                            break;
                        case "L":
                            box.GetComponent<Rigidbody2D>().gravityScale = 0;
                            box.GetComponent<Rigidbody2D>().AddForce(new Vector2(-gravityScale * thrust, 0));
                            break;
                        case "R":
                            box.GetComponent<Rigidbody2D>().gravityScale = 0;
                            box.GetComponent<Rigidbody2D>().AddForce(new Vector2(gravityScale * thrust, 0));
                            break;
                    }
                }
            }
        }
    }

    void ClutterGravity()
    {
        foreach (Transform item in clutter)
        {
            if (item.GetComponent<Rigidbody2D>() != null)
            {
                switch (gravity)
                {
                    case "U":
                        item.GetComponent<Rigidbody2D>().gravityScale = -gravityScale;
                        break;
                    case "D":
                        item.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                        break;
                    case "L":
                        item.GetComponent<Rigidbody2D>().gravityScale = 0;
                        item.GetComponent<Rigidbody2D>().AddForce(new Vector2(-gravityScale * thrust, 0));
                        break;
                    case "R":
                        item.GetComponent<Rigidbody2D>().gravityScale = 0;
                        item.GetComponent<Rigidbody2D>().AddForce(new Vector2(gravityScale * thrust, 0));
                        break;
                }
            }
        }
    }
    
    public void glueExtraPlace(){
        Destroy(glues[0].gameObject);
        glues.RemoveAt(0);
        /*for(int i=1;i<glues.Capacity;i++){
            glues[i-1] = glues[i];
        }*/
    }
}