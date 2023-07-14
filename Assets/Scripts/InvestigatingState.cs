using UnityEngine;

public class InvestigatingState : IState
{
    private Enemy _enemy;

    public InvestigatingState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public IState CheckTransitions()
    {
        if (_enemy.Detection.GetCurrentDetectionLevel() < 1f)
        {
            return new PatrollingState(_enemy);
        }

        if (_enemy.Detection.GetCurrentDetectionLevel() > 99f)
        {
            return new PursuingState(_enemy);
        }

        return this;
    }

    public void Enter()
    {
        _enemy.NavMeshAgent.destination = _enemy.Detection.LastKnownPosition;
        _enemy.NavMeshAgent.isStopped = false;
        _enemy.NavMeshAgent.speed = _enemy.InvestigateSpeed;
        _enemy.MeshRenderer.material.color = Color.yellow;
    }

    public void Execute()
    {
        _enemy.NavMeshAgent.destination = _enemy.Detection.LastKnownPosition;
    }

    public void Exit()
    {
        
    }
}
