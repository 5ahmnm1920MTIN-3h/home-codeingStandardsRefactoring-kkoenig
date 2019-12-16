using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D rigidbodyObstacle;
    [SerializeField] private float MoveSpeed;
    const float obstacleDestroyBoundary = 15f;

    // Called once on gamestart, sets rigidbody of obstacles
    private void Awake()
    {
        rigidbodyObstacle = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if obstacle's position x is < -15f it will be destroyed
        if (transform.position.x < -obstacleDestroyBoundary)
        {
            Destroy(gameObject);
        }
        //if obstacle's position x is > 15f it will be destroyed
        else if (transform.position.x > obstacleDestroyBoundary)
        {
            Destroy(gameObject);
        }
    }

    // Called every fixed framerate frame, sets obstacle move speed
    private void FixedUpdate()
    {
        rigidbodyObstacle.velocity = Vector2.left * MoveSpeed;
    }
}
