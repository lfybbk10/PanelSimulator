using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UITimer : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        _timer.OnTimeChanged += UpdateText;
    }

    private void OnDisable()
    {
        _timer.OnTimeChanged -= UpdateText;
    }

    private void UpdateText(float value)
    {
        _text.text = "Время: " + (int)value + " с.";
    }
}
