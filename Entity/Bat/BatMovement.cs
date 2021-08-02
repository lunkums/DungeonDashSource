using UnityEngine;

public class BatMovement : MonoBehaviour
{
    [Range(0.1f, 1.0f)]
    [SerializeField] private float speedFactor = 0.8f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float amplitude = 2.0f;
    [SerializeField] private float period = 2.0f;
    private float timeSinceBirth;
    private float horizontalShift;

    public float SpeedFactor => speedFactor;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    private void Awake()
    {
        timeSinceBirth = 0f;
        horizontalShift = Random.Range(0, Mathf.PI);

        var startingPosition = gameObject.transform.position;
        startingPosition.y += amplitude * Mathf.Sin(horizontalShift);
        gameObject.transform.position = startingPosition;
    }

    public void SetVelocity()
    {
        SetForwardVelocity();
        SetUpwardVelocity();
    }

    private void SetForwardVelocity()
    {
        var newVelocity = Rigidbody2D.velocity;
        newVelocity.x = EntityMovement.GlobalSpeed * speedFactor;
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
        gameObject.layer = 12;
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody2D.gravityScale = 1.0f;
        SetUpwardVelocity(4.0f);
    }
}
