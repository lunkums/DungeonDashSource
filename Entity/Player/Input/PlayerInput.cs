using UnityEngine;

public abstract class PlayerInput : IPlayerInput
{
    public bool Start { get => Input.GetButtonDown("Start"); }

    public abstract bool Jump { get; }
    public abstract bool JumpPressed { get; }
    public abstract bool Attack { get; }
    public abstract bool Roll { get; }
    public abstract bool Test { get; }
}