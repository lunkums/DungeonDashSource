using UnityEngine;

public class ActivePlayerInput : PlayerInput
{
    public override bool Jump => Input.GetButtonDown("Jump");

    public override bool JumpPressed => Input.GetButton("Jump");
	
    public override bool Attack => Input.GetButtonDown("Fire1");

    public override bool Roll => Input.GetButtonDown("Fire2");

    public override bool Test => Input.GetButtonDown("Test");

    public override bool FallThrough => Input.GetButtonDown("Fall Through");
}
