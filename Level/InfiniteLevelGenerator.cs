using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfiniteLevelGenerator : MonoBehaviour
{
    private const int DistanceUntilLoadNextPart = 10;

    [SerializeField] private Transform firstLevelPart;
    [SerializeField] private List<Transform> levelPartList;

    private Transform player;
    private Vector2 lastEndPoint;

    private void Start()
    {
        var scene = gameObject.scene;
        SceneManager.SetActiveScene(scene);
        player = GameManager.instance.Player.transform;
        lastEndPoint = firstLevelPart.Find("End Point").position;
    }

    private void Update()
    {
        if (Vector2.Distance(player.position, lastEndPoint) < DistanceUntilLoadNextPart)
            SpawnNextLevelPart();
    }

    private void SpawnNextLevelPart()
    {
        Transform nextLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        SpawnNextLevelPart(nextLevelPart);
    }

    private void SpawnNextLevelPart(Transform nextLevelPart)
    {
        Vector2 offset = nextLevelPart.Find("Start Point").localPosition;
        var newLevelPart = Instantiate(nextLevelPart, lastEndPoint - offset, Quaternion.identity);
        lastEndPoint = newLevelPart.Find("End Point").position;
    }
}
