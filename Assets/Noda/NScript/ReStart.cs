using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    [SerializeField] GameObject _result = null;
    [SerializeField] UnityEngine.UI.Image image;

    public void Start()
    {
        this.image.DOFade(endValue: 0f, duration: 3f);
    }
    public void SceneOut()
    {
        this.image.DOFade(endValue: 3f, duration: 3f);
        Destroy(_result);
        Invoke("changeScene", 1.5f);
    }

    public void changeScene()
    {
        SceneManager.LoadScene("Start");
    }
}
