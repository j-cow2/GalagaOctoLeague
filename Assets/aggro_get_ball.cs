using UnityEngine;

public class aggro_get_ball : MonoBehaviour
{
    public float aggroDistance = 5;
    public Rigidbody2D rb;
    public float speed = 3;
    private GameObject ball;
    private Vector2 origin;
    


    private void Start()
    {
        spawner spawnerScript = FindObjectOfType<spawner>();
        if (spawnerScript != null)
        {
            ball = spawnerScript.target_ball;
        }
        origin = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (ball != null) 
        {
            float distanceToBall = Vector2.Distance(transform.position, ball.transform.position);
            if (distanceToBall <= aggroDistance)
            {
                Vector2 direction = (ball.transform.position - transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.rotation = angle - 90;
                rb.linearVelocity = direction * speed;
            }
            else if (Vector2.Distance(transform.position, origin) > 0.1f)
            {
                Vector2 direction = (origin - (Vector2)transform.position).normalized;
                rb.linearVelocity = direction * speed;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.rotation = angle - 90;
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
                rb.rotation = 0;
            }
        }
    }
}
