using System;
using System.Collections.Generic;
using UnityEngine;

namespace Luminfiarious.Gameplay
{
	//This interface will expand as the logic grows.
	public interface IItem
	{
		void Interact();
		//public void DestroyObject();
		void HandleCollisionEnter(Collider collidingObject);
		void HandleCollisionExit(Collider collidingObject);
		void DeBuff(short DebuffValue);
		void Buff(Int16 BuffValue);
		//public void DeBuff(Int16 DebuffValue);

	}
}