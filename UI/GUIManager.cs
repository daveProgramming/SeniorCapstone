using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {
    Image healthImg;
    Image staminaImg;
    HealthManager hm;
    StaminaManager sm;
    InventoryManager im;
    public Image tonaImg;
    public Text tonaTxt;

    public GameObject tutorialMove;
    public GameObject tutorialAttack;
    public GameObject NarrativeText1;
    // Use this for initialization
    void Awake()
    {
        hm = GameObject.Find("Player_Weapon").GetComponent<HealthManager>();
        sm = FindObjectOfType<StaminaManager>();
        im = FindObjectOfType<InventoryManager>();

        healthImg = this.gameObject.transform.GetChild(1).GetComponent<Image>();
        tonaImg = this.gameObject.transform.GetChild(2).GetComponent<Image>();
        tonaTxt = tonaImg.gameObject.transform.GetChild(0).GetComponent<Text>();
        staminaImg = this.gameObject.transform.GetChild(0).GetComponent<Image>();

        tonaImg.enabled = false;
        tonaTxt.enabled = false;

        tutorialMove.SetActive(false);
        tutorialAttack.SetActive(false);
        NarrativeText1.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        healthImg.fillAmount = hm.healthCurrent / 100;
        staminaImg.fillAmount = sm.staminaCurrent / 100;
        
        

        if(im.tonaAmt > 0)
        {
            tonaImg.enabled = true;
            tonaTxt.enabled = true;
            tonaTxt.text = "Tona x" + im.tonaAmt;

        }
        else
        {
            tonaImg.enabled = false;
            tonaTxt.enabled = false;
        }

}



    }
