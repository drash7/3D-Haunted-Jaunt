using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    private NavMeshAgent navMeshAgent;

    private int _currentIndex = 0;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    private void Update()
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            _currentIndex += 1;
            if (_currentIndex == waypoints.Length)
                _currentIndex = 0;
            navMeshAgent.SetDestination(waypoints[_currentIndex].position);
        }
    }
}
