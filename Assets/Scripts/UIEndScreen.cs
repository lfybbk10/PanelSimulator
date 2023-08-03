using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIEndScreen : MonoBehaviour
{
    [SerializeField] private ScenarioController _scenarioController;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _screen;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Text _text;

    private void Awake()
    {
        _restartButton.onClick.AddListener(Restart);
    }

    private void OnEnable()
    {
        _scenarioController.OnScenarioCompleted += SetCompleteText;
        _scenarioController.OnScenarioFailed += SetFailedText;
    }

    private void OnDisable()
    {
        _scenarioController.OnScenarioCompleted -= SetCompleteText;
        _scenarioController.OnScenarioFailed -= SetFailedText;
    }

    private void ShowScreen()
    {
        _screen.SetActive(true);
    }

    private void SetCompleteText()
    {
        _text.text = "Сценарий успешно пройден\nВремя прохождения - " + _timer.Time + "\nКоличество попыток - " +
                     _scenarioController.CurrErrorsCount;
        ShowScreen();
    }

    private void SetFailedText()
    {
        _text.text = "Вы ошиблись 3 раза!\nНачните прохождение заново";
        ShowScreen();
    }

    private void Restart() => SceneManager.LoadScene(0);
}
