using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState { GameReady, Ongoing, GameClear, GameOver }

    public static GameManager Instance { get; private set; }

    public GameState globalGameState { get; private set; }

    [SerializeField] private CoinSpawn CoinSpawn;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        SetState(GameState.GameReady);
        CoinSpawn.spawnStart();
    }

    public void SetState(GameState newstate)
    {
        globalGameState = newstate;

    if (newstate == GameState.GameClear)
        {
            GameCler();
        }
    }

    private void GameCler()
    {
        Time.timeScale = 0f;
        if(UIManager.Instance != null)
        {
            UIManager.Instance.ClearPanel();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
   

}
