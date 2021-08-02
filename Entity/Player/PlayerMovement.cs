using UnityEngine;

public class PlayerMovement : EntityMovement
{
    [SerializeField] private Collider2D fullHurtbox;
    [SerializeField] private Collider2D rollingHurtbox;

    public void EnableRollHurtbox(bool enabled)
    {
        fullHurtbox.enabled = !enabled;
        rollingHurtbox.enabled = enabled;
    }
}
