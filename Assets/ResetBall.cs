using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetBall : MonoBehaviour
{

    private int count = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetMan() {
        transform.position = new Vector3(0, 0, 0);
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
        count++;
        if (count == 7) {
            SceneManager.LoadScene(3);
        }
        
    }
}
