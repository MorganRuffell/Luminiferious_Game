using Luminfiarious.Character;
using UnityEngine;
using UnityEngine.UI;

namespace Luminfiarious.UI
{
    public class HealthBarScript : MonoBehaviour
    {
        public Image HealthBarImage;

        public float LerpSpeed;
    
        public healthScript HealthScript;

		private void Awake()
		{
			if (HealthScript == null)
			{
                HealthScript = GameObject.Find("Player").GetComponent<healthScript>();
			}

			HealthBarImage = GetComponent<Image>();
    
            HealthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<healthScript>();
			
		}
        // Update is called once per frame
        void Update()
        {
			if (HealthScript == null)
			{
				HealthScript = GameObject.Find("Player").GetComponent<healthScript>();
			}

			HealthBarImage.fillAmount = Mathf.Lerp(HealthBarImage.fillAmount, HealthScript.GetHealthPercentage(), Time.deltaTime * LerpSpeed);
        }
    }
}
