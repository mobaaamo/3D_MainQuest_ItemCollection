using UnityEngine;

public class Coin : MonoBehaviour
{
    public System.Action<Coin> OnTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnTrigger?.Invoke(this);
            
        }
    }
}
