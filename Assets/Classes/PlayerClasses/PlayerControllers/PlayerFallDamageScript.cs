using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminfiarious.Gameplay;
using Luminfiarious.Supers;

namespace Luminfiarious.Character
{
    [RequireComponent(typeof(healthScript))]
	[RequireComponent(typeof(PlayerControllerScript))]
    public class PlayerFallDamageScript : DamageParent
    {
		[Header("Player Scriptable Object")]
		PlayerScriptableObjects PlayerAttr;

		public JumpInteraction jump;

        #region Player Fall Damage Attr.

			[Header("Jump and animation public variables")]

			[Range(1, 600)]
			[Tooltip("This is the amount of fall distance that is allowed")]
			public int FallDistanceAllowed = 1;
			//public float MaximumTime = 10.0f;

			private float fallDistance;

			private float time = 0.0f;

			[SerializeField]
			public float DamageInflicted = 10.0f;

			[Space]
			[Space]

			[SerializeField]
			private Rigidbody PlayerRigidbody;

        #endregion

        private bool isMoving = false;

        public PlayerControllerScript controllerScript;
        public healthScript PlayerHealthScript;

        private void Awake()
        {
			//FallDistanceAllowed = PlayerAttr.FallDistanceAllowed;
			//DamageInflicted = PlayerAttr.DamageInflicted;
        }

		private void Start()
		{
            PlayerRigidbody = GetComponent<Rigidbody>();
            fallDistance = 0;
		}

		private void Update()
        {
            if (GrappilingHookController.bIsPlayerSwinging == false)
            {
                if (jump.isJumpPressed == true)
                {
                    isMoving = true;
                }

                if (isMoving == true)
                {
                    time = time + Time.fixedDeltaTime;

                    fallDistance = fallDistance + 1;
                    //Debug.Log("FallDistance Value is " + fallDistance);
                }

            }

            else
            {
                //Logic for if the player is swinging.
            }

        }

        //Still WIP
        private void OnCollisionEnter(Collision collision)
        {
            isMoving = false;

            if (collision.gameObject.tag == "Enviroment")
            {
                if (fallDistance > FallDistanceAllowed)
                {
                    fallDistance = 0;
                    gameObject.GetComponent<healthScript>().TakeDamage((int)DamageInflicted);
                }

                else
                {
                    fallDistance = 0;
                }
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            fallDistance = 0;
        }
    }
}
