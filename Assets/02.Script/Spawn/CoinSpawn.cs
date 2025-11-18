using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public Coin coinPrefab;
    public int coinCount = 10;
    public LayerMask groundLayer;

    private ObjectPool<Coin> coinPool;

    private void Awake()
    {
        coinPool = new ObjectPool<Coin>(coinPrefab, coinCount, transform);
    }

    private void Start()
    {
        for(int i =0; i< coinCount; i++)
        {
            SpawnRandomCoin();
        }
    }
    void SpawnRandomCoin()
    {
        Coin coin = coinPool.Dequeue();
        coin.SetPool(coinPool);

        float randX = Random.Range(-50, 51);
        float randZ = Random.Range(-50, 51);

        Vector3 rayStart = new Vector3(randX, 20f, randZ); //랜덤한 위치 생성 20f에서 레이케스트 쏨

        RaycastHit hit;

        if(Physics.Raycast(rayStart, Vector3.down, out hit, 50f, groundLayer))//레이케스트로 바닥 감지 후 생성
        {
            coin.transform.position = hit.point + Vector3.up * 0.3f;  //Vector3.up * 0.3 다른 오브젝트 안에 안들어가게 살짝 띄움
            coin.gameObject.SetActive(true);
        }

    }


}