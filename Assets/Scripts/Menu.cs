using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuPause;
    [SerializeField] private GameObject _losingMenu;

    public void PauseButton()
    {
        _menuPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeButton()
    {
        _menuPause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void RestartButton()
    {
        _losingMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
