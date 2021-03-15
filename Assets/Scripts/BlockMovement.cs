using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject blocksPrefab;
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2(-100, blocksPrefab.transform.position.y));
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(blocksPrefab);
    }

}
