using UnityEngine;
using System.Collections;

public class UniversalSoundCollision : MonoBehaviour {


    public string playOnceAudio = "";
    public string tagOfObjectCollidingWith = "";
	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == tagOfObjectCollidingWith)
        {
            AkSoundEngine.PostEvent(playOnceAudio, gameObject);
        }
    }
}
