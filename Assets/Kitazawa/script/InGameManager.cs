using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class InGameManager : MonoBehaviour
{
    [SerializeField] PlayerManager _playerManager = null;
    [SerializeField] UIManager _uiManager = null;

    /// <summary>タイム</summary>
    public float Gm_time;
    /// <summary>スコア</summary>
    public int Gm_score;

    //音楽
    [SerializeField] public AudioClip _audioClip1 = null;
    [SerializeField] public AudioClip _audioClip2 = null;
    private AudioSource[] _audioSource;

    public void GmChanged()
    {
        Gm_time = 0.0f;
        Gm_score = 0;

        //音楽を流す
        _audioSource = gameObject.GetComponents<AudioSource>();
        _audioSource[0].clip = _audioClip1;
        _audioSource[1].clip = _audioClip2;
        _audioSource[0].Play();
        _audioSource[1].Play();
    }

    public void GmUpdate()
    {
        //ほかメソッドを回す
        _playerManager.GmUpdate();
        _uiManager.InGameText(Gm_time, Gm_score);
        _uiManager.hpText(_playerManager._health);

        //経過時間の管理
        Gm_time += Time.deltaTime;

    }
}
