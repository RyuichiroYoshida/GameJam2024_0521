using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class StartFade : MonoBehaviour
{
    [SerializeField]UnityEngine.UI.Image image;
    GameManager _gameManager;
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.SetGameState(GameState.InGame);
        this.image.DOFade(endValue: 0f, duration: 1f);
        Invoke("Destroy", 1f);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
