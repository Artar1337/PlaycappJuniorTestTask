using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

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
    [SerializeField]
    private Toggle autoLaunch;

    public float Speed
    {
        get => (float)Convert.ToDouble(speedInput.text.Replace('.', ','));
        set => speedInput.text = value.ToString();
    }

    public float SpawnTime
    {
        get => (float)Convert.ToDouble(timeInput.text.Replace('.', ','));
        set => timeInput.text = value.ToString();
    }

    public float Distance
    {
        get => (float)Convert.ToDouble(distanceInput.text.Replace('.', ','));
        set => distanceInput.text = value.ToString();
    }

    public bool IsAutoSpawning
    {
        get => autoSpawn.isOn;
        set => autoSpawn.isOn = value;
    }

    public bool IsAutoLaunching
    {
        get => autoLaunch.isOn;
        set => autoLaunch.isOn = value;
    }
}
