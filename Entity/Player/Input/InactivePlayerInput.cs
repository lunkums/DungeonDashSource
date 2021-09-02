public class InactivePlayerInput : PlayerInput
{
    public override bool Jump { get => false; }

    public override bool JumpPressed { get => false; }

    public override bool Attack { get => false; }

    public override bool Roll { get => false; }

    public override bool Test { get => false; }
}