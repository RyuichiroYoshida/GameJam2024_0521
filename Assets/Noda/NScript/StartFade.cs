using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class StartFade : MonoBehaviour
{
    [SerializeField]UnityEngine.UI.Image image;
    void Start()
    {
        this.image.DOFade(endValue: 0f, duration: 1f);
        Invoke("Destroy", 1f);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
