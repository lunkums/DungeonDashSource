using UnityEngine;

public class ActivePlayerInput : PlayerInput
{
    public override bool Jump { get => Input.GetButtonDown("Jump"); }

    public override bool JumpPressed { get => Input.GetButton("Jump"); }
	
    public override bool Attack { get => Input.GetButtonDown("Fire1"); }

    public override bool Roll { get => Input.GetButtonDown("Fire2"); }

    public override bool Test { get => Input.GetButtonDown("Test"); }
}
