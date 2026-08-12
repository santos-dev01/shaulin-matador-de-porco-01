using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pigPrefab;
    public Transform player;
    public float spawnInterval = 2f;
    public float spawnRadius = 10f;
    float spawnTimer = 0f;

    public int score = 0;
    public Text scoreText;
    public GameObject gameOverUI;

    public bool isGameOver = false;

    void Start()
    {
        spawnTimer = spawnInterval;
        UpdateScoreUI();
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p) player = p.transform;
        }

        if (gameOverUI != null) gameOverUI.SetActive(false);
    }

    void Update()
    {
        if (isGameOver) return;

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnPig();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnPig()
    {
        if (pigPrefab == null || player == null) return;
        Vector2 spawnPos = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(pigPrefab, spawnPos, Quaternion.identity);
    }

    public void AddScore(int v)
    {
        score += v;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameOver = true;
        if (gameOverUI != null) gameOverUI.SetActive(true);
    }
}
