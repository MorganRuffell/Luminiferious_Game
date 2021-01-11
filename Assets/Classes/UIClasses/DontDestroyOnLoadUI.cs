using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DontDestroyOnLoadUI : MonoBehaviour
{
	//Mark anything that refers to itself inside of a singleton, static.
	//This is because statics exist for an entire program lifetime.
	public static DontDestroyOnLoadUI UIinstance;

	public JumpInteraction jump;

    void Start()
    {
		if (UIinstance == null)
		{
			DontDestroyOnLoad(this);
			UIinstance = this;
		}
		else if (UIinstance != this)
		{
			Destroy(gameObject);
		}

		//Instead of the jump interaction having a manual approach, you need to 
		//Allow the player to set the reference on the JumpInteraction class itself through this?

		// If you follow this path...
		//Every single reference you would have to re-reference. You would have to have all of the object dependecies in one method 
		//

		GetDependencies();
    }

	void GetDependencies()
	{
		//Reassign both classes to the pointer events
		// Left and right

	}


    void Update()
    {
        
    }
}
