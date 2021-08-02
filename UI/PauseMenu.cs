using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private Player player;

    private void OnEnable()
    {
        player = GameManager.instance.Player.GetComponent<Player>();
        Time.timeScale = 0f;
        player.InputController.EnableInput(false);

        Debug.Log(gameObject.ToString());
        Menu.MenuStack.Push(gameObject);
    }

    private void OnDisable()
    {
        Time.timeScale = 1.0f;
        player.InputController.EnableInput(true);

        Menu.MenuStack.Pop();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
