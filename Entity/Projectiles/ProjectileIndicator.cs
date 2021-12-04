using UnityEngine;

public class ProjectileIndicator : MonoBehaviour
{
    [SerializeField] private Arrow arrow;
    private GameManager gameManager;
    [SerializeField] private GameObject indicator;

    private void OnEnable()
    {
        indicator.SetActive(true);
    }

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private bool ShouldDisplayIndicator()
    {
        var isAheadOfPlayer = transform.position.x > gameManager.Player.transform.position.x;
        return isAheadOfPlayer && !arrow.Renderer.isVisible;
    }

    private void Update()
    {
        if (!ShouldDisplayIndicator())
        {
            indicator.SetActive(false);
        }
        else
        {
            var newPosition = indicator.transform.position;
            var viewportCoords = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, Camera.main.nearClipPlane));
            newPosition.x = viewportCoords.x;
            indicator.transform.position = newPosition;
        }
    }
}
