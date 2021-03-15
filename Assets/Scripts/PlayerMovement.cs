using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public float speed = 2f;
    public GameObject player;
    public GameObject drunk;
    public SobrietyBar sobrietyBar;
    
    
   

    
    
    // Start is called before the first frame update
    void Start()
    {
        
        playerBody.GetComponent<Rigidbody2D>();
        drunk.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                playerBody.AddForce(new Vector2(player.transform.position.x, speed));
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            playerBody.AddForce(new Vector2(player.transform.position.x, speed));
        }
        if(sobrietyBar.sobriety.curSobriety == sobrietyBar.sobriety.maxSobriety)
        {
            drunk.SetActive(true);
             new WaitForSeconds(5);
            SceneManager.LoadScene("Level_02");
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        sobrietyBar.SetSobriety();
        sobrietyBar.sobriety.curSobriety += 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sobrietyBar.Sobering();
        if(sobrietyBar.sobriety.curSobriety > 0)
        {
            sobrietyBar.sobriety.curSobriety--;
        }
        Destroy(collision.gameObject);
    }


}
