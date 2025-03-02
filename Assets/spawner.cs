using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject target_ball;
    public float radialDistance = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
        {
            int enemyCount = 8;
            float angleStep = 360f / enemyCount;
            float angle = 0f;

            for (int i = 0; i < enemyCount; i++)
            {
                float enemyDirXPosition = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radialDistance;
                float enemyDirYPosition = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radialDistance;

                Vector3 enemyPosition = new Vector3(enemyDirXPosition, enemyDirYPosition, 0);
                GameObject enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
                

                SetEnemyColor(enemy, i, enemyCount);

                angle += angleStep;
            }
        }

    void SetEnemyColor(GameObject enemy, int index, int totalEnemies)
        {
            Renderer enemyRenderer = enemy.GetComponent<Renderer>();
            if (enemyRenderer != null)
            {
                float hue = (float)index / totalEnemies;
                enemyRenderer.material.color = Color.HSVToRGB(hue, 1f, 1f);
            }
        }
}
