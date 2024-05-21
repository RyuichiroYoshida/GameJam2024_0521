using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]GameObject _start = null;

    public void SceneOut()
    {
        Destroy(_start);
        GetComponent<Renderer>().material.DOFade(0, 2);
        Invoke("changeScene", 2f);
    } 

    public void changeScene()
    {
        SceneManager.LoadScene("Main");
    }
}
