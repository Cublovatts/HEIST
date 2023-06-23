using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolSequence : MonoBehaviour
{
    public List<Transform> Destinations;
    public string CurrentDestinationName;

    private NavMeshAgent _navMeshAgent;
    private int _currentDestinationIndex = 0;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        _navMeshAgent.destination = Destinations[_currentDestinationIndex].position;
    }

    void Update()
    {
        if (IsAtDestination())
        {
            _currentDestinationIndex++;
            if (_currentDestinationIndex > Destinations.Count - 1) _currentDestinationIndex = 0;
        }

        _navMeshAgent.destination = Destinations[_currentDestinationIndex].position;
        CurrentDestinationName = Destinations[_currentDestinationIndex].name;
    }

    bool IsAtDestination()
    {
        if (_navMeshAgent.remainingDistance < 2.0f)
        {
            return true;     
        } else
        {
            return false;
        }
    }
}

