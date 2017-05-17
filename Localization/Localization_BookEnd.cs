using UnityEngine;
using System.Collections;

public class Localization_BookEnd : MonoBehaviour {

    int delay = 0;
    public int scene;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        BookendDelay();
        Debug.Log(" Delay = " + delay);
       
        
	}


void   BookendDelay()
    {
        if (delay <= 90){

            delay++;
        } if (delay >= 90)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
         
        }

    }
}
