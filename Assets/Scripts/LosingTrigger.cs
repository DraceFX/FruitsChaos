using TMPro;
using UnityEngine;

public class LosingTrigger : MonoBehaviour
{
    [SerializeField] private float _timeToStayInTrigger = 1f;
    [SerializeField] private GameObject _losingMenu;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Points _maxScore;

    private bool _isObjInTrigger = false;
    private float _timer = 0f;
    private GameObject _goInTrigger = null;

    private void Start()
    {
        _pauseButton.SetActive(true);
        _losingMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _goInTrigger = collision.gameObject;
        _isObjInTrigger = true;
        _timer = 0f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _goInTrigger = null;
        _isObjInTrigger = false;
        _timer = 0f;
    }

    private void Update()
    {
        if (_isObjInTrigger == true && _goInTrigger != null)
        {
            _timer += Time.deltaTime;

            if (_timer >= _timeToStayInTrigger)
            {
                Losing();
                _goInTrigger = null;
                _isObjInTrigger = false;
            }
        }
    }

    private void Losing()
    {
        _losingMenu.SetActive(true);
        _scoreText.text = $"Вы набрали {_maxScore.point}";
        _pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }
}
