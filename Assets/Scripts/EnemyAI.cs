using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 8f;
    //[SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;
    float distToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distToTarget <= chaseRange)
        {
            isProvoked = true;
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void EngageTarget()
    {
        if (distToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        transform.LookAt(target);
        GetComponent<Animator>().SetBool("attack", true);
    }

    //private void FaceTarget()
    //{
        //Vector3 direction = (target.position - target.position).normalized;
        //Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x + 0.001f, 0, direction.z));
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    //}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
