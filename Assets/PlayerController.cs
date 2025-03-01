using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public Rigidbody2D rb;
    Vector3 temp = new Vector3(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        float hor;
        float ver;

        float speed = 100;

        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");




        if (hor > 0)
        {
            temp = new Vector3(0, 0, temp.z - 1);
            rb.linearVelocity = transform.up.normalized * rb.linearVelocity.magnitude;
            
        }
        else if (hor < 0) {
            temp = new Vector3(0, 0, temp.z + 1);
            rb.linearVelocity = transform.up.normalized * rb.linearVelocity.magnitude;
        }
        if ( ver > 0) {
            rb.linearVelocity = transform.up * Time.deltaTime * speed;
        }
        else if ( ver < 0) {
            rb.linearVelocity = new Vector2(0, 0);
        }

        transform.rotation = Quaternion.Euler(temp);
    }
}
