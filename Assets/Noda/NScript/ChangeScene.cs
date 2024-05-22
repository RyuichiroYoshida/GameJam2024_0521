using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] GameObject _ui = null;
    [SerializeField] UnityEngine.UI.Image image;
    [SerializeField] bool _inGame;
    GameManager _gameManager;

    public void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        this.image.DOFade(endValue: 0f, duration: 3f);
        if(_inGame)
        {
            _gameManager.SetGameState(GameState.InGame);
        }
        else
        {
            _gameManager.SetGameState(GameState.Title);
        }
    }
    public void SceneOut()
    {
        this.image.DOFade(endValue: 3f, duration: 3f);
        Destroy(_ui);
        Invoke("changeScene", 1.5f);
    } 

    public void changeScene()
    {
        if(_inGame == false)
            SceneManager.LoadScene("InGame");
        if(_inGame == true)
            SceneManager.LoadScene("Start");
    }

    public void GameOverFade()
    {
        this.image.DOFade(endValue: 1f, duration: 1f);
    }
}
