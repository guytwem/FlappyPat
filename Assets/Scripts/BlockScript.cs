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
        BeginSpawning(); // start spawning blocks
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BeginSpawning() => StartCoroutine("Spawning"); // this function starts the spawning coroutine

    IEnumerator Spawning() // block spawning coroutine.
    {
        yield return new WaitForSeconds(1f);

        SpawnBlocks();
        SpawnWater();

        StartCoroutine("Spawning");

    }

    public GameObject SpawnBlocks()
    {
        Vector3 randomSpawn = new Vector3(8, Random.Range(5, -5), 0); // randomises spawn location
        var blocks = Instantiate(blocksPrefab, randomSpawn, Quaternion.identity); // instantiates blocks at the random spawn point.
        blocks.SetActive(true);
        return blocks;



    }
    
    public GameObject SpawnWater() // radnomises the location and instantiates a water block.
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
