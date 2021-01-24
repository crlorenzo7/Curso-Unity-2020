using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WayPointPatrol : MonoBehaviour
{
    // Start is called before the first frame update

    NavMeshAgent _navMeshAgent;

    public Transform[] wayPoints;

    int currentWaypointIndex = 0;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_navMeshAgent.destination == null)
        {
            _navMeshAgent.SetDestination(wayPoints[currentWaypointIndex].position);
        }

        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            currentWaypointIndex = CalculateNextWaypoint();
            _navMeshAgent.SetDestination(wayPoints[currentWaypointIndex].position);
        }
    }

    int CalculateNextWaypoint()
    {
        return (currentWaypointIndex + 1) % wayPoints.Length;
    }



}
