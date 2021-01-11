using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminfiarious.Gameplay;

namespace Luminfiarious.Gameplay
{
	public class AmmoClass : InteractableBase, IItem
	{
		public bool Interactable;

		public Renderer renderer;

		public Material[] AMaterials;

		public AmmoRemainingScript ammoController;

		[Header("Gameplay Values")]
		[Range(0, 50)]
		public short AmmoIncreaseValue;
	
		[Range(0,20)]
		public float DestroyTimeDelay;

		public void Update()
		{
			if (Interactable)
			{
				GetComponent<Renderer>().sharedMaterial = AMaterials[1];
			}

			else
			{
				GetComponent<Renderer>().sharedMaterial = AMaterials[0];
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

		public override void HandleCollisionEnter(Collider collidingObject)
		{
			if (collidingObject.gameObject.tag == "Player")
			{
				Interactable = true;
				Interact();
			}
		}

		public void Interact()
		{
			ammoController.AmmoAmount += AmmoIncreaseValue;
			DestroyObject();
		}

		public void Buff(short BuffValue)
		{
			throw new System.NotImplementedException();
		}

		public void DeBuff(short DebuffValue)
		{
			throw new System.NotImplementedException();
		}

		public override void DestroyObject()
		{
			Destroy(this.gameObject, DestroyTimeDelay);
		}

	}
}
