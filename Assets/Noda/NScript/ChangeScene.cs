using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] GameObject _start = null;
    [SerializeField] UnityEngine.UI.Image image;

    public void SceneOut()
    {
        this.image.DOFade(endValue: 3f, duration: 3f);
        Destroy(_start);
        Invoke("changeScene", 1.5f);
    } 

    public void changeScene()
    {
        SceneManager.LoadScene("InGame");
    }
}
