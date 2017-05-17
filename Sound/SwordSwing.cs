using UnityEngine;
using System.Collections;

public class SwordSwing : MonoBehaviour {

    // Use this for initialization
    
    Player player;

	void Start () {
        player = FindObjectOfType<Player>();
	}

    // Update is called once per frame
    void Update()
    {
        if (player.currentActionState == Player.ActionState.MeleeAttack)
        {
            AkSoundEngine.PostEvent("swordSwing", gameObject);
            AkSoundEngine.PostEvent("playGrunt", gameObject);
        }
    



	}
}
