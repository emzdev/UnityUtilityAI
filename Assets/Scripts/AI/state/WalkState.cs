using Unity.VisualScripting;
using UnityEngine;

public class WalkState : State
{
    public WalkState(AIController controller) : base(controller) { }

    public override void OnStateEnter()
    {
        base.OnStateEnter();

        // Make sure we have a valid TargetObject to walk to before we proceed
        if (_controller.TargetObject != null)
        {
            _controller.MoveToDestination(_controller.TargetObject.transform.position);
        }
        else
        {
            _controller.SetState(new WaitState(_controller));
        }
    }

    public override void UpdateState()
    {
        base.UpdateState();

        // Check if we've reached the destination
        if (!_controller.NavAgent.pathPending)
        {
            if (_controller.NavAgent.remainingDistance <= _controller.NavAgent.stoppingDistance)
            {
                if (!_controller.NavAgent.hasPath || _controller.NavAgent.velocity.sqrMagnitude == 0f)
                {
                    _controller.SetState(new InteractState(_controller));
                }
            }
        }

    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}