using UnityEngine;

public class GenerateChunk : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField] private float chanceOfArrow;
    [Range(0, 9)]
    [SerializeField] private int numOfArrows;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform endPoint;

    private void Initialize()
    {
        for (int i = 0; i < numOfArrows; i++)
        {
            if (Random.Range(0.01f, 1.0f) < chanceOfArrow)
            {
                var startingPosition = new Vector2(endPoint.position.x, Mathf.FloorToInt(Random.Range(0.0f, 11.99f)) / 4.0f);
                ObjectPooler.instance.SpawnObject("Arrow", startingPosition);
            }
        }
    }

    private void OnEnable()
    {
        Initialize();
    }
}
