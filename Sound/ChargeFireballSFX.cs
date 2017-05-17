using UnityEngine;
using System.Collections;

public class ChargeFireballSFX : MonoBehaviour {

    private SoundManager sm;
    private Player p;
    bool hasStarted;
	// Use this for initialization
    void Awake()
    {
        p = GameObject.Find("Player_Weapon").transform.GetComponent<Player>();
        sm = GameObject.Find("SoundManager").transform.GetComponent<SoundManager>();
    }
	void Start () {
        hasStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (p.currentActionState == Player.ActionState.EnterRangedAttack)
        {
            if (!hasStarted)
            {
                AkSoundEngine.PostEvent("fireballCharge", gameObject);
                hasStarted = true;
            }
            
            AkSoundEngine.SetRTPCValue("fireballCharge", p.chargingTime);
        }
        if(p.previousActionState == Player.ActionState.EnterRangedAttack)
        {
            sm.StopEvent("fireballCharge", 0);
            hasStarted = false;
        }
   
	}
}
