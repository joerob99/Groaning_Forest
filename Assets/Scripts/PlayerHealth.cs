using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;

    public void LoseHealth(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0f) { GetComponent<DeathHandler>().HandleDeath(); }
    }
}
