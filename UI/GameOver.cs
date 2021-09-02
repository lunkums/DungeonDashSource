using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform parentRect;
    [SerializeField] private GameObject gameOverObject;
    private bool isGameOver;

    private void Awake()
    {
        isGameOver = false;
    }

    private void Start()
    {
        rectTransform.sizeDelta = parentRect.sizeDelta;
    }

    private void OnEnable()
    {
        GameManager.instance.Player.Damageable.OnDestruct += EnableGameOverText;
    }

    private void OnDisable()
    {
        GameManager.instance.Player.Damageable.OnDestruct -= EnableGameOverText;
    }

    private void Update()
    {
        if (isGameOver)
            if (GameManager.instance.Player.InputController.Start)
                SceneManager.LoadScene("PersistentGameObjects");
    }

    private void EnableGameOverText()
    {
        gameOverObject.SetActive(true);
        isGameOver = true;
    }
}
