using System.Collections;
using UnityEngine;

/// <summary>
/// Спавнит кубы
/// </summary>
public class CubeSpawner : MonoBehaviour
{
    /// <summary>
    /// Префаб куба для спавна
    /// </summary>
    [SerializeField] 
    private GameObject cube;
    /// <summary>
    /// Диапазон позиций спавна кубика по оси X (компонента x - минимальное значение, y - максимальное)
    /// </summary>
    [SerializeField]
    private Vector2 xPositionRange;
    /// <summary>
    /// Диапазон позиций спавна кубика по оси Z (компонента x - минимальное значение, y - максимальное)
    /// </summary>
    [SerializeField]
    private Vector2 zPositionRange;
    /// <summary>
    /// Диапазон позиций спавна кубика по оси Y (компонента x - минимальное значение, y - максимальное)
    /// </summary>
    [SerializeField]
    private Vector2 yPositionRange;

    /// <summary>
    /// Спавнит куб на случайной позиции, по диапазонам, указанным в полях класса
    /// </summary>
    public void SpawnCube()
    {
        Vector3 position = new Vector3(Random.Range(xPositionRange.x, xPositionRange.y),
            Random.Range(yPositionRange.x, yPositionRange.y),
            Random.Range(zPositionRange.x, zPositionRange.y));
        Instantiate(cube, position, Quaternion.identity, transform);
    }

    /// <summary>
    /// Включает/выключает корутину спавна кубов
    /// </summary>
    public void SetSpawnMode()
    {
        if (UiController.instance.IsAutoSpawning)
        {
            StartCoroutine(SpawnCoroutine());
            return;
        }
        StopAllCoroutines();
    }

    /// <summary>
    /// Корутина для постоянного спавна кубов
    /// </summary>
    /// <returns>Ждет указанное в UI время</returns>
    public IEnumerator SpawnCoroutine()
    {
        while (UiController.instance.IsAutoSpawning)
        {
            yield return new WaitForSeconds(UiController.instance.SpawnTime);
            SpawnCube();
        }
    }

    public void OnEnable()
    {
        SetSpawnMode();
    }
}
