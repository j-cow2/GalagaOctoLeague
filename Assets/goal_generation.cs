using UnityEngine;

public class goal_generation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int index = 0;
        int totalChildren = transform.childCount;

        foreach (Transform child in transform)
        {
            GameObject goal = new GameObject("Goal");
            goal.transform.position = child.position;
            goal.transform.localScale = new Vector3(1, 1, 1);

            LineRenderer lineRenderer = goal.AddComponent<LineRenderer>();
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
            lineRenderer.positionCount = 2;
            lineRenderer.sortingOrder = 100;
            int segments = 100;
            lineRenderer.positionCount = segments + 1;
            float radius = 0.25f;

            for (int i = 0; i <= segments; i++)
            {
                float angle = (float)i / segments * 2 * Mathf.PI;
                float x = Mathf.Cos(angle) * radius;
                float y = Mathf.Sin(angle) * radius;
                lineRenderer.SetPosition(i, new Vector3(child.position.x + x, child.position.y + y, child.position.z));
            }
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

            float hue = (float)index / totalChildren;
            Color color = Color.HSVToRGB(hue, 1f, 1f);
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;

            index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
