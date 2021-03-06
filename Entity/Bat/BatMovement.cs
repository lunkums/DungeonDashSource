using UnityEngine;

public class BatMovement : EntityMovement
{
    [Range(0.1f, 1.0f)]
    [SerializeField] private float speedFactor = 0.8f;
    [SerializeField] private float amplitude = 2.0f;
    [SerializeField] private float period = 2.0f;
    private float timeSinceBirth;
    private float horizontalShift;

    public float SpeedFactor => speedFactor;

    private void SetStartingPosition()
    {
        var startingPosition = gameObject.transform.position;
        timeSinceBirth = 0f;
        horizontalShift = Random.Range(0f, Mathf.PI);
        startingPosition.y += amplitude * Mathf.Sin(horizontalShift);
        gameObject.transform.position = startingPosition;
    }

    private void Initialize()
    {
        SetStartingPosition();
        // Undo any changes made by EnableFreeFall()
        gameObject.layer = LayerMask.NameToLayer("Enemy");
        Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        Rigidbody2D.gravityScale = 0f;
    }

    private void OnEnable()
    {
        Initialize();
    }

    private void SetForwardVelocity()
    {
        var newVelocity = Rigidbody2D.velocity;
        newVelocity.x = GroundedEntityMovement.GlobalSpeed * speedFactor;
        Rigidbody2D.velocity = newVelocity;
    }

    private void SetUpwardVelocity()
    {
        var newVelocity = Rigidbody2D.velocity;
        newVelocity.y = VelocityFunction(timeSinceBirth);
        timeSinceBirth += Time.fixedDeltaTime;
        Rigidbody2D.velocity = newVelocity;
    }

    private void SetUpwardVelocity(float upwardVelocity)
    {
        var newVelocity = Rigidbody2D.velocity;
        newVelocity.y = upwardVelocity;
        Rigidbody2D.velocity = newVelocity;
    }

    private float VelocityFunction(float x)
    {
        return amplitude * period * Mathf.Cos(period * x + horizontalShift);
    }

    public void EnableFreeFall()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore All");
        Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        Rigidbody2D.gravityScale = 1.0f;
        SetUpwardVelocity(4.0f);
    }

    public void SetVelocity()
    {
        SetForwardVelocity();
        SetUpwardVelocity();
    }
}
