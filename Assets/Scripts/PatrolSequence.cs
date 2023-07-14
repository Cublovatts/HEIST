using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolSequence : MonoBehaviour
{
    public List<PatrolDestination> Destinations;
    public string CurrentDestinationName;

    private NavMeshAgent _navMeshAgent;
    private int _currentDestinationIndex = 0;
    private bool _isDelaying = false;
    private bool _atDestination = false;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        UpdateNavMeshDestination();
    }

    void Update()
    {
        if (_atDestination && !_isDelaying)
        {
            _isDelaying = true;
            StartCoroutine("IncrementDestinationAfterDelay", Destinations[_currentDestinationIndex].DelayAtDestination);
            _atDestination = false;
        }
    }

    public int GetCurrentDestinationIndex()
    {
        return _currentDestinationIndex;
    }

    public NavMeshAgent GetNavMeshAgent()
    {
        return _navMeshAgent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == CurrentDestinationName)
        {
            _atDestination = true;
        }
    }

    private bool IsAtDestination()
    {
        if (GetPathRemainingDistance() > 2.0f)
        {
            return false;     
        } else
        {
            return true;
        }
    }

    private void UpdateNavMeshDestination()
    {
        _navMeshAgent.destination = Destinations[_currentDestinationIndex].Destination.position;
        CurrentDestinationName = Destinations[_currentDestinationIndex].Destination.name;
    }

    private float GetPathRemainingDistance()
    {
        if (_navMeshAgent.pathPending ||
            _navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid ||
            _navMeshAgent.path.corners.Length == 0)
            return -1f;

        float distance = 0.0f;
        for (int i = 0; i < _navMeshAgent.path.corners.Length - 1; ++i)
        {
            distance += Vector3.Distance(_navMeshAgent.path.corners[i], _navMeshAgent.path.corners[i + 1]);
        }

        return distance;
    }

    IEnumerator IncrementDestinationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _currentDestinationIndex++;
        if (_currentDestinationIndex > Destinations.Count - 1) _currentDestinationIndex = 0;
        _isDelaying = false;
        UpdateNavMeshDestination();
    }
}

