﻿using UnityEngine;

public class Button : MonoBehaviour
{
    public Transform[] activates;
    public bool toggleable = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<GlueObject>() == null)
        {
			Activate(1);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(!(toggleable)){
            if (other.gameObject.GetComponent<GlueObject>() == null)
            {
                Activate(0);
            }
        }
    }

	void Activate(int source) {
		foreach(Transform field in activates) {
			if (field.GetComponent<Field>() != null) {
			    field.GetComponent<Field>().ToggleField();
			} else if (field.GetComponent<Door>() != null) {
				field.GetComponent<Door>().Active(source);
    		}
    	}
	}

}