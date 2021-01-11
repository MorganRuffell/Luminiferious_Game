using System.Collections;
using System.Collections.Generic;
using Luminfiarious.Manager;
using UnityEngine;
using UnityEngine.UI;

public class LivesRemainingScript : MonoBehaviour
{
	public GameManager gameManager;
	public static LivesRemainingScript lives;

	public Text LivesText;

	void Start()
	{
		if (lives == null)
		{
			DontDestroyOnLoad(this);
			lives = this;
		}
		else if (lives != this)
		{
			Destroy(gameObject);
		}

		LivesText = gameObject.GetComponent<Text>();
		LivesText.text = gameManager.PlayerLives.ToString();
	}

	void Update()
	{
		LivesText.text = gameManager.PlayerLives.ToString();
		
	}

	
}
