using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float move;
    private float Vmove;
    public float speed = 3;
    public bool BattleGrounded = false;
    //public bool CanJump = false;

    //Experience and Level
    public float level = 100;
    public float MaxLevel = 100;
    public float Experience = 10;
    public float MaxExperience = 10;
    public float MinExperience = 0;

    public float HP;

    //Jump
    public float JumpVelocity = 50f;

    //Display Statistics
    public TextMeshProUGUI EXPtext;
    public TextMeshProUGUI Leveltext;
    public TextMeshProUGUI HPtext;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            move = Input.GetAxis("Horizontal");
            Vmove = Input.GetAxis("Vertical");

            rb.velocity = new Vector2(speed * Vmove, rb.velocity.y);
            rb.velocity = new Vector2(speed * move, rb.velocity.x);
        }

        /*
        move = Input.GetAxis("Horizontal");
        Vmove = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(speed * Vmove, rb.velocity.y);
        rb.velocity = new Vector2(speed * move, rb.velocity.x);
        */

        //Have the player's Experience Points go down
        Experience -= Time.deltaTime;

        //Text Values of the Player's Stats
        EXPtext.text = Experience.ToString("0");
        Leveltext.text = "Level: " + level;
        HPtext.text = "HP: " + HP;

        if(Experience < 0)
        {
            level -= 1;
            MaxExperience -= 2;
            Experience = MaxExperience;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(sceneName: "BattleScene");
        }

        if(collision.gameObject.CompareTag("Bullet"))
        {
            HP -= 5;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("BattleGround"))
        {
            //CanJump = true;
            BattleGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("BattleGround"))
        {

            BattleGrounded = false;
        }
    }
}
