using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance { get; private set; }

    private int totalCoins = 0;
    private int currentCoin = 0;

    private void Awake()
    {
        instance = this;
    }

    public void RegisterCoin()
    {
        totalCoins++;
        currentCoin++;
        UIManager.Instance.UpdateScoreTextUI(currentCoin, totalCoins);
    }

    public void CoinCollected()
    {
        currentCoin--;
        UIManager.Instance.UpdateScoreTextUI(currentCoin, totalCoins);

        if (currentCoin <= 0)
        {
            GameManager.Instance.SetState(GameManager.GameState.GameClear);
            
        }
    }
}
