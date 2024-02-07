using UnityEngine;
using UnityEngine.UI;

public class SoundsController : MonoBehaviour
{
    [SerializeField] private Image _imageSound;

    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;

    private bool _isPlaying = true;

    private void Start()
    {
        _imageSound.sprite = _soundOn;
    }

    public void EnableSoudns()
    {
        _isPlaying = !_isPlaying;
        if (_isPlaying == true)
        {
            _imageSound.sprite = _soundOn;
            AudioListener.volume = 1.0f;
        }

        if (_isPlaying == false)
        {
            _imageSound.sprite = _soundOff;
            AudioListener.volume = 0f;
        }
    }
}
