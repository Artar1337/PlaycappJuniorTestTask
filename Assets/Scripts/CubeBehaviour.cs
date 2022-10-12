using System.Collections;
using UnityEngine;

/// <summary>
/// ќтвечает за поведение куба
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class CubeBehaviour : MonoBehaviour
{
    private const string COLLIDINGLAYERNAME = "Cube";
    private const string DESTROYINGLAYERNAME = "DestroyZone";

    /// <summary>
    /// Ќаправление движени€ куба
    /// </summary>
    [SerializeField]
    private Vector3 throwDirection;

    private bool isCubeStartedMoving = false;
    private float speedMultiplier = 1f;
    private float distance = 1f;
    private float currentDistance = 0f;
    private int cubeLayerMask;
    private int destroyZoneLayerMask;

    private void Start()
    {
        cubeLayerMask = LayerMask.NameToLayer(COLLIDINGLAYERNAME);
        destroyZoneLayerMask = LayerMask.NameToLayer(DESTROYINGLAYERNAME);
        speedMultiplier = UiController.instance.Speed;
        distance = UiController.instance.Distance;
    }

    /// <summary>
    /// Ѕросает кубик на определенное рассто€ние с определенной скоростью
    /// </summary>
    public void ThrowCube()
    {
        if (isCubeStartedMoving)
        {
            return;
        } 
        isCubeStartedMoving = true;
        StartCoroutine(MoveCoroutine());
    }

    /// <summary>
    /// ѕередвигает кубик, если было достигнуто нужное рассто€ние - уничтожает
    /// </summary>
    /// <returns>ќжидает конца каждого FixedUpdate</returns>
    private IEnumerator MoveCoroutine()
    {
        Vector3 speedVector = throwDirection * speedMultiplier;
        Vector3 lastPosition = transform.position;
        while (currentDistance < distance)
        {
            transform.position += speedVector * Time.fixedDeltaTime;
            currentDistance += Vector3.Distance(transform.position, lastPosition);
            lastPosition = transform.position;
            yield return new WaitForFixedUpdate();
        }
        Destroy(gameObject);
    }

    /// <summary>
    /// ѕри контакте с поверхностью (кроме кубов) запускаем куб вперед, если опци€ активна
    /// </summary>
    /// <param name="collision"> оллизи€</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == destroyZoneLayerMask)
            Destroy(gameObject);
        else if (cubeLayerMask != collision.gameObject.layer)
            ThrowCube(); 
    }
}
