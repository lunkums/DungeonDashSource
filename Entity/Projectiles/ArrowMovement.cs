using UnityEngine;

public class ArrowMovement : EntityMovement
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float lerpValue;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.instance;
    }

    public void SetXVelocity(float magnitude = 1.0f)
    {
        var newVelocity = Rigidbody2D.velocity;
        newVelocity.x = xSpeed * magnitude;
        Rigidbody2D.velocity = newVelocity;
    }

    public void MoveTowardsPlayer()
    {
        var newPosition = transform.position;
        var playerPosition = gameManager.Player.transform.position;
        newPosition.y = Mathf.Lerp(newPosition.y, playerPosition.y, lerpValue);
        transform.position = newPosition;
    }
}
