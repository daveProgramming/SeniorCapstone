using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour {

	public GameObject panel;
    private GameObject[] UI;
    //private GameObject[] UIText;

    public GameObject[] UISettings;


    public InputHandler ih;
    //public int controllerSchemeNumber;

    private GameObject[] splashDamages;
    //private List<SplashDuration> sDuration;
    Player playerScript;

    PlayerAnimatorController playerAnimatorController;


    public bool wasPlayerHealingBeforePause;
	public bool isPaused;

    EventSystem es;
    private GameObject settingsCanvas;
    private GameObject pauseCanvas;

	void Awake()
	{
        es = FindObjectOfType<EventSystem>();
        playerScript = FindObjectOfType<Player>();

        ih = GameObject.Find("Player_Weapon").GetComponent<InputHandler>();

        panel = transform.GetChild(0).gameObject;

        pauseCanvas = GameObject.FindGameObjectWithTag("PauseCanvas");
        //settingsCanvas = GameObject.FindGameObjectWithTag("SettingsCanvas");
	    UI = GameObject.FindGameObjectsWithTag("PauseUI");
	    //UIText = GameObject.FindGameObjectsWithTag("PauseUIText");
        UISettings = GameObject.FindGameObjectsWithTag("UISettings");

	}

	void Start ()
	{        
        isPaused = false;
        //controllerSchemeNumber = (int)ih.controlScheme;
	}
	
	void Update () 
	{
        if (Input.GetButtonDown(ih.inputID + "Submit") && !isPaused)
        {
 
            Pause();
        }
        else if (Input.GetButtonDown(ih.inputID + "Submit") && isPaused) 
	    {
            Resume();
            ToggleUISettings(false);
		}
	}
    void LateUpdate()
    {
        if (isPaused)
        {
            Time.timeScale = 0f; 
        }
        
    }

    public void Pause()
    {
        //es.SetSelectedGameObject(pauseCanvas);
        ih.enabled = false;
        isPaused = true;
        //HandleSplashDamages(false);
        panel.GetComponent<Image>().enabled = true;
       
        panel.transform.GetChild(0).GetComponent<Image>().enabled = true;
        panel.transform.GetChild(1).gameObject.SetActive(true);
        ToggleUI(true);
        wasPlayerHealingBeforePause = playerScript.healOnSit;
        playerScript.enabled = false;
    }
    public void Resume()
    {
        
        ToggleUI(false);
        //find all splash damages and pause them
        //HandleSplashDamages(true);
        //sDuration.Clear();
        playerScript.enabled = true;
        if (wasPlayerHealingBeforePause == true)
        {
            playerScript.healOnSit = true;
        }

        panel.GetComponent<Image>().enabled = false;
        panel.transform.GetChild(0).GetComponent<Image>().enabled = false;
        panel.transform.GetChild(1).gameObject.SetActive(false);
        isPaused = false;
        ih.enabled = true;
        Time.timeScale = 1f;
    }
    public void QuitToMainMenu()
    {
        ToggleUI(false);
        //find all splash damages and pause them
        //HandleSplashDamages(true);
        //sDuration.Clear();
        playerScript.enabled = true;
        if (wasPlayerHealingBeforePause == true)
        {
            playerScript.healOnSit = true;
        }

        panel.GetComponent<Image>().enabled = false;
        panel.transform.GetChild(0).GetComponent<Image>().enabled = false;
        isPaused = false;
        ih.enabled = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void LoadSettings()
    {
        //es.SetSelectedGameObject(settingsCanvas);
        ToggleUI(false);
        ToggleUISettings(true);
    }
    public void Back()
    {
        es.SetSelectedGameObject(pauseCanvas);
        ToggleUISettings(false);
        ToggleUI(true);
    }

    public void HandleSplashDamages(bool value)
    {
        //splashDamages = GameObject.FindGameObjectsWithTag("SplashDamage");
        //int i = 0;
        //if (splashDamages.Length != 0)
        //{
        //    foreach (GameObject og in splashDamages)
        //    {
        //        //sDuration.Add(og.GetComponent<SplashDuration>());
        //        //if (sDuration.Count != 0)
        //        //{
        //        //    sDuration[i].enabled = value;
        //        //    i++;
        //        //}
        //    }
        //}
        //Array.Clear(splashDamages, 0, splashDamages.Length);
    }


    //Helper classes, Should abstract further
    void ToggleUI(bool toggleValue)
    {
        foreach (GameObject g in UI)
        {
            g.GetComponent<Image>().enabled = toggleValue;
            if (g.GetComponent<Button>())
            {
                g.GetComponent<Button>().enabled = toggleValue;
            }
        }
    
    }
    void ToggleUISettings(bool toggleValue)
    {
        
        foreach (GameObject g in UISettings)
        {
            if (g.GetComponent<Image>())
            {
                g.GetComponent<Image>().enabled = toggleValue;
            }
            
            if (g.GetComponent<Button>())
            {
                g.GetComponent<Button>().enabled = toggleValue;
            }
        }
       
        
    }

}
