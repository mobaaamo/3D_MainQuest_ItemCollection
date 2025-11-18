using UnityEngine;

public class Coin : MonoBehaviour
{
    private ObjectPool<Coin> coinPool;
    [SerializeField] private AudioClip coinClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            CoinCounter.instance.CoinCollected();
            gameObject.SetActive(false);
            coinPool.Enqueue(this);
        }
    }

    public void SetPool(ObjectPool<Coin> pool)
    {
        this.coinPool = pool;
    }
}
