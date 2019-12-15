using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbodySanta;
    Animator animator;
    bool isGrounded;
    bool isGameOver = false;
    const string jumpAnimationKeyword = "Jump";
    const string santaDeathAnimationKeyword = "SantaDeath";
    const string groundObjectTag = "Ground";
    const string obstacleObjectTag = "Obstacle";

    [SerializeField] float jumpForce;
    
    private void Awake()
    {
        rigidbodySanta = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !isGameOver)
        {
            if (isGrounded == true)
            {
                jump();
            }
        }
    }

    void jump()
    {
        isGrounded = false;
        rigidbodySanta.velocity = Vector2.up * jumpForce;
        animator.SetTrigger(jumpAnimationKeyword);
        GameManager.instance.IncrementScore();
        Debug.Log("DeleteMe");
    }

    private bool SetGameOverTrue()
    {
        return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == groundObjectTag)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == obstacleObjectTag)
        {
            GameManager.instance.GameOver();
            Destroy(collision.gameObject);
            animator.Play(santaDeathAnimationKeyword);
            isGameOver = SetGameOverTrue();
        }
    }
}
