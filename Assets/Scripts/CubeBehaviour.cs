using UnityEngine;

/// <summary>
/// �������� �� ��������� ����
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class CubeBehaviour : MonoBehaviour
{
    /// <summary>
    /// ������ ������ � �����������
    /// </summary>
    [SerializeField]
    private GameObject settingsPopup;
    /// <summary>
    /// ����������� �������� ����
    /// </summary>
    [SerializeField]
    private Vector3 throwDirection;

    private bool isCubeStartedMoving = false;

    /// <summary>
    /// �������� ��������� ���������� popup � ����������� ��� ����� �� �����
    /// </summary>
    private void OnMouseDown()
    {
        if (isCubeStartedMoving)
        {
            settingsPopup.SetActive(false);
            return;
        }
        settingsPopup.SetActive(!settingsPopup.activeInHierarchy);
    }

    /// <summary>
    /// ������� ����� �� ������������ ���������� � ������������ ���������
    /// </summary>
    public void ThrowCube()
    {
        if (isCubeStartedMoving)
        {
            return;
        } 
        isCubeStartedMoving = true;
        Rigidbody cubeBody = GetComponent<Rigidbody>();
        cubeBody.AddForce(throwDirection, ForceMode.Force);
    }
}
