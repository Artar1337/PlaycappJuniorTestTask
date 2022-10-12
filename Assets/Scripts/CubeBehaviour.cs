using UnityEngine;

/// <summary>
/// Отвечает за поведение куба
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class CubeBehaviour : MonoBehaviour
{
    /// <summary>
    /// Префаб попапа с настройками
    /// </summary>
    [SerializeField]
    private GameObject settingsPopup;
    /// <summary>
    /// Направление движения куба
    /// </summary>
    [SerializeField]
    private Vector3 throwDirection;

    private bool isCubeStartedMoving = false;

    /// <summary>
    /// Изменяет состояние активности popup с настройками при клике на кубик
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
    /// Бросает кубик на определенное расстояние с определенной скоростью
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
