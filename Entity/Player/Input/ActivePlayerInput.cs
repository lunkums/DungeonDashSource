using UnityEngine;

public class ActivePlayerInput : IPlayerInput
{
    public virtual bool Jump { get { return Input.GetButtonDown("Jump"); } private set { } }

    public virtual bool Attack { get { return Input.GetButtonDown("Fire1"); } private set { } }

    public virtual bool Roll { get { return Input.GetButtonDown("Fire2"); } private set { } }

    public virtual bool Test { get { return Input.GetButtonDown("Test"); } private set { } }
}
