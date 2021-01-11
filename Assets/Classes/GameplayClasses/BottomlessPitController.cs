using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminfiarious.Character;
using Luminfiarious.Supers;

namespace Luminfiarious.Gameplay
{
    public class BottomlessPitController : MonoBehaviour
    {
        public int DamageImplementation = 999;

		//protected override int Damage => throw new System.NotImplementedException();

		private void OnCollisionEnter(Collision collidingObject)
        {
			HandleCollision(collidingObject);
        }

		public void HandleCollision(Collision collidingObject)
		{
			if (collidingObject.gameObject.CompareTag("Player"))
			{
				collidingObject.gameObject.GetComponent<healthScript>().TakeDamage(DamageImplementation);
			}
		}

		
	}
}
