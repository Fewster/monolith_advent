using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject actionUI;
	
    RaycastHit hit;

	void Start()
    {
        
    }

    void Update()
    {
	    int layerMask = 1 << 7;
	    //layerMask = layerMask;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2, layerMask))
        {
            toggleActionUI(true);
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red, 1);
            Debug.Log(hit.collider.gameObject.name + " " + hit.collider.gameObject.tag);
        }
        else
        {
			toggleActionUI(false);
		}
	}

	private void toggleActionUI(bool isDisplayed)
	{
        actionUI.SetActive(isDisplayed);
        if(isDisplayed && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("You've Picked Up: " + hit.collider.gameObject.name);
        }
	}
}
