using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;


class DontDestroyOnLoad:MonoBehaviour
{
    public  void Start()
    {
       DontDestroyOnLoad(this.GameObject());
    }
}

