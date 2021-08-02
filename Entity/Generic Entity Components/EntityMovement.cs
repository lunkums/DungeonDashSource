using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public static float GlobalSpeed = 10.0f / 3.0f;

    private float currentSpeed = 10.0f;
    [SerializeField] private float jumpVelocity = 10.0f;
    [SerializeField] private float forwardJumpVelocity = 10.0f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius = 1.0f;
    [SerializeField] private LayerMask groundLayer;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public float Speed
    {
        get { return currentSpeed; }
        private set { }
    }
    public float ForwardJumpVelocity => forwardJumpVelocity;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
    }

    public bool IsGrounded()
    {
        var colliders = Physics2D.OverlapCircleAll(groundCheckPoint.position, groundCheckRadius, groundLayer);

        return colliders.Length > 0;
    }

    public void SetForwardVelocity(float magnitude = 1.0f)
    {
        var newVelocity = Rigidbody2D.velocity;
        currentSpeed = GlobalSpeed * magnitude;
        newVelocity.x = currentSpeed;
        Rigidbody2D.velocity = newVelocity;
    }

    public void Jump()
    {
        var newVelocity = Rigidbody2D.velocity;
        newVelocity.y = jumpVelocity;
        Rigidbody2D.velocity = newVelocity;
    }

    public void Stop()
    {
        Rigidbody2D.velocity = Vector2.zero;
    }

    public void SetLayer(int layer)
    {
        gameObject.layer = layer;
    }
}
