using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;

    public static GameManager instance = null;

    public Player Player
    {
        get => player;
        set => player = value;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
}
