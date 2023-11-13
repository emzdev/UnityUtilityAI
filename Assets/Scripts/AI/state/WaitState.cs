using UnityEngine;

public class WaitState : State
{
    private float _waitTime = 3f;
    private float _elapsedTime;

    public WaitState(AIController controller) : base(controller) { }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        _elapsedTime = 0f;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _waitTime)
        {
            // Target selection
            if (_controller.SelectNewTarget())
            {
                _controller.SetState(new WalkState(_controller));
                return;
            }

            // We reset timer if we fail to find a target
            _elapsedTime = 0f;
        }

    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}