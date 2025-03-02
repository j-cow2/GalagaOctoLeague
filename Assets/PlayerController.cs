using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public Rigidbody2D rb;
    Vector3 temp = new Vector3(0, 0, 0);
    float speed = 100;


    // Update is called once per frame
    void Update()
    {
        float hor;
        float ver;



        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");

        speed= Mathf.Clamp(speed, 0, 20);


        if (hor > 0)
        {
            temp = new Vector3(0, 0, temp.z - (100 * Time.deltaTime));
            rb.linearVelocity = transform.up.normalized * rb.linearVelocity.magnitude;
            
        }
        else if (hor < 0) {
            temp = new Vector3(0, 0, temp.z + (100 * Time.deltaTime));
            rb.linearVelocity = transform.up.normalized * rb.linearVelocity.magnitude;
        }
        if ( ver > 0) {
            speed= Mathf.Clamp((speed +  (1 * Time.deltaTime * 0.001f) ), 0, 5);
            rb.linearVelocity = transform.up * speed;
        }
        else if ( ver < 0) {
            rb.linearVelocity = new Vector2(0, 0);
            speed= Mathf.Clamp((speed - (1 * Time.deltaTime * 0.001f)), 0, 5);
        }

        transform.rotation = Quaternion.Euler(temp);
    }
}