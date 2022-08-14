using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHealthController : MonoBehaviour
{
    [SerializeField] private HealthController _healthController;
    public GameOverScreen GameOverScreen;
    public WinScreen WinScreen;

    // How long the player needs to stay at location
    public float timer = 0.0f;
    private int seconds;
    // Is the player currently at location
    bool isPlayerColliding = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Collision timer
        if (isPlayerColliding == true)
        {
            timer += Time.deltaTime;
            seconds = (int)(timer % 60);
        }

        if (_healthController.playerHealth == 0)
        {
            GameOver();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject light = GameObject.Find("Light");
        if(collision.gameObject.tag == "Enemy")
        {
            isPlayerColliding = true;
            
        }
        else if(collision.gameObject.tag == "Health" && _healthController.playerHealth < 3)
        {
            _healthController.playerHealth++;
            _healthController.UpdateHealth();
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Light")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Finish" && light == null)
        {
            Debug.Log("You Win!");
            YouWin();
        }
    }
    // Check if the player is still at location, if they are spawn our secret item
    void OnCollisionStay2D(Collision2D other)
    {

        if(other.gameObject.tag == "Enemy" && isPlayerColliding == true)
        {
            if (Input.GetKeyDown("space"))
            {
                other.gameObject.GetComponent<EnemyController>().health -= 1;
            }
            if(seconds == 1)
            {
                _healthController.playerHealth--;
                _healthController.UpdateHealth();
                timer = 0.0f;
                seconds = 0;
            }
 
        }
    }
    // If the player is not colliding reset our timer
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            isPlayerColliding = false;
        }
    }

    public void GameOver() {
        GameOverScreen.Setup();
    }

    public void YouWin() {
        WinScreen.Setup();
    }
}
