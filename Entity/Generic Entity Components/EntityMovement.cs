using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public virtual Rigidbody2D Rigidbody2D => _rigidbody2D;
}
