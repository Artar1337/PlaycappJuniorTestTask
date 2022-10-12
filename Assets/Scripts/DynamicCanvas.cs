using UnityEngine;

/// <summary>
/// Поддерживает канвас в одном и том же положении относительно камеры
/// </summary>
public class DynamicCanvas : MonoBehaviour
{
    private Vector3 offset;

    private void Start()
    {
        Vector3 parentScale = transform.parent.transform.localScale;
        offset = transform.localPosition;
        offset = new Vector3(offset.x * parentScale.x, 
            offset.y * parentScale.y, offset.z * parentScale.z);
        transform.localPosition = Vector3.zero;
    }

    private void LateUpdate()
    {
        transform.position = transform.parent.transform.position + offset;
        transform.rotation = Quaternion.identity;
    }
}
