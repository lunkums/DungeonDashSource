public abstract class AnimatedState : State
{
    private string animatorTrigger;

    public string AnimatorTrigger => animatorTrigger;

    public AnimatedState(IEntity entity, StateMachine stateMachine, string animatorTrigger) : base(entity, stateMachine)
    {
        this.animatorTrigger = animatorTrigger;
    }

    public override void Enter()
    {
        Entity.Animator.SetTrigger(animatorTrigger);
    }

    public override void Exit()
    {
        Entity.Animator.ResetTrigger(animatorTrigger);
    }

    public bool IsCurrentAnimationPastTime(float timeInSeconds)
    {
        return Entity.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > timeInSeconds;
    }
}
