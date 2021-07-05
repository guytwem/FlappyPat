using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public float speed = 10f;
    public GameObject player;
    public GameObject drunk;
    public GameObject win;
    public GameObject winButton;
    public GameObject mainmenuButton;
    public SobrietyBar sobrietyBar;

   

   


    // Start is called before the first frame update
    void Start()
    {
        
        playerBody.GetComponent<Rigidbody2D>(); // getting player rigidbody
        //sets the win screens to false
        drunk.SetActive(false);
        win.SetActive(false);
        winButton.SetActive(false);
        mainmenuButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainmenuButton.SetActive(true);
            Time.timeScale = 0;
            // this gets the pause menu and stops game time.

        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                playerBody.AddForce(new Vector2(player.transform.position.x, speed));
            }
            //when you touch on the screen adds force to the player
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            playerBody.AddForce(new Vector2(player.transform.position.x, speed));
            //when space is pressed or mouse button it moves the player
        }

        if(SceneManager.GetActiveScene().name == ("Level_02") && sobrietyBar.sobriety.curSobriety == sobrietyBar.sobriety.maxSobriety)
        {
            //wnen you win activate the end screen.
            win.SetActive(true);
            winButton.SetActive(true);
            mainmenuButton.SetActive(true);
            Time.timeScale = 0;
        }
        else if(sobrietyBar.sobriety.curSobriety == sobrietyBar.sobriety.maxSobriety)
        {
            //starts the second level after you complete the first.
            drunk.SetActive(true);
             new WaitForSeconds(5);
            SceneManager.LoadScene("Level_02");
        }
        //if the player goes off the screen then spawn him at the opposite side.
        if(player.transform.position.y > 6)
        {
            player.transform.position = new Vector3(-6.95f, -5,0);
        }
        if (player.transform.position.y < -6)
        {
            player.transform.position = new Vector3(-6.95f, 5, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        sobrietyBar.SetSobriety();
        sobrietyBar.sobriety.curSobriety += 1;
        //if the player hits a block add sobriety
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
