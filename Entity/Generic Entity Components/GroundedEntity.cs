using UnityEngine;

public abstract class GroundedEntity : Entity
{
    [SerializeField] private EntityMovement movement;

    public EntityMovement Movement => movement;
}
