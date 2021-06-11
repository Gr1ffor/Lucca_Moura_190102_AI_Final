using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class Fugir : MonoBehaviour
{
    public float EnemyDistanceRun = 4f;
    public Transform player;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < EnemyDistanceRun)
        {
            Vector3 dirToPlayer = player.transform.position - transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            agent.SetDestination(newPos);
            agent.speed = 15;
        }
    }
}
