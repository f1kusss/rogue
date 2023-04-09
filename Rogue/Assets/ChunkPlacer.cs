using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk FisrtChunk;

    private List<Chunk> spawnedChunks = new List<Chunk>();

    // Start is called before the first frame update
    void Start()
    {
        spawnedChunks.Add(FisrtChunk);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.position.z > spawnedChunks[spawnedChunks.Count - 1].End.position.z)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        Chunk newChunk =Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count-1].End.position - newChunk.Begin.localPosition;
        spawnedChunks.Add(newChunk);
    }
}
