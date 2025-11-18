using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private CoinSpawn coinSpawn;


    private void Start()
    {
        UpdateScoreText();
    }
    public void DiscreaseScore(int amount)
    {
       
        coinSpawn.coinCount -= amount;
        UpdateScoreText();
    }
    public void UpdateScoreText()
    {
        scoreText.text = $"Coins Left : + { coinSpawn.coinCount}";
    }
}
