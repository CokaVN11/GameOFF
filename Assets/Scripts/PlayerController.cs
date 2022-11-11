using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D colli;

    private float moveInput;

    public float speed;

    public bool takeOff = false;

    public float usingTime = 10 ;
    private float keyPressedTime = 0;

    public HealthBar healthBar;
    public int maxHealth = 100;
    private float health = 0;
    private float healthReduceScale = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colli = GetComponent<Collider2D>();
        healthReduceScale = 1;
        health = (int)maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        GetMoveInput();
        GetAction();

        if (health <= 0) GameOver();
        //float time_remain = usingTime - (Time.time - keyPressedTime);
        //print("Time remain: " + time_remain);
    }

    private void FixedUpdate()
    {
        health -= Time.fixedDeltaTime * healthReduceScale + gameObject.GetComponent<StaminaController>().weight/10;
        healthBar.SetCurrentHealth((int)health);
    }

    //private void ApplyMove()
    //{

    //}

    private void GetMoveInput()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void GetAction()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !takeOff)
        {
            //Debug.Log("Key Q is Pressed");  
            takeOff = true;
            healthReduceScale = 2.5f;
            keyPressedTime = Time.time;
        }
        
        //if (Input.GetKeyUp(KeyCode.Q))
        //{
        //    //Debug.Log("Key Q is Up");
        //    takeOff = false;
        //}

        if (takeOff && Time.time > keyPressedTime + usingTime)
        {
            takeOff = false;
            healthReduceScale = 1f;
            keyPressedTime = Time.time;
        }
    }

    public void GameOver()
    {
        //gameObject.SetActive(false);
        SceneManager.LoadScene("GameOver");
    }
}
