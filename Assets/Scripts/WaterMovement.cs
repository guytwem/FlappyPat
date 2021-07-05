using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    public GameObject waterPrefab;

     


    // Start is called before the first frame update
    void Start() // sends water blocks left across the screen.
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2(-200, waterPrefab.transform.position.y));
    }

   
}
