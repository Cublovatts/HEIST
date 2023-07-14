using UnityEngine;

public class PatrollingState : IState
{
    private Enemy _enemy;

    public PatrollingState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Execute()
    {
     
    }

    public IState CheckTransitions()
    {
        if (_enemy.Detection.GetCurrentDetectionLevel() > 50f)
        {
            return new InvestigatingState(_enemy);
        }

        return this;
    }

    public void Enter()
    {
        _enemy.PatrolSequence.enabled = true;
        _enemy.MeshRenderer.material.color = Color.green;
        _enemy.NavMeshAgent.speed = _enemy.PatrolSpeed;
    }

    public void Exit()
    {
        _enemy.PatrolSequence.enabled = false;
    }
}
