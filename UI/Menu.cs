using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private static Stack<GameObject> menuStack;
    [SerializeField] private GameObject pauseMenuUI;
    private PlayerInputController playerInputController;

    public static bool GameIsPaused => menuStack.Count > 0;
    public static Stack<GameObject> MenuStack => menuStack;

    private void OnEnable()
    {
        GameManager.instance.Player.Damageable.OnDestruct += DisableSelf;
    }

    private void OnDisable()
    {
        GameManager.instance.Player.Damageable.OnDestruct -= DisableSelf;
    }

    private void Start()
    {
        menuStack = new Stack<GameObject>();
        playerInputController = GameManager.instance.Player.InputController;
    }

    private void Update()
    {
        if (playerInputController.Start)
        {
            if (GameIsPaused)
            {
                var lastMenuItem = menuStack.Peek();

                lastMenuItem.SetActive(false);
            }
            else
            {
                pauseMenuUI.SetActive(true);
            }
        }
    }

    private void DisableSelf()
    {
        this.enabled = false;
    }
}
