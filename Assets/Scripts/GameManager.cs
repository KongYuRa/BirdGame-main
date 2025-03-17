using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    public GameObject wallPrefab;
    public float spawnTerm = 4;

    public TextMeshProUGUI scoreLabel;

    public float score;

    float spawnTimer;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        spawnTimer = 0;
        score = 0;

        if (scoreLabel == null)
        {
            Debug.LogError("scoreLabel이 null입니다! Inspector에서 연결했는지 확인하세요.");
        }
        if (wallPrefab == null)
        {
            Debug.LogError("wallPrefab이 null입니다! Inspector에서 연결했는지 확인하세요.");
        }
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        score += Time.deltaTime;

        if (scoreLabel != null)  // null 체크 추가
        {
            scoreLabel.text = ((int)score).ToString();
        }

        if (spawnTimer > spawnTerm)
        {
            spawnTimer -= spawnTerm;

            if (wallPrefab != null)  // null 체크 추가
            {
                GameObject obj = Instantiate(wallPrefab);
                obj.transform.position = new Vector2(10, Random.Range(-2.75f, 2.75f));
            }
        }
    }
}
