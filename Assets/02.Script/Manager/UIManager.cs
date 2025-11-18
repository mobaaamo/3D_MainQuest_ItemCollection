using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }  

    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        panel.SetActive(false);

        resetButton.onClick.AddListener(GameManager.Instance.RestartGame);
        quitButton.onClick.AddListener(GameManager.Instance.QuitGame);
        
    }
    public void ClearPanel()
    {
        panel.SetActive(true);
    }
    public void UpdateScoreTextUI(int count, int max)
    {
        scoreText.text = $"Current/Max : {count}/{max}";
    }
}
