using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] float _speedValue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FieldManager.Instance.AddSpeed(_speedValue);
    }
}
