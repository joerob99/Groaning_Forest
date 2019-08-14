using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;
    [SerializeField] TextMeshProUGUI healthText;

    public void LoseHealth(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0f) { GetComponent<DeathHandler>().HandleDeath(); }
    }

    void Update()
    {
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        healthText.text = ((int) playerHealth).ToString();
    }
}
