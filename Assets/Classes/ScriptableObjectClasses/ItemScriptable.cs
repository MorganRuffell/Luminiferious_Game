using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Luminfiarious.Gameplay
{ 
	[CreateAssetMenu(fileName = "InteractableItem", menuName = "InventoryItems/Items/HealthPickup")]
	public class ItemScriptable : ScriptableObject
	{
		public Int16 HealthValue = 10;
	
	}
	
}
