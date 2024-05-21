using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public static FieldManager Instance;

    [SerializeField] GameObject[] _fieldPrefabs;
    [SerializeField] float _scrollSpeed;
    [SerializeField] bool _randomField;
    
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
        _fieldObjects.Add(Instantiate(_fieldPrefabs[0], new Vector3(0, 0, 0), Quaternion.identity));
        _fieldObjects.Add(Instantiate(_fieldPrefabs[1], new Vector3(0, 10, 0), Quaternion.identity));
    }

    void FixedUpdate()
    {
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


    public void AddSpeed(float value)
    {
        _scrollSpeed += value;
    }
}