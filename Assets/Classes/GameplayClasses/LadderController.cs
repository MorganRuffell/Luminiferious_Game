using System;
using System.Collections.Generic;
using UnityEngine;
using Luminfiarious.Character;

namespace Luminfiarious.Gameplay
{
	[RequireComponent(typeof(BoxCollider))]
	[SelectionBase]
	public class LadderController : MonoBehaviour
	{
		public PlayerControllerScript PlayerController;

		public void OnTriggerEnter(Collider collider)
		{
			if (collider.gameObject.tag == "Player")
			{
				PlayerController.bcanClimb = true;
			}
		}

		public void OnTriggerStay(Collider collider)
		{
			if (collider.gameObject.tag == "Player")
			{
				PlayerController.bIsPlayerClimbing = true;
			}
		}

		public void OnTriggerExit(Collider collider)
		{
			Debug.Log("Something has exited the collision space");

			if (collider.gameObject.tag == "Player")
			{
				Debug.Log("The player has exited the collision space");
				PlayerController.bcanClimb = false;
				PlayerController.bIsPlayerClimbing = false;
			}
		}
	}
}