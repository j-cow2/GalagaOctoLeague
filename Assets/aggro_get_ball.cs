using UnityEngine;

public class aggro_get_ball : MonoBehaviour
{
    public GameObject ball;
    public float aggroDistance = 5;
    public rigidbody2D rb;
    public float speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToBall = Vector2.Distance(transform.position, ball.transform.position);
        if (distanceToBall <= aggroDistance)
        {
        Vector2 direction = (ball.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        rb.velocity = direction * speed;
        }
        else
        {
        rb.velocity = Vector2.zero;
        }
    
    }
}
