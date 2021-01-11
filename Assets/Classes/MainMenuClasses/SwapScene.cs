using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Luminfiarious.Manager
{
    [RequireComponent(typeof(Button))]
    public class SwapScene : MonoBehaviour
    {
        //Write the name of the scene in here and when you want to load it, 
        //Click on it and it will load it!
        public string SceneToLoad;


        //OnClick method, when the object is clicked it will perform the contents of this method.
        public void OnClick()
        {
            SceneManager.LoadScene(SceneToLoad);
		}
        
	}

}

