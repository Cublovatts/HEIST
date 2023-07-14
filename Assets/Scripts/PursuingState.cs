using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuingState : IState
{
    private Enemy _enemy;

    public PursuingState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public IState CheckTransitions()
    {
        if (_enemy.Detection.GetCurrentDetectionLevel() < 80f)
        {
            return new InvestigatingState(_enemy);
        }

        return this;
    }

    public void Enter()
    {
        _enemy.NavMeshAgent.speed = _enemy.PursueSpeed;
        _enemy.MeshRenderer.material.color = Color.red;
    }

    public void Execute()
    {
        _enemy.NavMeshAgent.destination = _enemy.PlayerPosition.position;
    }

    public void Exit()
    {
        
    }
}
