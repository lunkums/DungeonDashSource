using UnityEngine;

public static class UtilityEntityMovement
{
    public static readonly string groundLayerName = "Foreground";

    public static bool IsGrounded(Transform groundCheckPoint, float groundCheckRadius = 0.125f)
    {
        var colliders = Physics2D.OverlapCircleAll(groundCheckPoint.position, groundCheckRadius, LayerMask.GetMask(groundLayerName));
        return colliders.Length > 0;
    }
}
