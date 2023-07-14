using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public MeshRenderer MeshRenderer;
    public PatrolSequence PatrolSequence;
    public Detection Detection;
    public NavMeshAgent NavMeshAgent;
    public Transform PlayerPosition;

    public float PatrolSpeed;
    public float InvestigateSpeed;
    public float PursueSpeed;

    [SerializeField]
    private StateMachine _stateMachine;

    void Start()
    {
        _stateMachine = new StateMachine(new PatrollingState(this));
    }

    void Update()
    {
        _stateMachine.Update();
    }
}

