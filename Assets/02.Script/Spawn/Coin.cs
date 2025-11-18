using UnityEngine;

public class Coin : MonoBehaviour
{
    private ObjectPool<Coin> coinPool;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            coinPool.Enqueue(this);
        }
    }

    public void SetPool(ObjectPool<Coin> pool)
    {
        this.coinPool = pool;
    }
}
