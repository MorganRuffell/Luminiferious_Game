using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Luminfiarious.Manager;

namespace Luminfiarious.Gameplay
{
	
	public class WinTrigger : MonoBehaviour, ITriggerAble
	{
		public string SceneToLoad;

		private void OnTriggerEnter(Collider CollidingObject)
		{
			HandleCollision(CollidingObject);
		}
	
		public void HandleCollision(Collider CollidingObject)
		{
			if (CollidingObject.gameObject.CompareTag("Player"))
			{
				SceneManager.LoadScene(SceneToLoad);
			}
		}
	}
	
	
}
