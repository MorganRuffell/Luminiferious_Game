using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminfiarious.Character;


namespace Luminfiarious.Cameras
{
	[DisallowMultipleComponent]
	public class CameraController : MonoBehaviour
	{
		#region CameraController Variables

			public GameObject PlayerGameObject;
			[Space]
			[Space]
			private Vector3 CameraOffset;

		#endregion

		//Awake is called before start.
		private void Awake()
		{
			CameraOffset = transform.position - PlayerGameObject.transform.position;
		}

		private void LateUpdate()
		{
			transform.position = PlayerGameObject.transform.position + CameraOffset;
		}
	}
	
	
}
