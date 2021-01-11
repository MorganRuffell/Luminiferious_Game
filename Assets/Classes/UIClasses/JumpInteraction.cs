using System;
using System.Collections;
using System.Collections.Generic;
using Luminfiarious.Character;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpInteraction : MonoBehaviour, IPointerClickHandler
{
	private Int32 tap;
	private bool readyForDoubleTap = true;

	public float JumpPower = 10;
	
	public PlayerControllerScript player;
	public Rigidbody PlayerRigidbody;
	public Animator PlayerAnimator;	

	private EventTrigger trigger;


	[HideInInspector]
	public bool isJumpPressed = false;

	public void Start()
	{
		PlayerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();
		trigger = gameObject.GetComponent<EventTrigger>();
		
		//NewMethod(trigger,OnPointerClick,);

	}

	//void NewMethod(EventTrigger trigger, EventTriggerType eventType, System.Action<BaseEventData> callBack)
	//{
	//	EventTrigger.Entry entry = new EventTrigger.Entry();
	//	entry.eventID = eventType;
	//	entry.callback = new EventTrigger.TriggerEvent();
	//	entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>(callBack));
	//	trigger.triggers.Add(entry);
	//}

	//Add a new event trigger with the paramaters that are required for up and down.

	//YouTube this so that it works. https://answers.unity.com/questions/1411148/add-event-trigger-parameters-using-c.html

	public void Update()
	{
		//if (PlayerRigidbody == null)
		//{
		//	PlayerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();
		//}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (player.IsTouchingEnviroment == true)
		{ 
			tap++;

			if (tap == 1)
			{
				StartCoroutine(DoubleTapInterval());
			}

			else if (tap > 1 && readyForDoubleTap)
			{
				isJumpPressed = true;
				PlayerAnimator.SetBool("IsJumping", true);
				PlayerRigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
				PlayerAnimator.SetBool("IsJumping", false);
				tap = 0;
				readyForDoubleTap = false;
			}	
		}
	}

	IEnumerator DoubleTapInterval()
	{
		yield return new WaitForSeconds(0.01f);
		readyForDoubleTap = true;
	}
}
