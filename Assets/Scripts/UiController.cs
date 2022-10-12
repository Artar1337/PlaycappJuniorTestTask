using UnityEngine;
using System;
using UnityEngine.UI;

/// <summary>
/// ���������� �������������� � UI
/// </summary>
public class UiController : MonoBehaviour
{
    #region Singleton
    public static UiController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("UI CONTROLLER instance error!");
            return;
        }
        instance = this;
    }
    #endregion

    [SerializeField]
    private InputField speedInput;
    [SerializeField]
    private InputField timeInput;
    [SerializeField]
    private InputField distanceInput;
    [SerializeField]
    private Toggle autoSpawn;

    private InputValidator speedValidator;
    private InputValidator timeValidator;
    private InputValidator distanceValidator;

    public float Speed
    {
        get => GetValidatedValue(speedInput, speedValidator);
        set => speedInput.text = value.ToString();
    }

    public float SpawnTime
    {
        get => GetValidatedValue(timeInput, timeValidator); 
        set => timeInput.text = value.ToString();
    }

    public float Distance
    {
        get => GetValidatedValue(distanceInput, distanceValidator); 
        set => distanceInput.text = value.ToString();
    }

    public bool IsAutoSpawning
    {
        get => autoSpawn.isOn;
        set => autoSpawn.isOn = value;
    }
    
    private void Start()
    {
        speedValidator = speedInput.GetComponent<InputValidator>();
        timeValidator = timeInput.GetComponent<InputValidator>();
        distanceValidator = distanceInput.GetComponent<InputValidator>();
    }

    /// <summary>
    /// ���������� ������������ �������� �� ���������� ����
    /// </summary>
    /// <param name="field">��������� ����</param>
    /// <param name="validator">��������� ����</param>
    /// <returns></returns>
    private float GetValidatedValue(InputField field, InputValidator validator)
    {
        validator.ValidateRange();
        return (float)Convert.ToDouble(field.text.Replace('.', ','));
    }
}
