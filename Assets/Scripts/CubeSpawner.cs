using UnityEngine;

/// <summary>
/// ������� ����
/// </summary>
public class CubeSpawner : MonoBehaviour
{
    /// <summary>
    /// ������ ���� ��� ������
    /// </summary>
    [SerializeField] 
    private GameObject cube;
    /// <summary>
    /// �������� ������� ������ ������ �� ��� X (���������� x - ����������� ��������, y - ������������)
    /// </summary>
    [SerializeField]
    private Vector2 xPositionRange;
    /// <summary>
    /// �������� ������� ������ ������ �� ��� Z (���������� x - ����������� ��������, y - ������������)
    /// </summary>
    [SerializeField]
    private Vector2 zPositionRange;
    /// <summary>
    /// �������� ������� ������ ������ �� ��� Y (���������� x - ����������� ��������, y - ������������)
    /// </summary>
    [SerializeField]
    private Vector2 yPositionRange;

    /// <summary>
    /// ������� ��� �� ��������� �������, �� ����������, ��������� � ����� ������
    /// </summary>
    public void SpawnCube()
    {
        Vector3 position = new Vector3(Random.Range(xPositionRange.x, xPositionRange.y),
            Random.Range(yPositionRange.x, yPositionRange.y),
            Random.Range(zPositionRange.x, zPositionRange.y));
        Instantiate(cube, position, Quaternion.identity, transform);
    }
}