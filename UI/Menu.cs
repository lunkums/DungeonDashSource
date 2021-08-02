using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private static Stack<GameObject> menuStack;
    [SerializeField] private GameObject pauseMenuUI;

    public static bool GameIsPaused => menuStack.Count > 0;
    public static Stack<GameObject> MenuStack => menuStack;

    private void Start()
    {
        menuStack = new Stack<GameObject>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
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
}
