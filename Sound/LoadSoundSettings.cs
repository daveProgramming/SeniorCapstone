using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSoundSettings : MonoBehaviour {

    public float volumeSliderValue;
    public float sfxSliderValue;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        volumeSliderValue = 1;
        sfxSliderValue = 1;
        
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetSoundVariables()
    {
        volumeSliderValue = GameObject.Find("Music Volume Slider").transform.GetComponent<Slider>().value;
        sfxSliderValue = GameObject.Find("SFX Volume Slider").transform.GetComponent<Slider>().value;
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "_GDC_Level_Official")
        {
            GameObject.Find("Music Volume Slider").transform.GetComponent<Slider>().value = volumeSliderValue;
            GameObject.Find("SFX Volume Slider").transform.GetComponent<Slider>().value = sfxSliderValue;
        }
    }
    
}
