using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _topScoreText;

    private int _topScore;
    void Start()
    {
        _topScore = PlayerPrefs.GetInt("TOP");
        _topScoreText.text = $"Ваш лучший результат {_topScore}";
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
    }
}
