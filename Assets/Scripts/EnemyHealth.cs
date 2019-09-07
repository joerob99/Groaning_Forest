using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] [Range(1f, 14f)] float minMoanWait = 13f;
    [SerializeField] [Range(15f, 30f)] float maxMoanWait = 25f;
    [SerializeField] AudioClip moan;
    [SerializeField] AudioClip dying;
    [SerializeField] AudioClip inPain;
    private AudioSource source;
    bool isDead = false;
    float waitMoan;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        waitMoan = UnityEngine.Random.Range(minMoanWait, maxMoanWait);
        Invoke("Moan", waitMoan);
    }

    private void Moan() // Intermittent ambient moaning from zombies
    {
        if (isDead) { return; }
        source.PlayOneShot(moan);
        waitMoan = UnityEngine.Random.Range(minMoanWait, maxMoanWait);
        Invoke("Moan", waitMoan);
    }

    public bool IsDead() { return isDead; }

    public void TakeDamage(float damage)
    {
        if (isDead) { return; }
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        source.PlayOneShot(inPain);
        if (hitPoints <= 0f) { Die(); }
    }

    private void Die()
    {
        if (isDead) { return; }
        isDead = true;
        source.PlayOneShot(dying);
        GetComponent<Animator>().SetTrigger("die");
    }
}
