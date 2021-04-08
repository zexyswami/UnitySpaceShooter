using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Sprite[] _livesSprite;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private float _flicker = 0.5f;
    [SerializeField]
    private Text _restartText;



    // Start is called before the first frame update
    void Start ()
    {
        _scoreText.text = "Score : " + 0;
        _gameOverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        
    }

    public void UpdateScore ( int score )
    {
        _scoreText.text = "Score : " + score;
    }
    
    public void UpdateLives (int currentLives )
    {
        _livesImg.sprite = _livesSprite[currentLives];
        
        if(currentLives < 1 )
        {
            _gameOverText.gameObject.SetActive(true);
            StartCoroutine(GameOverRoutine(_flicker));
            _restartText.gameObject.SetActive(true);
        }
        
    }

    public IEnumerator GameOverRoutine(float time)
    {
        while (true) 
         { 
        _gameOverText.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        _gameOverText.gameObject.SetActive(false);
        yield return new WaitForSeconds(time);
        }
    }
}
