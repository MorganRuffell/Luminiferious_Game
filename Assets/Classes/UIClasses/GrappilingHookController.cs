using UnityEngine;
using UnityEngine.UI;
using Luminfiarious.UI;
using Luminfiarious.Character;

namespace Luminfiarious.Gameplay
{
	[DisallowMultipleComponent]
	public class GrappilingHookController : MonoBehaviour
	{
		#region GrappilingHookVariables

			private LineRenderer lr;
			private Vector3 grapplePoint;

			[Tooltip("This is the objects, marked by inspector layers what we can grapple to")]
			public LayerMask WhatCanWeGrappleTo;

			[SerializeField]
			[Range(0, 999), Tooltip("This is how long it takes for the firing animation for the grapple takes.")]
			private float GrappleAnimationTime = 0;

			[Header("Grappiling Hook Origin & Distance")]

			[Tooltip("This is the location of where the grappiling hook originates from.")]
			public Transform GrappilingHookOrigin;
			public Transform player;

			[HideInInspector]
			public static bool bIsPlayerSwinging = false;

			[Tooltip("This is the camera that we are going to use, in this instance it is the main camera.")]
			public Transform camera;

			[SerializeField]
			[Range(30, 999), Tooltip("This is the maximum distance that we can grapple too.")]
			private float maxDistance = 100.0f;

			[Header("Grappiling Hook Spring Joint")]

			public float JointSpringVal = 2.5f;
			public float JointDamperVal = 5.0f;
			public float JointMassScale = 7.0f;

			private SpringJoint Joint;


		#endregion

		private void Awake()
		{
			lr = GetComponent<LineRenderer>();
			
			
		}

		public void Update()
		{
			if (Luminfiarious.Manager.GameManager.gameManager.IsGunSelected == false)
			{
				if (Input.GetMouseButtonDown(0))
				{
					Invoke("StartGrapple", GrappleAnimationTime);
				}	
		
				else if (Input.GetMouseButtonUp(0))
				{
					StopGrapple();
					bIsPlayerSwinging = false;
				}

				return;
			}


		}

		private void LateUpdate()
		{
			if (bIsPlayerSwinging == true)
			{
				DrawRope();
			}
		}

		//Call this method when we are starting the grapple and the Grappiling hook has been unlocked.
		public void StartGrapple()
		{

			RaycastHit GrappleHit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out GrappleHit, maxDistance, WhatCanWeGrappleTo))
			{
				grapplePoint = GrappleHit.point;
				Joint = player.gameObject.AddComponent<SpringJoint>();
				Joint.autoConfigureConnectedAnchor = false;
				Joint.connectedAnchor = grapplePoint;

				float distanceFromPoint = Vector3.Distance(a: player.position, b: grapplePoint);

				//The distance grapple will try to keep from grapple point.
				Joint.maxDistance = distanceFromPoint * 0.0f;
				Joint.minDistance = distanceFromPoint + 0.0f;

				//Change these values to fit the game, I'll make these floats publically editable. 
				Joint.spring = JointSpringVal;
				Joint.damper = JointDamperVal;
				Joint.massScale = JointMassScale;

				bIsPlayerSwinging = true;

				lr.positionCount = 2;

			}
			
		}

		void DrawRope()
		{
			//if not grappiling don't draw rope.
			if (!Joint)
			{
				return;
			}

			lr.SetPosition(index: 0, GrappilingHookOrigin.position);
			lr.SetPosition(index: 1, grapplePoint);
			
		}


		//Call this method when we are stopping the  grapple and the Grappiling hook has been unlocked.
		void StopGrapple()
		{
			bIsPlayerSwinging = false;
			lr.positionCount = 0;
			Destroy(Joint);

		}

		//Still buggy, needs more swing direction?
		//Also has issues with the swinging.

	}

}

