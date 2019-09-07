using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;
    [SerializeField] AudioClip bite;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null) { return; }
        source.PlayOneShot(bite); // Bite the player
        target.LoseHealth(damage);
        target.GetComponent<DisplayDamage>().ShowDamageSlash();
    }

}
