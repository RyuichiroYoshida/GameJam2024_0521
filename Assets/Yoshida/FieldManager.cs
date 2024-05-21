using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    // シングルトン参考
    // https://qiita.com/Teach/items/c146c7939db7acbd7eee
    public static FieldManager Instance;

    [SerializeField, Tooltip("流すフィールドのプレハブ")] GameObject[] _fieldPrefabs;
    [SerializeField, Tooltip("スクロール速度")] float _scrollSpeed;
    [SerializeField, Tooltip("フィールドのランダム生成化")] bool _randomField;
    
    int _fieldIndex = 1;
    List<GameObject> _fieldObjects = new();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // 開始時のフィールド生成
        _fieldObjects.Add(Instantiate(_fieldPrefabs[0], new Vector3(0, 0, 0), Quaternion.identity));
        _fieldObjects.Add(Instantiate(_fieldPrefabs[1], new Vector3(0, 10, 0), Quaternion.identity));
    }

    void FixedUpdate()
    {
        // フィールドを下にスクロール
        foreach (var item in _fieldObjects)
        {
            item.transform.position += Vector3.down * _scrollSpeed;
        }
        
        if (_fieldObjects[0].transform.position.y >= -10) return;

        if (_randomField)
        {
            _fieldIndex = Random.Range(0, _fieldPrefabs.Length);
        }
        else
        {
            _fieldIndex++;
            if (_fieldIndex >= _fieldPrefabs.Length)
            {
                _fieldIndex = 0;
            }
        }

        Destroy(_fieldObjects[0]);
        _fieldObjects.RemoveAt(0);
        _fieldObjects.Add(Instantiate(_fieldPrefabs[_fieldIndex], new Vector3(0, 10, 0), Quaternion.identity));

    }


    /// <summary>
    /// フィールドスクロール速度加算メソッド
    /// </summary>
    /// <param name="value">加算量</param>
    public void AddSpeed(float value)
    {
        _scrollSpeed += value;
    }
}