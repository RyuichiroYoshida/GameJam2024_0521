using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : MonoBehaviour
{
    [SerializeField] PlayerManager _playerManager = null;
    [SerializeField] UIManager _uiManager = null;

    /// <summary>�^�C��</summary>
    public float Gm_time;
    /// <summary>�X�R�A</summary>
    public int Gm_score;

    void GmChanged()
    {
        Gm_time = 0.0f;
        Gm_score = 0;
    }

    void GmUpdate()
    {
        _playerManager.GmUpdate();
        _uiManager.InGameText(Gm_time, Gm_score);

        //�o�ߎ��Ԃ̊Ǘ�
        Gm_time += Time.deltaTime;
    }
}
