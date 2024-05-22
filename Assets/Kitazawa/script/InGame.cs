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

    public void GmChanged()
    {
        Gm_time = 0.0f;
        Gm_score = 0;
    }

    public void GmUpdate()
    {
        _playerManager.GmUpdate();
        _uiManager.InGameText(Gm_time, Gm_score);

        //経過時間の管理
        Gm_time += Time.deltaTime;

        _uiManager.InGameText(Gm_time, Gm_score);
    }
}
