using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfiniteLevelGenerator : MonoBehaviour
{
    [SerializeField] private int DistanceUntilLoadNextPart = 10;
    [SerializeField] private Transform firstEndPoint;
    [SerializeField] private List<Transform> chunkList;
    [SerializeField] private Transform chunkPrefab;

    private Transform player;
    private Vector2 lastEndPoint;
    private Queue<Transform> chunkQueue;
    private int maxPreloadedChunks = 5;
    private Vector2 tempStartPosition = new Vector2(0.0f, -50.0f);

    private void Start()
    {
        var scene = gameObject.scene;
        SceneManager.SetActiveScene(scene);
        player = GameManager.instance.Player.transform;
        lastEndPoint = firstEndPoint.position;
        chunkQueue = new Queue<Transform>();
        StartCoroutine(InitializeChunks());
    }

    private void Update()
    {
        if (Vector2.Distance(player.position, lastEndPoint) < DistanceUntilLoadNextPart)
            SpawnNextLevelPart();
    }

    private IEnumerator InitializeChunks()
    {
        while (true)
        {
            var nextChunk = Instantiate(chunkPrefab, tempStartPosition, Quaternion.identity, transform);
            var nextChunkScript = nextChunk.GetComponent<GenerateTiles>();

            while (!nextChunkScript.IsChunkReady)
                yield return null;

            chunkQueue.Enqueue(nextChunk);

            while (chunkQueue.Count >= maxPreloadedChunks)
                yield return null;
        }
    }

    private void SpawnNextLevelPart()
    {
        Transform nextChunk;

        if (chunkQueue.Count > 0)
        {
            nextChunk = chunkQueue.Dequeue();
        }
        else
        {
            var nextChunkPrefab = chunkList[Random.Range(0, chunkList.Count)];
            nextChunk = Instantiate(nextChunkPrefab, tempStartPosition, Quaternion.identity, transform);
        }

        RepositionNextChunk(nextChunk);
    }

    private void RepositionNextChunk(Transform nextChunk)
    {
        Vector2 offset = nextChunk.Find("Start Point").localPosition;
        nextChunk.position = lastEndPoint - offset;
        lastEndPoint = nextChunk.Find("End Point").position;
    }
}
