using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePatrolScript : MonoBehaviour
{
    private PatrolSequence _patrolSequence;

    void Start()
    {
        _patrolSequence = GetComponent<PatrolSequence>();
    }

    public void Activate()
    {
        _patrolSequence.enabled = true;
    }
}
