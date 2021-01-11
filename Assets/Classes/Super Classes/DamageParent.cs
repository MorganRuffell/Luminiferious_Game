using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luminfiarious.Supers
{
    public abstract class DamageParent : MonoBehaviour
    {
        /*This is an interface, it contains variables and methods that must be implemented in derieved classes
        This is sorted into the.supers namespace meaning that this code belongs to a collection of classes
        That contain variables that are used in almost all facets of the game and therefore I want concrete
        implementation*/


        //Fuck I did this wrong!


        //DamageParent contains the damage float, which is used across scripts that infict damage on the player. 

        [HideInInspector]
        protected float Damage;

		//Luke would reccomedn that you do this as an individal event.

    }
}



