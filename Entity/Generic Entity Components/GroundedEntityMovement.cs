using System.Collections;
using UnityEngine;

public class GroundedEntityMovement : EntityMovement
{
    public static readonly float GlobalSpeed = 40.0f / 3.0f;

    private float currentSpeed = 40.0f;
    private bool groundedExtension = false;

    [SerializeField] private float jumpExtensionTime = 0.1f;
    [SerializeField] private float jumpVelocity = 40.0f;
    [SerializeField] private float forwardJumpVelocity = 40.0f;
    [SerializeField] private float layerResetTime = 0.2f;

    public float Speed { get { return currentSpeed; } private set { } }
    public float ForwardJumpVelocity => forwardJumpVelocity;
    public ContactFilter2D ContactFilter;

    private IEnumerator JumpExtension()
    {
        yield return new WaitForSeconds(jumpExtensionTime);
        groundedExtension = false;
    }

    private IEnumerator ResetLayer()
    {
        yield return new WaitForSeconds(layerResetTime);
        gameObject.layer = GameManager.GroundedLayer;
    }

    public bool IsGrounded()
    {
        var grounded = Rigidbody2D.IsTouching(ContactFilter);

        if (grounded)
            groundedExtension = true;
        else if (groundedExtension)
            StartCoroutine(JumpExtension());

        return grounded || groundedExtension;
    }

    public void SetForwardVelocity(float magnitude = 1.0f)
    {
        var newVelocity = Rigidbody2D.velocity;
        currentSpeed = GlobalSpeed * magnitude;
        newVelocity.x = currentSpeed;
        Rigidbody2D.velocity = newVelocity;
    }

    public void Jump(float magnitude = 1.0f)
    {
        var newVelocity = Rigidbody2D.velocity;
        newVelocity.y = jumpVelocity * magnitude;
        Rigidbody2D.velocity = newVelocity;
        groundedExtension = false;
    }

    public void Stop()
    {
        Rigidbody2D.velocity = Vector2.zero;
    }

    public void DisablePlatformCollisions()
    {
        gameObject.layer = GameManager.IgnorePlatformGroundedLayer;
        StartCoroutine(ResetLayer());
    }
}
