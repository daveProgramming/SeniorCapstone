using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour 
{

    public Slider slider;
    public string soundForVolume = "";

    public void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void Update()
    {
        AkSoundEngine.SetRTPCValue(soundForVolume, slider.value);
    }

}
