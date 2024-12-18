using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    float health = 100;
    public GameObject player;
    public void reduceHealth(float damage) 
    {
        health -= damage;
    }

    void Update()
    {
        if (health <= 0) 
        {
            Destroy(player);
        }    
    }
}
