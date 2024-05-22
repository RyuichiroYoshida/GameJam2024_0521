using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ 
    private GameManager _gameManager;

    [SerializeField] GameObject _timeObject = null;
    [SerializeField] GameObject _scoreObject = null;
    [SerializeField] GameObject _resultObject = null;
    [SerializeField] GameObject _resultCanvas = null;

    Text _timeText;
    Text _scoreText;
    Text _resultText;

    private float _score;
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();

        _timeText = _timeObject.GetComponent<Text>();
        _scoreText = _scoreObject.GetComponent<Text>();
        _resultText = _resultObject.GetComponent<Text>();
    }

    public void InGameText(float time, int score)
    {
        _resultCanvas.SetActive(false);
        _timeText.text = "Time:" + time.ToString("0000");
        _scoreText.text = "Score:" + score.ToString("000000");
    }

    public void ResultText(int result)
    {
        _timeObject.SetActive(false);
        _scoreObject.SetActive(false);
        _resultObject.SetActive(true);
        _resultText.text = "Result:" + result.ToString("000000");
    }
}
