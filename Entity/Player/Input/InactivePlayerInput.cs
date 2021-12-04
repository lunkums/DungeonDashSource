public class InactivePlayerInput : PlayerInput
{
    public override bool Jump => false;

    public override bool JumpPressed => false;

    public override bool Attack => false;

    public override bool Roll => false;

    public override bool Test => false;

    public override bool FallThrough => false;
}