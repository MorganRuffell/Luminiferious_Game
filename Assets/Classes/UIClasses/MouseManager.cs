using System.Collections;
using System.Collections.Generic;
using Luminfiarious.Cameras;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Luminfiarious.UI
{
	[RequireComponent(typeof(CameraController))]
	public class MouseManager : MonoBehaviour
	{
		#region TexturesForMouse

		[Header("Target Textures")]

		public Texture2D BaseTextureForMouse;
		[Space]
		public Texture2D ShootingReticleTexture;
		[Space]
		public Texture2D GrappilingHookTexture;
		[Space]

		[Range(16, 180), Tooltip("This is the size of the reticle, tweak this if you want your images to look bigger. They are not UI elements, and cannot be teaked manually.")]
		public int CursorSizeInt = 16;

		[HideInInspector]
		public static bool bCanFire = false;

		#endregion

		private PhysicsRaycaster physicsRaycaster;

		public bool GrappilingHook = true;

		public LayerMask ClickableLayer;

		void Update()
		{
			bCanFire = false;

			//Refactor this to include the instantiation of variables on mouse down.

			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, ClickableLayer.value))
			{
				if (hit.collider.gameObject.tag == "Enemy")
				{
					Cursor.SetCursor(GrappilingHookTexture, new Vector2(CursorSizeInt, CursorSizeInt), CursorMode.Auto);
					StartCoroutine(Shooting());
				}

				if (hit.collider.gameObject.tag == "Enviroment")
				{ 
					if (GrappilingHook == true)
					{
						Cursor.SetCursor(GrappilingHookTexture, new Vector2(CursorSizeInt, CursorSizeInt), CursorMode.Auto);
						Debug.Log("Hit Enviroment");
						return;
					}

					else
					{	
						StartCoroutine(Shooting());
					}
				}

				else
				{
					Cursor.SetCursor(BaseTextureForMouse, new Vector2(CursorSizeInt, CursorSizeInt), CursorMode.Auto);
				}

			}

			else
			{
				Cursor.SetCursor(BaseTextureForMouse, new Vector2(CursorSizeInt, CursorSizeInt), CursorMode.Auto);
			}

		}

		private IEnumerator Shooting()
		{
			Cursor.SetCursor(ShootingReticleTexture, new Vector2(CursorSizeInt, CursorSizeInt), CursorMode.Auto);
			bCanFire = true;
			
			yield return new WaitForSeconds(0.5f);
		}

    }

}
