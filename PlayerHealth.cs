using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool canDie = true;                  // Whether or not this health can die

    public static float startingHealth = 2000.0f;       // The amount of health to start with
    public static float maxHealth = 2000.0f;            // The maximum amount of health
    public static float currentHealth;                // The current ammount of health

    public bool replaceWhenDead = false;        // Whether or not a dead replacement should be instantiated.  (Useful for breaking/shattering/exploding effects)
    public GameObject deadReplacement;          // The prefab to instantiate when this GameObject dies
    public bool makeExplosion = false;          // Whether or not an explosion prefab should be instantiated
    public GameObject explosion;                // The explosion prefab to be instantiated

    public bool isPlayer = true;               // Whether or not this health is the player
    public GameObject deathCam;                 // The camera to activate when the player dies

    public static bool dead = false;                  // Used to make sure the Die() function isn't called twice

    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;
    }

    public void ChangeHealth(float amount)
    {
        currentHealth += amount;

        if (currentHealth <= 0 && !dead && canDie)
            Die();
        else if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0 && !dead && canDie)
            Die();
    }

    public void Die()
    {
        dead = true;

        if (replaceWhenDead)
            Instantiate(deadReplacement, transform.position, transform.rotation);
        if (makeExplosion)
            Instantiate(explosion, transform.position, transform.rotation);

        if (isPlayer && deathCam != null)
            deathCam.SetActive(true);
        Destroy(gameObject);
    }
}
