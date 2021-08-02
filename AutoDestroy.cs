using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private int distanceBeforeDestruction = 20;
    [SerializeField] private Transform pointOfDestruction;

    void Update()
    {
        GameObject player = GameManager.instance.Player.gameObject;

        if (Vector2.Distance(pointOfDestruction.position, player.transform.position) > distanceBeforeDestruction)
            Destroy(gameObject);
    }
}
