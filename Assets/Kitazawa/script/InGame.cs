using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class InGame : MonoBehaviour
{
    [SerializeField] PlayerManager _playerManager = null;
    [SerializeField] UIManager _uiManager = null;

    /// <summary>�^�C��</summary>
    public float Gm_time;
    /// <summary>�X�R�A</summary>
    public int Gm_score;

    //���y
    //[SerializeField] public AudioClip audioClip1 = null;
    //[SerializeField] public AudioClip audioClip2 = null;
    //private AudioSource audioSource;

    public void GmChanged()
    {
        Gm_time = 0.0f;
        Gm_score = 0;

        //���y�𗬂�
        //audioSource.clip = audioClip1;
        //audioSource.Play();
    }

    public void GmUpdate()
    {
        _playerManager.GmUpdate();
        _uiManager.InGameText(Gm_time, Gm_score);

        //�o�ߎ��Ԃ̊Ǘ�
        Gm_time += Time.deltaTime;

    }
}
