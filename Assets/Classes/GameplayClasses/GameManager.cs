using System;
using System.Collections;
using System.Collections.Generic;
using Luminfiarious.Character;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Luminfiarious.Manager
{
	[DisallowMultipleComponent]
	public class GameManager : MonoBehaviour
	{
		[HideInInspector]
		public static GameManager gameManager;		
		public healthScript Playerhealth;
		[Space]
		public GameObject gameOverCanvas;
		[Space]
		public GameObject PauseCanvas;
		[Space]
		public GameObject PlayerUI;
		public GameObject PlayerLivesUI;


		[Header("Reloading Lives System")]
		public Int16 PlayerLives;   
        public string SceneToLoad;

		public GameObject LivesCount0;
		public GameObject LivesCount1;
		public GameObject LivesCount2;

		private static bool a = false;
		private static bool b = false;
		private static bool c = false;




		[HideInInspector]
		public bool isGamePaused;
	
		[HideInInspector]
		public bool IsGunSelected = false;

		private void Update()
		{
			gameOverCanvas = GameObject.Find("GameOverCanvas");
			PauseCanvas = GameObject.Find("PauseCanvas");
		}


		private void Awake()
		{

			//Our GameManager Implements a singleton design pattern, meaning that there can only.
			//be one such instance of it in the scene.
			if (gameManager == null)
			{
				DontDestroyOnLoad(this);
				gameManager = this;
			}
			else if (gameManager != this)
			{
				Destroy(gameObject);
			}

			//if (gameOverCanvas = null)
			//{ 
			//	gameOverCanvas = GameObject.Find("GameOverCanvas");
			//	PauseCanvas = GameObject.Find("PauseCanvas");
			//}

			if (a == true)
			{
				LivesCount0.GetComponent<Image>().gameObject.SetActive(false);
			}

			if (b == true)
			{
				LivesCount1.GetComponent<Image>().gameObject.SetActive(false);
			}

			if (c == true)
			{
				LivesCount2.GetComponent<Image>().gameObject.SetActive(false);
			}

			//This conversion is added through the static explicit operator overload below.
			gameManager = (Luminfiarious.Manager.GameManager) GameObject.Find("GameManager").transform.Find("GameManager").gameObject;

			PlayerUI.SetActive(true);
			PauseCanvas.SetActive(false);				
		}


		//This is a public static explicit operator overload. This forces unity to accept the conversion from GameObject to Luminifarious.GameManager
		public static explicit operator GameManager(GameObject v)
		{
			throw new NotImplementedException();
		}

		public void ResumeGame()
		{
			PlayerUI.SetActive(true);
			PlayerLivesUI.SetActive(true);

			PauseCanvas.SetActive(false);
			isGamePaused = false;
			Time.timeScale = 1;
		}

		public void GamePaused()
		{
			PlayerUI.SetActive(false);
			PlayerLivesUI.SetActive(false);

			Time.timeScale = 0;
			PauseCanvas.SetActive(true);
			isGamePaused = true;

		}

		public void LifeCheck()
		{
			Debug.Log("The current player lives count it  " + PlayerLives);

			if (PlayerLives <= 1)
			{
				LivesCount2.SetActive(false);
				c = true;
				EndGame();
			}

			if (gameManager.PlayerLives == 2)
			{
				LivesCount1.SetActive(false);
				//LivesCount1.GetComponent<Image>().enabled = false;
				b = true;
				RestartGame();
			}

			if (gameManager.PlayerLives == 3)
			{
				LivesCount0.SetActive(false);
				a = true;
				RestartGame();		
			}
		}
		
		public void RestartGame()
		{
			PlayerLives--;
			SceneManager.LoadScene("Level1");	
		}

		public void EndGame()
		{
			Debug.Log("Game Over.");
		
		}
	}
}


