using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject target_ball;
    public float radialDistance = 10;
    private List<GameObject> enemies = new List<GameObject>();
    private bool[] enemiesKilled;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemiesKilled = new bool[8];
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

        for (int i = 0; i < enemyCount -1; i++)
        {
            float enemyDirXPosition = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radialDistance;
            float enemyDirYPosition = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radialDistance;

            Vector3 enemyPosition = new Vector3(enemyDirXPosition, enemyDirYPosition, 0);
            GameObject enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
            enemies.Add(enemy);

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

    public void KillEnemy(int index)
    {
        if (index >= 0 && index < enemies.Count && !enemiesKilled[index])
        {
            Destroy(enemies[index]);
            enemiesKilled[index] = true;

            if (index == 7)
            {
                SceneManager.LoadScene(2);
            }
            else if (AllEnemiesKilledExcept(7))
            {
                SceneManager.LoadScene(3);
            }
        }
    }

    bool AllEnemiesKilledExcept(int exceptionIndex)
    {
        for (int i = 0; i < enemiesKilled.Length; i++)
        {
            if (i != exceptionIndex && !enemiesKilled[i])
            {
                return false;
            }
        }
        return true;
    }
}
