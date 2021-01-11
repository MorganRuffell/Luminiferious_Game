using System;
using System.Collections;
using System.Collections.Generic;
using Luminfiarious.Manager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Luminfiarious.Gameplay
{
	public class WeaponSwapScript : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
	{

		private bool FirstInteraction = true;

		public GameObject UiWeaponLiveIndicator;
		public GameObject UiGrappilingHookIndicator;


		public void OnPointerClick(PointerEventData eventData)
		{
			FiringManager();
		}

		public void FiringManager()
		{
			if (FirstInteraction == true)
			{
				//This swaps round but it won't instantiate gameObject.
				Luminfiarious.Manager.GameManager.gameManager.IsGunSelected = true;
				FirstInteraction = false;
				UiGrappilingHookIndicator.SetActive(false);
				UiWeaponLiveIndicator.SetActive(true);

				Debug.Log("Handling first interaction.");
				return;
			}

			else
			{
				//Luminfiarious.Manager.GameManager.gameManager.IsGunSelected = false;

				if (Luminfiarious.Manager.GameManager.gameManager.IsGunSelected == false)
				{
					Luminfiarious.Manager.GameManager.gameManager.IsGunSelected = true;
					Debug.ClearDeveloperConsole();
					Debug.Log("Swapped to handgun");
					UiGrappilingHookIndicator.SetActive(false);
					UiWeaponLiveIndicator.SetActive(true);
					
					
					return;
				}

				if (Luminfiarious.Manager.GameManager.gameManager.IsGunSelected == true)
				{
					Luminfiarious.Manager.GameManager.gameManager.IsGunSelected = false;
					Debug.ClearDeveloperConsole();

					UiGrappilingHookIndicator.SetActive(true);
					UiWeaponLiveIndicator.SetActive(false);

					Debug.Log("Swapped back to grapple hook");
					return;
				}
			}

		}


		public void OnPointerDown(PointerEventData eventData)
		{
			throw new System.NotImplementedException();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			throw new System.NotImplementedException();
		}
	}
}


