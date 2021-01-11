using Luminfiarious.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Luminfiarious.Gameplay
{
	public class AmmoRemainingScript : MonoBehaviour
	{
		public GameManager gameManager;
		public Int16 AmmoAmount = 10;

		public Text AmmoText;

		void Start()
		{
			AmmoText = gameObject.GetComponent<Text>();
		}

		// Update is called once per frame
		void Update()
		{
			AmmoText.text = AmmoAmount.ToString();
		}
	}
}


