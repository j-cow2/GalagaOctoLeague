using UnityEngine;
using UnityEngine.SceneManagement;

public class destruct : MonoBehaviour
{

    public int gatenum;
    public GameObject expl;
    public GameObject myPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "ball") {
            if (gatenum == 7) {
                SceneManager.LoadScene(2);
            }
            GameObject temp = GameObject.Instantiate(expl, transform.position, Quaternion.identity);
            GameObject.Find("Ball").GetComponent<ResetBall>().ResetMan(gatenum);
            GameObject.Find("enemySpawner").GetComponent<spawner>().KillEnemy(gatenum);
            
            Destroy(this.gameObject);
    }
    }

    
}
