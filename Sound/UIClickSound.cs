using UnityEngine;
using System.Collections;

public class UIClickSound : MonoBehaviour {

    public int fadeTimeSeconds = 1;
    public void onClick()
    {
        AkSoundEngine.PostEvent("uiClick", gameObject );
        
    }
    public void FadeTitleMusic()
    {
        AkSoundEngine.SetRTPCValue("titleMusicVolume", 0f, GameObject.FindGameObjectWithTag("TitleMusic"), fadeTimeSeconds * 1000);
    }

}
