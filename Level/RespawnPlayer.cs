using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.RespawnPlayer();
    }
}
