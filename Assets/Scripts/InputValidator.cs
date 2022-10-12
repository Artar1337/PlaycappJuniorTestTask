using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// Валидатор диапазона для float InputField
/// </summary>
[RequireComponent(typeof(InputField))]
public class InputValidator : MonoBehaviour
{
    /// <summary>
    /// Диапазон значений, X - минимальное, Y - максимальное
    /// </summary>
    [SerializeField]
    private Vector2 valuesRange;
    [SerializeField]
    private float defaultValue = 1f;

    private InputField inputField;

    private void Start()
    {
        inputField = GetComponent<InputField>();
    }

    /// <summary>
    /// Проверка значения в инпуте - если не соответствует, ставим по умолчанию
    /// </summary>
    public void ValidateRange()
    {
        float current;
        try 
        { 
            current = (float)Convert.ToDouble(inputField.text.Replace('.', ',')); 
        }
        catch (FormatException)
        {
            current = defaultValue;
        }
        if (current > valuesRange.y || current < valuesRange.x)
            inputField.text = defaultValue.ToString().Replace(',', '.');
    }
}
