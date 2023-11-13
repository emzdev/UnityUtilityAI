using UnityEngine;

/// <summary>
///     base state class for AI FMS
/// </summary>
public abstract class State
{
    protected AIController _controller;

    public State(AIController controller)
    {
        this._controller = controller;
    }

    public virtual void OnStateEnter()
    {
        Debug.Log("Entering: " + GetType().Name);
    }
    public virtual void UpdateState() { }
    public virtual void OnStateExit() { }
}
