using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminfiarious.Character;
using Luminfiarious.Supers;

namespace Luminfiarious.Enemies
{	
	public class EnemyDamageScript : DamageParent
	{
		[Header("Enemy Control Variables")]
		[Tooltip("How much damage the enemy can do.")]
		public int Damage = 10; 

		[Tooltip("Useful for boss monsters, this allows us to multiply the amount of damage that this specific enemy  ")]
		public float EnemyDamageMultiplier = 1.0f;

		[Tooltip("The string literal name of the tag that this specific enemy will do damage to.")]
		public string TargetTag;

		//protected override int Damage => throw new System.NotImplementedException();
		private void Awake()
		{	
			Damage = Damage * (int)EnemyDamageMultiplier;	
		}

		private void OnCollisionEnter(Collision collision)
		{
			//if (collision.gameObject.CompareTag("Player"))
			//	{
				collision.gameObject.GetComponent<healthScript>().TakeDamage(Damage);
			//}
		}
	}
}


