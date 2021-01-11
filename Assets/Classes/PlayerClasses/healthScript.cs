using System;
using System.Collections;
using System.Collections.Generic;
using Luminfiarious.Manager;
using UnityEngine;

namespace Luminfiarious.Character
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(PlayerControllerScript))]
	public class healthScript : MonoBehaviour
	{
		#region PlayerHealth & Life Variables
		[SerializeField]
		public Rigidbody PlayerRigidBody;

		//public event PlayerDestroyed 

		[HideInInspector]
		public bool IsPlayerDead = false;

		[Range(0, 30), Tooltip("This is how long the players body will hang around before it is removed.")]
		public float DeathTime = 6.0f;
		public Animator PlayerAnimator;


		//[Header("Health Settings")]
		[Range(0, 500), Tooltip("The players current health")]
		public Int16 PlayerCurrentHealth;

		[Range(100, 500), Tooltip("The players Maximum health")]
		public Int16 PlayerMaximumHealth;

		[Space]
		[Space]
	
		[SerializeField, Range(0, 30), Tooltip("This is useful if we want our character to be able to autoheal, have a play with this value.")]
		private float TimeBasedHealAmount;

		#endregion

		private void Awake()
		{
			PlayerCurrentHealth = PlayerMaximumHealth;


		}

		private void Update()
		{
			//ToDo Fix the UI so that it shows the health
			GetHealthPercentage();

			if (PlayerCurrentHealth <= 0)
			{
				IsPlayerDead = true;
				PlayerAnimator.SetTrigger("IsDead");
				Death();
			}
		}

		public void TakeDamage(int amount)
		{
			PlayerCurrentHealth -= (Int16) amount;
		}

		public void TakeDamage(float amount)
		{
			PlayerCurrentHealth -= (Int16) amount;
		}

		public void Death()
		{
			if(IsPlayerDead && GameManager.gameManager.PlayerLives > 0)
			{
				GameManager.gameManager.LifeCheck();
			}

			if (GameManager.gameManager.PlayerLives <= 0)
			{
				IsPlayerDead = true;
				PlayerRigidBody.constraints = RigidbodyConstraints.FreezePositionX;
				PlayerRigidBody.constraints = RigidbodyConstraints.FreezePositionZ;
				PlayerRigidBody.constraints = RigidbodyConstraints.FreezePositionY;
				//Implement Logic for the player death animation
	
				Invoke("DestroyGameObject", DeathTime);
			}

		}

		//Fixed: Resolved the issue with the health & lives system, couldn't integrate the scriptable objects
		private void DestroyGameObject()
		{
			//Some logic for the gamemanager
			Destroy(this.gameObject);
		}

		public float GetHealthPercentage()
		{
			return (float)PlayerCurrentHealth / PlayerMaximumHealth;
		}
	}
}