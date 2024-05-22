using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class InGameManager : MonoBehaviour
{
    [SerializeField] PlayerManager _playerManager = null;
    [SerializeField] UIManager _uiManager = null;

    /// <summary>�^�C��</summary>
    public float Gm_time;
    /// <summary>�X�R�A</summary>
    public int Gm_score;

    //���y
    [SerializeField] public AudioClip _audioClip1 = null;
    [SerializeField] public AudioClip _audioClip2 = null;
    private AudioSource[] _audioSource;

    public void GmChanged()
    {
        Gm_time = 0.0f;
        Gm_score = 0;

        //���y�𗬂�
        _audioSource = gameObject.GetComponents<AudioSource>();
        _audioSource[0].clip = _audioClip1;
        _audioSource[1].clip = _audioClip2;
        _audioSource[0].Play();
        _audioSource[1].Play();
    }

    public void GmUpdate()
    {
        //�ق����\�b�h����
        _playerManager.GmUpdate();
        _uiManager.InGameText(Gm_time, Gm_score);
        _uiManager.hpText(_playerManager._health);

        //�o�ߎ��Ԃ̊Ǘ�
        Gm_time += Time.deltaTime;

    }
}
