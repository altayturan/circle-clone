using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    [SerializeField]
    private float jumpHeight;
    private float jumpForce;
    private bool canJump = false;
    private bool isStarted;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject gameManager;

    private void Start()
    {
       GetComponent<Rigidbody2D>().gravityScale = 0f;
        
    }
    void Update()
    {
        jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * GetComponent<Rigidbody2D>().gravityScale));
        if (!gameManager.GetComponent<GameManager>().isGameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameManager.GetComponent<GameManager>().isGameStarted = true;
                canJump = true;
                GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, jumpForce);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GetComponent<GameManager>().isGameFinished = true;
        canJump = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Debug.Log("Girdi");
        SpriteRenderer[] sr = GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer item in sr)
        {
            item.color = Color.red;
        }
    }
}
