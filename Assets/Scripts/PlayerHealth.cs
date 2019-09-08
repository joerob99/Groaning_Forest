using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;
    [SerializeField] TextMeshProUGUI healthText;

    private float playerHealthMax;
    private void Start() { playerHealthMax = playerHealth; }

    public void LoseHealth(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0f) { GetComponent<DeathHandler>().HandleDeath(); }
    }

    public void HealHealth(float heal)
    {
        if ((playerHealth + heal) >= playerHealthMax) { playerHealth = playerHealthMax; }
        else { playerHealth += heal; }
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
