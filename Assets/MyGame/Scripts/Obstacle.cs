using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
Rigidbody2D rigidbodyObstacle;
[SerializeField] private float MoveSpeed;

private void Awake()
{
    rigidbodyObstacle = GetComponent<Rigidbody2D>();
}

// Start is called before the first frame update
void Start()
{
        
}

// Update is called once per frame
void Update()
{
    //if obstacle's position x is < -15f it will be destroyed
    if(transform.position.x < -15f)
    {
        Destroy(gameObject);
}
        //if obstacle's position x is < -15f it will be destroyed
        if (transform.position.x > 15f)
        {
            Destroy(gameObject);
        }

    }



private void FixedUpdate()
{

    rigidbodyObstacle.velocity = Vector2.left * MoveSpeed;

}
}
