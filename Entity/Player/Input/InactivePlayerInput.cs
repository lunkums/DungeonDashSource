public class InactivePlayerInput : IPlayerInput
{
    public bool Jump { get { return false; } }

    public bool Attack { get { return false; } }

    public bool Roll { get { return false; } }

    public bool Test { get { return false; } }
}