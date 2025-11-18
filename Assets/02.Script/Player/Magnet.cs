using UnityEngine;

public class Magnet : MonoBehaviour
{

    private Transform player;
    [SerializeField] private float magnetSpeed = 1.0f;

    private void Awake()
    {
        player = transform.root;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out Coin coin))
        {
            Vector3 dir = (player.position - coin.transform.position).normalized;
            coin.transform.position += dir * magnetSpeed * Time.deltaTime;
        }
    }

}
