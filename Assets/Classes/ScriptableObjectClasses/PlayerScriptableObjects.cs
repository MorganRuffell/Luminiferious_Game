using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luminfiarious.Character
{
	[CreateAssetMenu(fileName = "Player Attribute Instance", menuName = "ScriptableObjects/PlayerScriptableObject", order = 1)]
	public class PlayerScriptableObjects : ScriptableObject
	{
		[Header("Player Health Variables")]

		[Range(0, 500), Tooltip("The players current health")]
		public Int16 PlayerCurrentHealth;
		[Range(0, 500), Tooltip("The players Maximum health")]
		public Int16 PlayerMaximumHealth;

		[Space]

		[Range(0, 30), Tooltip("This is how long the players body will hang around before it is removed.")]
		public float DeathTime = 6.0f;

		[Header("Jump and animation public variables")]
		public float WalkSpeed = 6.0f;
		public float WalkSpeedMultiplier = 3.0f;
		public const float JumpPower = 7;
		public const float AnimationTurnSpeed = 0.25f;

		[Header("Fall Distance Attributes")]

		[Tooltip("This is the amount of damage that ")]
		public float DamageInflicted = 10.0f;

		[Range(1, 600)]
		[Tooltip("This is the amount of fall distance that is allowed")]
		public Int16 FallDistanceAllowed = 1;
	}
}


