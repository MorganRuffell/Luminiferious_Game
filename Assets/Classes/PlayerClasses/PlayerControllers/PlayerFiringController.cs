using UnityEngine;
using Luminfiarious.Character;
using Luminfiarious.UI;
using Luminfiarious.Manager;

namespace Luminfiarious.Gameplay
{
	[RequireComponent(typeof(PlayerControllerScript))]
	class PlayerFiringController : MonoBehaviour
	{
		[Header("Bullet Spawning")]
		[Tooltip("This is the location where the firing mechanism can spawn from")]
		public Transform spawnPoint;

		[Space]
		[Tooltip("This is the projectile that we are spawning")]
		public GameObject projectile;
	
		[Header("AmmoScript")]
		public GameObject ammoUI;

		private void Awake()
		{
			//Prioritise this method for stuff done on instantiation
		}

		private void Start()
		{
			//Implement logic for when we've made the animations and set them up inside of unity.
		}
	
		//Todo change this so that it enables the firing mechanism when the grappiling

		private void Update()
		{
			if (GameManager.gameManager.IsGunSelected == true && MouseManager.bCanFire == true)
			{
				Debug.ClearDeveloperConsole();

				Debug.Log("Game Manager processes firing mechanics");
				Fire();
			}
		}

		/// <summary>
		///	You need a delay value, when you run fire you then want it to be set to false.
		///	in update if bCanFire..
		///	
		/// Two variables, one that says you can actually fire. The second one would be the delay.
		/// 
		///  
		///
		/// 
		/// </summary>

		private void Fire()
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (ammoUI.GetComponent<AmmoRemainingScript>().AmmoAmount <= 0)
				{
					Debug.ClearDeveloperConsole();
					Debug.Log("Out Of Ammo");
					return;
				}

				else
				{
					ammoUI.GetComponent<AmmoRemainingScript>().AmmoAmount--;
					Instantiate(projectile, spawnPoint.transform.position, spawnPoint.rotation);
				}
			}
		}

	}
}
