using System;
using System.Collections;
using System.Collections.Generic;
using Luminfiarious.Gameplay;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Luminfiarious.Character
{
	[RequireComponent(typeof(PlayerFiringController))]
	[DisallowMultipleComponent]
	public class PlayerControllerScript : MonoBehaviour
	{
		[Header("Player Scriptable Object")]
		PlayerScriptableObjects PlayerAttr;

		#region CharacterAttrVariables
		private Vector3 velocity;

		[Header("Jump and animation public variables")]
		public float WalkSpeed = 6.0f;
		public int WalkSpeedMultiplier = 3;
		public const float JumpPower = 50;
		public const float AnimationTurnSpeed = 0f;
		public const float ToolSwapAnimationDelay = 0.0f;

		[HideInInspector]
		public bool IsTouchingEnviroment = true;
		private bool IsHeld = false;

		[HideInInspector]
		public float uiButtonAxis = 0.0f;

		[HideInInspector]
		public Rigidbody PlayerRigidbody;
		public Animator PlayerAnimator;
		private CapsuleCollider PlayerCollider;
		[Space]
		
		[HideInInspector]
		public bool bcanClimb;
		public bool IsPlayerJumping;
		public bool bIsPlayerClimbing;
		public LayerMask EnviromentLayers;


		[Header("Character Animation Attributes")]
		public float CharacterMovementSpeed;
		public float WalkTrigger;
		public float RunTrigger;

		private List<string> playerAnimations;		

		public bool left = false;
		public bool right = false;


		
		//If you have a dictionary where the key is an int. just make this a list.
		//Run a modulo operator 10 % 10 = 0;

		public Dictionary<int, string> CurrentlySelectedTool = new Dictionary<int, string>()
		{
			{ 0, "Grapple" },
			//Refactor the handgun into becoming a pickup once he touches some ammo
			//{ 1, "Handgun" }
		};

		#endregion

		private void Awake()
		{
			CurrentlySelectedTool.ContainsKey(0);
			PlayerRigidbody = GetComponent<Rigidbody>();
			SetupAnimation();
		}

		private void SetupAnimation()
		{
			//PlayerAnimator = GetComponent<Animator>();

			playerAnimations = new List<string>()
			{
				"Walking",
				"Idle",
				"Jumping",
				"Falling",
				"Dead",
				"Climbing",
			};

		}

		private void Update()
		{
			//Refactor the movement so that it works with the On Screen Controls
			if (Input.GetKeyDown(KeyCode.LeftShift))
			{
				WalkSpeed = WalkSpeed * WalkSpeedMultiplier;
			}

			if (Input.GetKeyUp(KeyCode.LeftShift))
			{
				WalkSpeed = WalkSpeed / WalkSpeedMultiplier;
			}

			if (bcanClimb)
			{
				PlayerRigidbody.AddForce(Vector3.up * uiButtonAxis, ForceMode.Impulse);
				
			}

			if (bIsPlayerClimbing)
			{
				PlayerRigidbody.AddForce(Vector3.up * uiButtonAxis, ForceMode.Impulse);
			}
		}

		private void FixedUpdate()
		{
			Move(uiButtonAxis);
		}

		private void Move(float horizontal)
		{
			
			velocity.Set(horizontal, 0.0f, 0.0f);
			velocity = velocity.normalized * WalkSpeed * Time.deltaTime;
			PlayerRigidbody.MovePosition(PlayerRigidbody.position + velocity);

			if (velocity.magnitude > WalkTrigger)
			{
				//PlayerRigidbody.MoveRotation()
				PlayerAnimator.SetBool("Walking", true);
			}
			else
			{
				PlayerAnimator.SetBool("Walking", false);
			}
		}

		#region Player Movement IEnums - Works with the WASD Controls

		private IEnumerator PlayerRightMovement(float AnimationTurnSpeed)
		{
			transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
			yield return new WaitForSeconds(AnimationTurnSpeed);
		}
		private IEnumerator PlayerLeftMovement(float AnimationTurnSpeed)
		{
			transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
			yield return new WaitForSeconds(AnimationTurnSpeed);
		}

		#endregion


		#region ToolSwap

		private IEnumerator ToolSwap(float ToolSwapAnimationDelay)
		{
			// Check to see if the tool has been swapped before

			// If it hasn't add handgun into the dictionary

			// Change the value to handgun

			// if the selected tool is handgun 

			// Swap to grapplehook

			// else if the selected tool is grapple hook

			// Swap to handgun

			yield return new WaitForSeconds(ToolSwapAnimationDelay);
		}



		#endregion

		//These two on collision checks are used for ensuring that the player cannot double jump.
		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.tag == "Enviroment")
			{
				IsTouchingEnviroment = true;
				PlayerAnimator.SetBool("IsFalling", false);
			}

		}

		private void OnCollisionExit(Collision collision)
		{
			if (collision.gameObject.tag == "Enviroment")
			{
				IsTouchingEnviroment = false;
				PlayerAnimator.SetBool("IsFalling", true);
			}
		}

		public void OnUILeftDown()
		{
			IsHeld = true;
			left = true;
			PlayerAnimator.SetTrigger("IsWalking");
			uiButtonAxis = -1.0f;
			StartCoroutine(PlayerLeftMovement(AnimationTurnSpeed));
			Move(uiButtonAxis);
		}

		public void OnUILeftUp()
		{
			IsHeld = false;
			left = false;
			uiButtonAxis = 0.0f;
		}


		public void OnUIRightDown()
		{
			IsHeld = true;
			right = true;
			PlayerAnimator.SetTrigger("IsWalking");
			uiButtonAxis = 1.0f;
			StartCoroutine(PlayerRightMovement(AnimationTurnSpeed));
			Move(uiButtonAxis);

		}

		public void OnUIRightUp()
		{
			IsHeld = false;
			right = false;
			uiButtonAxis = 0.0f;
		}
	}
}










