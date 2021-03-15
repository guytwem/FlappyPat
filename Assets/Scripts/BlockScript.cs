using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    

    public GameObject blocksPrefab;
    public GameObject waterPrefab;

    public float spawnRate = 5f;

    private void Awake()
    {
        BeginSpawning();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BeginSpawning() => StartCoroutine("Spawning");

    IEnumerator Spawning()
    {
        yield return new WaitForSeconds(1f);

        SpawnBlocks();
        SpawnWater();

        StartCoroutine("Spawning");

    }

    public GameObject SpawnBlocks()
    {
        Vector3 randomSpawn = new Vector3(8, Random.Range(5, -5), 0);
        var blocks = Instantiate(blocksPrefab, randomSpawn, Quaternion.identity);
        blocks.SetActive(true);
        return blocks;



    }
    
    public GameObject SpawnWater()
    {
        Vector3 randomSpawn = new Vector3(8, Random.Range(5, -5), 0);
        var waterBlocks = Instantiate(waterPrefab, randomSpawn, Quaternion.identity);
        waterBlocks.SetActive(true);
        return waterBlocks;

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
