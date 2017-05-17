using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class StartScreenManager : MonoBehaviour
{
    public float delayStartSeconds = 1f;

	InputHandler ih;

    public GameObject[] StartUI;
    public GameObject[] LoadUI;
    public GameObject[] OptionsUI;
    public GameObject[] UISliders;


	// Use this for initialization
	void Start () {
		ih = GetComponent<InputHandler> ();
        UISliders = GameObject.FindGameObjectsWithTag("UISettings");
        toggleSliders(false);
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetButtonDown("Submit")) 
        //{
        //    StartGame();
            
        //}
	}

    public void toggleSliders(bool value)
    {
        foreach (GameObject g in UISliders)
        {
            g.GetComponent<Image>().enabled = value;
        }
    }


    public void StartGame()
    {
        StartDelay();
        SceneManager.LoadScene(6);
    }
    public void CreditsScreen()
    {
        StartDelay();
        SceneManager.LoadScene(4);
    }
    public void ReturnToStartScreen()
    {
        StartDelay();
        SceneManager.LoadScene(0);
    }
    public IEnumerable StartDelay()
    {
        yield return new WaitForSeconds(delayStartSeconds);
        Time.timeScale = 1f;
        
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
    public void LoadGame()
    {
        StartDelay();
        //SceneManager.LoadScene(1);
        SaveManager.saveManager.Load();
        //SceneManager.LoadScene(1);
        //Time.timeScale = 1f;
    }
    public void LoadBack()
    {
        foreach (GameObject g in LoadUI)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in StartUI)
        {
            g.SetActive(true);
        }
    }
    public void Options()
    {
        foreach (GameObject g in StartUI)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in OptionsUI)
        {
            g.SetActive(true);
        }
   
        toggleSliders(true);
    }
    public void OptionsBack()
    {
        foreach (GameObject g in OptionsUI)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in StartUI)
        {
            g.SetActive(true);
        }

        toggleSliders(false);
    }
}
