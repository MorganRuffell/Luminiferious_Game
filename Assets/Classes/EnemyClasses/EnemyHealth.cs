using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Luminfiarious.Enemies
{
	[DisallowMultipleComponent]
	class EnemyHealth : MonoBehaviour
	{
		[Header("Enemy Health Attributes")]
		[Range(0, 500), Tooltip("The enemies Current Health")]
		public int EnemyCurrentHealth;

		[Range(0, 500), Tooltip("The enemies Maximum Health")]
		public int EnemyMaxHealth;

		[Range (0, 20), Tooltip ("How long it takes for the death animation to play out in seconds...")]
		public float EnemyDeathDelay = 2.0f;

		[Tooltip ("This is the amount of damage tha")]
		public float DamageMultiplier = 0.0f;

		public void OnEnable()
		{			
			EnemyCurrentHealth = EnemyMaxHealth;
		}

		public void TakeDamage(int amount)
		{
			float TotalDamage = DamageMultiplier * amount; 

			EnemyCurrentHealth -= (int) TotalDamage;

			if (EnemyCurrentHealth <= 0)
			{
				Invoke("Die", EnemyDeathDelay);
			}

		}
	
		private void Die()
		{
			Destroy(gameObject);
	
		}

		//This is for the UI, it's greyed out as I won't be using it yet.
		public float GetHealthPercentage()
		{
			return (float)EnemyCurrentHealth / EnemyMaxHealth;
		}

	}
}
