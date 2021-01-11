using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luminfiarious.Gameplay
{
    public abstract class InteractableBase : MonoBehaviour
	{       //This is an array of material classes
        private Renderer renderer;

        private bool Interactable;

        private Material[] AMaterials; 

		public virtual void awake()
    	{	
            renderer = GetComponent<Renderer>();
            GetComponent<Renderer>().enabled = true;
            GetComponent<Renderer>().sharedMaterial = AMaterials[0];
    	}
 
        void Update()
        {
            //This implementation will work with keyboard for now, eventually it will work with on- screen controls.
            if (!Interactable && Input.GetKeyDown(KeyCode.E))
            {
                //Implementation Code goes here.
               //Interact();
            }
            
            if (Interactable)
            {
               GetComponent<Renderer>().sharedMaterial = AMaterials[1];
            }
    
    		else
    		{
                GetComponent<Renderer>().sharedMaterial = AMaterials[0];
    		}
        }
    
    	public virtual void OnTriggerEnter(Collider collidingObject)
    	{
            HandleCollisionEnter(collidingObject);
    	}
    
    
    	public virtual void OnTriggerExit(Collider collidingObject)
    	{
            HandleCollisionExit(collidingObject);
    	}
    
    	public virtual void HandleCollisionExit(Collider collidingObject)
    	{
            if(collidingObject.gameObject.tag == "Player")
            {
                Interactable = false;
            }
    	}
    
        public virtual void HandleCollisionEnter(Collider collidingObject)
    	{
    		if (collidingObject.gameObject.tag == "Player")
    		{
                Interactable = true;
    		}
    	}
    
        public virtual void DestroyObject()
        {
            Destroy(gameObject);
		}

    }
}
