using UnityEngine;

public class cameraman : MonoBehaviour
{
    public GameObject player;
    public GameObject Baal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        GetComponent<Camera>().transform.position = new Vector3(((player.transform.position + Baal.transform.position)/2).x, ((player.transform.position + Baal.transform.position)/2).y, - Mathf.Clamp( Mathf.Abs((player.transform.position - Baal.transform.position).magnitude), 2, 7));
        
    }
}
