using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float speed = 3.5f;

    [SerializeField]
    [Tooltip("How quickly this enemy can turn")]
    float turnSpeed = 5;

    [SerializeField]
    [Tooltip("The max distance the target can be and still be chased by this enemy")]
    float chaseRange = 10;

    private NavMeshAgent navMeshAgent;
    private float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false;

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;   
        Gizmos.DrawWireSphere(transform.position, chaseRange);    
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }

        if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;   
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void AttackTarget()
    {
        Debug.Log("attacking!!!");
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void EngageTarget()
    {
        FaceTarget();
        
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget < navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
