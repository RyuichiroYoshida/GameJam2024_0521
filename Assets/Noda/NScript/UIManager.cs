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

    Text _timeText;
    Text _scoreText;
    Text _resultText;

    private float _score;
    void start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();

        _timeText = _timeObject.GetComponent<Text>();
        _scoreText = _scoreObject.GetComponent<Text>();
        _resultText = _resultObject.GetComponent<Text>();
    }

    public void InGameText(float _time, int _score)
    {
        if (_gameManager.currentGameState == GameState.InGame)
        {
            _timeObject.SetActive(true);
            _scoreObject.SetActive(true);
            _timeText.text = "Time:" + _time.ToString("00");
            _scoreText.text = "Score:" + _score.ToString("000000");
        }
        else
        {
            Debug.Log("ステートが違います");
        }
    }//InGame中に呼び出す

    public void EndText(int _result)
    {
        if (_gameManager.currentGameState == GameState.Result)
        {
            _resultObject.SetActive(true);
            _resultText.text = "Result:" + _result.ToString("000000");
            _timeObject.SetActive(false);
            _scoreObject.SetActive(false);
        }
        else
        {
            Debug.Log("ステートが違います");
        }
    }//resultになったら呼び出す
}
