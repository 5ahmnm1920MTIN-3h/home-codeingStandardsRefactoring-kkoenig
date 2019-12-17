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
    
    // Called once on gamestart, sets Player animation and rigidbody
    private void Awake()
    {
        rigidbodySanta = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Called once per frame, calles jump methode if isGrounded is true
    void Update()
    {
        if (Input.GetMouseButton(0) && !isGameOver)
        {
            if (isGrounded == true)
            {
                Jump();
            }
        }
    }

    // Called when isGrounded is true, starts jumpevent
    void Jump()
    {
        isGrounded = false;
        rigidbodySanta.velocity = Vector2.up * jumpForce;
        animator.SetTrigger(jumpAnimationKeyword);
        GameManager.instance.IncrementScore();
    }

    private bool SetGameOverTrue()
    {
        return true;
    }

    // Called on CollisionEnter with gameObject, if gameObject has groundobject Tag isGrounded is set true
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == groundObjectTag)
        {
            isGrounded = true;
        }
    }

    // Called on TriggerEnter with Obstacles, sets GameOverEvent
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
