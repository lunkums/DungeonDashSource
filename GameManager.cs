using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static int ForegroundLayer => LayerMask.NameToLayer("Foreground");
    public static int PlatformLayer => LayerMask.NameToLayer("Platform");
    public static int GroundedLayer => LayerMask.NameToLayer("Grounded");
    public static int IgnorePlatformGroundedLayer => LayerMask.NameToLayer("Ignore Platform Grounded");

    [SerializeField] private GameObject[] dependentComponents;
    [SerializeField] private string activeSceneName = "InfiniteRunnerTest";
    [SerializeField] private Transform playerTracker;

    public Player Player { get; set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        StartCoroutine(LoadActiveSceneCoroutine());
    }

    private void FixedUpdate()
    {
        var newPosition = new Vector2(Player.transform.position.x, 0);
        playerTracker.position = newPosition;
    }

    private IEnumerator LoadActiveSceneCoroutine()
    {
        var activeScene = SceneManager.GetSceneByName(activeSceneName);
        AsyncOperation operation = SceneManager.LoadSceneAsync(activeSceneName, LoadSceneMode.Additive);

        operation.allowSceneActivation = true;

        while (!operation.isDone)
            yield return null;

        InitializeDependentComponents();

        yield break;
    }

    private void InitializeDependentComponents()
    {
        foreach (GameObject component in dependentComponents)
        {
            component.SetActive(true);
        }
    }

    public void RespawnPlayer()
    {
        Player.Respawn(Player.Movement.LastSafePosition);
    }
}
