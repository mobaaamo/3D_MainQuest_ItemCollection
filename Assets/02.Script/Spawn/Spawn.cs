using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("필수 설정")]
    public Coin coinPrefab;
    public int coinCount = 10;
    public LayerMask groundLayer;

    [Header("랜덤 스폰 영역")]
    public Vector3 spawnAreaMin = new Vector3(-10, 0, -10);
    public Vector3 spawnAreaMax = new Vector3(10, 0, 10);

    private ObjectPool<Coin> coinPool;
    private List<Coin> activeCoins = new List<Coin>();

    void Start()
    {
        coinPool = new ObjectPool<Coin>(coinPrefab, coinCount, transform);
        SpawnCoinsRandomly();
    }

    void SpawnCoinsRandomly()
    {
        ClearCoins();
        int spawned = 0;
        int maxAttempts = coinCount * 10;

        int attempts = 0;
        while (spawned < coinCount && attempts < maxAttempts)
        {
            attempts++;

            // 1. 랜덤 위치 선택 (x, z만 랜덤, y는 Ray 시작 높이)
            Vector3 randomXZ = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                spawnAreaMax.y + 10f, // 위에서 쏘기
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );

            // 2. Raycast로 아래 지면 탐지
            if (Physics.Raycast(randomXZ, Vector3.down, out RaycastHit hit, 30f, groundLayer))
            {
                Vector3 spawnPos = hit.point + Vector3.up * 0.1f;

                // 3. 위치 중복 검사
                bool overlap = activeCoins.Exists(c =>
                    Vector3.Distance(c.transform.position, spawnPos) < 0.5f);
                if (overlap) continue;

                // 4. 코인 풀에서 소환
                Coin coin = coinPool.Dequeue();
                if (coin != null)
                {
                    coin.transform.position = spawnPos;
                    activeCoins.Add(coin);
                    spawned++;
                }
            }
        }
    }

    void ClearCoins()
    {
        foreach (var coin in activeCoins)
        {
            coinPool.Enqueue(coin);
        }
        activeCoins.Clear();
    }

}
