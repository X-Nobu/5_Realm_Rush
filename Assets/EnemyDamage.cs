using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    [SerializeField] int hitPoints = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnParticleCollision(GameObject other)
    {
        
        ProcessHit();
        if (hitPoints <= 1)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        print("current hitpoints are " + hitPoints);
    }
}
