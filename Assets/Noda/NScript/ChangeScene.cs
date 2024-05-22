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

    public void Start()
    {
        this.image.DOFade(endValue: 0f, duration: 3f);
    }
    public void SceneOut()
    {
        this.image.DOFade(endValue: 3f, duration: 3f);
        Destroy(_ui);
        Invoke("changeScene", 1.5f);
    } 

    public void changeScene()
    {
        if(_inGame == true)
            SceneManager.LoadScene("InGame");
        if(_inGame == false)
            SceneManager.LoadScene("Start");
    }
}
