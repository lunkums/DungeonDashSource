using UnityEngine;

public class PlayerMovement : GroundedEntityMovement
{
    private Transform _transform;

    private float totalDistance;
    private float lastXPosition;
    private Vector3 lastSafePosition;
    [SerializeField] private Transform[] holeDetectionPoints;

    public float TotalDistance => totalDistance;
    public Vector3 LastSafePosition => lastSafePosition;

    private void Awake()
    {
        _transform = gameObject.transform;
        totalDistance = 0.0f;
        lastXPosition = _transform.position.x;
        lastSafePosition = _transform.position;
    }
    
    private bool IsCurrentPosSafe()
    {
        var isSafe = IsGrounded();

        var i = 0;
        while (isSafe && i < holeDetectionPoints.Length)
            isSafe = UtilityEntityMovement.IsGrounded(holeDetectionPoints[i++]);

        return isSafe;
    }

    private void Update()
    {
        var currentXPosition = _transform.position.x;

        totalDistance += currentXPosition - lastXPosition;
        lastXPosition = currentXPosition;
        if (IsCurrentPosSafe())
            lastSafePosition = _transform.position;
    }
}
