using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycast : MonoBehaviour
{
    public float interactDistance;
    public Text interactText;
    RaycastHit whatIHit;

    private void Update()
    {
        if(InventoryManager.instance.invBackground.activeInHierarchy == false)
        if (WhatDidISee() != null) // if the player is looking at something
        {
            GameObject lookingAt = WhatDidISee();

            if(lookingAt.tag == "Rubbish")
            {
                interactText.text = "E to pickup";
                interactText.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(lookingAt);
                }
            }
            else if(lookingAt.tag == "Bin")
            {
                interactText.text = "E to use bin";
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    InventoryManager.instance.ShowBinUI();
                }
            }
            else if(lookingAt = null)
            {
                interactText.gameObject.SetActive(false);
            }
            else
            {
                interactText.gameObject.SetActive(false);
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
