using UnityEngine;

public class score_tracker : MonoBehaviour
{
    public GameObject ball;
    private Transform[] children;
    private int score = 0;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        children = new Transform[ball.transform.childCount];
        for (int i = 0; i < ball.transform.childCount; i++)
        {
            children[i] = ball.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in children)
        {
            if (child != null && ball.GetComponent<Collider>().bounds.Intersects(child.GetComponent<Collider>().bounds))
            {
            score++;
            Debug.Log("Score: " + score);
            }
        }
    }
}
