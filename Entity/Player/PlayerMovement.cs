using UnityEngine;

public class PlayerMovement : EntityMovement
{
    [SerializeField] private Collider2D fullHurtbox;
    [SerializeField] private Collider2D rollingHurtbox;
    private Transform _transform;

    private float totalDistance;
    private float lastXPosition;

    public float TotalDistance => totalDistance;

    private void Awake()
    {
        _transform = gameObject.transform;
        totalDistance = 0.0f;
        lastXPosition = _transform.position.x;
    }

    private void Update()
    {
        var currentXPosition = _transform.position.x;
        totalDistance += currentXPosition - lastXPosition;
        lastXPosition = currentXPosition;
    }

    public void EnableRollHurtbox(bool enabled)
    {
        fullHurtbox.enabled = !enabled;
        rollingHurtbox.enabled = enabled;
    }
}
