using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] private GameObject[] dependentComponents;
    [SerializeField] private string activeSceneName = "InfiniteRunnerTest";

    public Player Player { get; set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        StartCoroutine(LoadActiveSceneCoroutine());
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
}
