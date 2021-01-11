using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Luminfiarious.Audio
{
	public class AudioTrigger : MonoBehaviour
	{
		public AudioSource Audio;

		void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				Audio.Play();
			}
		}
	}
}



