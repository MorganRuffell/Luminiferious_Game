using System;
using System.Collections;
using System.Collections.Generic;
using Luminfiarious.Character;
using UnityEngine;

namespace Luminfiarious.Gameplay
{
	public class HealthPickup : InteractableBase, IItem
	{
		public ItemScriptable HealthPickupAttr;

		public Renderer renderer;

		public bool Interactable;

		public Material[] AMaterials;

		[Header("Gameplay Values")]
		[Range(0,50)]
		public short HealthIncreaseValue;
		[Range(0,20)]
		public float DestroyTimeDelay;

		public override void awake()
		{
			renderer = gameObject.GetComponent<Renderer>();
			renderer.enabled = true;
			renderer.sharedMaterial = AMaterials[0];
		}

		public void Interact()
		{
			Destroy(gameObject);
		}

		void Update()
		{
			if (!Interactable && Input.GetKeyDown(KeyCode.E))
			{
				Interact();
			}

			if (Interactable)
			{
				renderer.sharedMaterial = AMaterials[1];
			}

			else
			{
				renderer.sharedMaterial = AMaterials[0];
			}
		}

		public override void OnTriggerEnter(Collider collidingObject)
		{
			HandleCollisionEnter(collidingObject);
		}


		public override void OnTriggerExit(Collider collidingObject)
		{
			HandleCollisionExit(collidingObject);
		}

		public override void HandleCollisionExit(Collider collidingObject)
		{
			if (collidingObject.gameObject.tag == "Player")
			{
				Interactable = false;
			}
		}

		//This new operator is used to override non-virtual or static methods
		public new void HandleCollisionEnter(Collider collidingObject)
		{
			if (collidingObject.gameObject.tag == "Player")
			{
				Interactable = true;
				Buff(HealthIncreaseValue);
			}
		}

		public void Buff(short BuffValue)
		{
			//Logic for buffing playerhealth. 

			GameObject.Find("Player").GetComponent<healthScript>().PlayerCurrentHealth += BuffValue;

			DestroyObject();
		}

		public void DeBuff(short DebuffValue)
		{
			
		}

		public override void DestroyObject()
		{
			Destroy(this.gameObject,DestroyTimeDelay);
		}
	}

}

