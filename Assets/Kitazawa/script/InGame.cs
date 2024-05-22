using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class InGame : MonoBehaviour
{
    [SerializeField] PlayerManager _playerManager = null;
    [SerializeField] UIManager _uiManager = null;

    /// <summary>タイム</summary>
    public float Gm_time;
    /// <summary>スコア</summary>
    public int Gm_score;

    //音楽
    //[SerializeField] public AudioClip audioClip1 = null;
    //[SerializeField] public AudioClip audioClip2 = null;
    //private AudioSource audioSource;

    public void GmChanged()
    {
        Gm_time = 0.0f;
        Gm_score = 0;

        //音楽を流す
        //audioSource.clip = audioClip1;
        //audioSource.Play();
    }

    public void GmUpdate()
    {
        _playerManager.GmUpdate();
        _uiManager.InGameText(Gm_time, Gm_score);

        //経過時間の管理
        Gm_time += Time.deltaTime;

    }
}
