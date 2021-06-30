using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycast : MonoBehaviour
{
    public float interactDistance;
    public Text pickupText;
    RaycastHit whatIHit;

    private void Update()
    {
        if (WhatDidISee() != null) // if the player is looking at something
        {
            GameObject lookingAt = WhatDidISee();

            if(lookingAt.tag == "Rubbish")
            {
                pickupText.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(lookingAt);
                }
            }
            else
            {
                pickupText.gameObject.SetActive(false);
            }
            
        }
    }

    public GameObject WhatDidISee()
    {
        Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out whatIHit, interactDistance))
        {
            return whatIHit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }
}
