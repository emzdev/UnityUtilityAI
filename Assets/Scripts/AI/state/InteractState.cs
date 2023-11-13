
public class InteractState : State
{
    public InteractState(AIController controller) : base(controller) { }

    public override void OnStateEnter()
    {
        base.OnStateEnter();

        if (_controller.TargetObject != null)
        {
            Advertiser advertiser = _controller.TargetObject.GetComponent<Advertiser>();

            foreach (var promisedNeedChange in advertiser.PromisedNeedChanges)
            {
                //// commented out need change because I didn't implement need decay yet
                // _controller.NeedsHandler.ModifyNeedValue(promisedNeedChange.NeedType, promisedNeedChange.NeedValue);
            }

            _controller.DestroyCurrentTarget();

            _controller.SetState(new WaitState(_controller));
        }


    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}