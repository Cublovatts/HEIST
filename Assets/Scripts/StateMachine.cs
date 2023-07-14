using System;

[Serializable]
public class StateMachine
{
    public string CurrentStateName;

    private IState _currentState;

    public StateMachine(IState currentState)
    {
        ChangeState(currentState);
    }

    public void ChangeState(IState newState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = newState;
        CurrentStateName = newState.GetType().Name;
        _currentState.Enter();
    }

    public void Update()
    {
        if (_currentState != null)
        {
            _currentState.Execute();
            if (_currentState.CheckTransitions() != _currentState)
            {
                ChangeState(_currentState.CheckTransitions());
            }
        }
    }
}
