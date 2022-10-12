using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// ��������� ��������� ��� float InputField
/// </summary>
[RequireComponent(typeof(InputField))]
public class InputValidator : MonoBehaviour
{
    /// <summary>
    /// �������� ��������, X - �����������, Y - ������������
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
    /// �������� �������� � ������ - ���� �� �������������, ������ �� ���������
    /// </summary>
    public void ValidateRange()
    {
        float current = (float)Convert.ToDouble(inputField.text.Replace('.', ','));
        if (current > valuesRange.y || current < valuesRange.x)
            inputField.text = defaultValue.ToString().Replace(',', '.');
    }
}