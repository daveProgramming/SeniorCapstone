using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public enum MusicState {explore, lightCombat, mediumCombat,  heavyCombat, death, bossSpawn, wait }


public class MusicStateManager : MonoBehaviour {

    public MusicState currentState, previousState;

    private EnemyManager em;
    public GameObject[] enemyArray;
    public List<GameObject> enemies;
    public List<GameObject> engagedEnemies;
    public float lightAmountEnemies, mediumAmountEnemies, heavyAmountEnemies, soundDistanceTrigger;
    float amountEngaged;

	void Start () {

        em = FindObjectOfType<EnemyManager>();
        currentState = MusicState.explore;
        LoadEnemies(); //Will need to change based on how the enemies are loaded
        amountEngaged = 0;

    }
	
	// Update is called once per frame
	void Update () {

        
        
        switch (currentState)
        {
            case MusicState.explore:
                AkSoundEngine.SetState("combatMusic", "exploration");
                previousState = MusicState.explore;
                currentState = MusicState.wait;
                break;
            case MusicState.lightCombat:
                AkSoundEngine.SetState("combatMusic", "light");
                previousState = MusicState.lightCombat;
                currentState = MusicState.wait;
                break;
            case MusicState.mediumCombat:
                AkSoundEngine.SetState("combatMusic", "medium");
                previousState = MusicState.mediumCombat;
                currentState = MusicState.wait;
                break;
            case MusicState.heavyCombat:
                AkSoundEngine.SetState("combatMusic", "heavy");
                previousState = MusicState.heavyCombat;
                currentState = MusicState.wait;
                break;
            case MusicState.death:
                AkSoundEngine.SetState("combatMusic", "death");
                previousState = MusicState.death;
                currentState = MusicState.wait;
                break;
            case MusicState.bossSpawn:
                AkSoundEngine.SetState("combatMusic", "bossSpawn");
                previousState = MusicState.bossSpawn;
                currentState = MusicState.wait;
                break;
            case MusicState.wait:
               
                CheckEngagedEnemies();
                SetCombatMusic();
                break;
            default:
                break;
        }
    }
    public void LoadEnemies()
    {
        //for (int i = 0; i < em.enemies.Count; i++)
        //{
        //    enemies.Add(em.enemies[i]);
        //}

        foreach (EnemyMeleeBehaviour enemy in FindObjectsOfType<EnemyMeleeBehaviour>())
        {
            enemies.Add(enemy.gameObject);
        }
        
    }
    void CheckEngagedEnemies()
    {
        foreach (var e in enemies)
        {
            if(e.GetComponent<HealthManager>().currentLivingState == HealthManager.LivingState.Alive && e.GetComponent<WanderBehaviour>().playerToEnemy.magnitude < soundDistanceTrigger)
            {
                if (!engagedEnemies.Contains(e))
                {
                    engagedEnemies.Add(e);
                }
                
            }
            else
            {
                engagedEnemies.Remove(e);
            }
        }
    }
    void SetCombatMusic()
    {

        if(engagedEnemies.Count == lightAmountEnemies)
        {
            currentState = MusicState.lightCombat;
        }
        else if (engagedEnemies.Count == mediumAmountEnemies)
        {
            currentState = MusicState.mediumCombat;
        }
        else if (engagedEnemies.Count >= heavyAmountEnemies)
        {
            currentState = MusicState.heavyCombat;
        }
        else
        {
            currentState = MusicState.explore;
        }
    }
   

  
}
