using System;
using System.Linq;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Cube : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] private AnimationClip left;
    [SerializeField] private AnimationClip right;
    [SerializeField] private AnimationClip up;
    [SerializeField] private AnimationClip down;
    [SerializeField] private TimeSlowdown timeSlowScript;
    [SerializeField] private  TMP_Text scoreboard;
    [SerializeField] private float speed;
    [SerializeField] private int neededScore;
    private GameObject[] coinManager;
    private GameObject[] coinActivate;
    private int coins = 0;
    private Vector3 intitialPosition;
    private float hInput;
    private float vInput;

    void Start()
    {
        //Creates Storage for coins 
        coinActivate =  GameObject.FindGameObjectsWithTag("Coin");
        coinManager =  GameObject.FindGameObjectsWithTag("Coin");
        intitialPosition = transform.position;
    }

    
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        hInput = Input.GetAxisRaw("Horizontal"); 
        vInput = Input.GetAxisRaw("Vertical");
        
        Vector3 movementDirection = new Vector3(hInput, vInput, 0).normalized;
        
        //gameObject.transform.position += movementDirection * speed*  Time.deltaTime;
        transform.Translate(movementDirection * speed * Time.unscaledDeltaTime, Space.World);
        Animations();
    }

    private void Animations()
    {
        if (vInput >= 0.1)
        {
            animator.Play("Player_Up");
        }
        else if (vInput <= -0.1)
        {
            animator.Play("Player_Down");
        }
        else if (hInput >= 0.1)
        {
            animator.Play("Player_Right");
        }
        else if (hInput <= -0.1)
        {
            animator.Play("Player_Left");
        }
        else
        {
            animator.Play("Player_Idle");
        }
    }

    // YOU NEED both of the objects have a collider
    // AT LEASt one of them should have checked as trigger
    // AT LEAST one of them should have a rigidbody.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            UpdateCoins(other);
        }
        else if (other.gameObject.CompareTag("Trap") || other.gameObject.CompareTag("Wall"))
        {
            coins = 0;
            scoreboard.text = "Score: " + coins;
            this.gameObject.transform.position = intitialPosition;
            timeSlowScript.timeRemaining = 10;
            timeSlowScript.isTimeSlow = false;
            Time.timeScale = 1;
            ActivateCoins(other);
        }
        else if (other.gameObject.CompareTag("Ending") && coins == neededScore)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }

    }
    

    private void ActivateCoins(Collider2D other)
    {
        foreach (GameObject coinActivate in coinManager)
        {
            coinActivate.gameObject.SetActive(true);
        }
            
    }

    private void UpdateCoins(Collider2D other)
    {
        coins++; //+1 coin.
        scoreboard.text = "Score: " + coins;
        timeSlowScript.timeRemaining += 10;
        other.gameObject.SetActive(false);
    }
}
