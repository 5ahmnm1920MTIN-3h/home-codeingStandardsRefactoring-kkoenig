using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D rigidbodyObstacle;
    [SerializeField] private float MoveSpeed;
    const float obstacleDestroyBoundary = 15f;

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
        //if obstacle's position x is < -15f it will be destroyed
        if (transform.position.x > obstacleDestroyBoundary)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rigidbodyObstacle.velocity = Vector2.left * MoveSpeed;
    }
}
