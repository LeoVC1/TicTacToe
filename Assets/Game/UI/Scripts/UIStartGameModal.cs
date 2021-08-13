using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;

public class UIStartGameModal : UIModal
{
    [Header("Controller References:")]
    [SerializeField]
    private GameController _gameController;

    [Header("UI References:")]
    [SerializeField]
    private TMP_Dropdown _difficultyDropdown;
    [SerializeField]
    private Toggle _markToggleX;
    [SerializeField]
    private Button _btnStartGame;

    [HideInInspector]
    public bool _playAsX;

    private AIController.Difficulty _selectedDifficulty = AIController.Difficulty.EASY;

    private void Awake()
    {
        SetupDropdown();

        _markToggleX.onValueChanged.AddListener(SetPlayerMark);

        _playAsX = _markToggleX.isOn;

        _btnStartGame.onClick.AddListener(StartGame);
    }

    private void SetupDropdown()
    {
        List<string> difficulties = new List<string>
        {
            "EASY",
            "MEDIUM",
            "HARD",
            "IMPOSSIBLE"
        };

        _difficultyDropdown.AddOptions(difficulties);

        _difficultyDropdown.onValueChanged.AddListener(delegate 
        {
            switch (_difficultyDropdown.value)
            {
                case 0:
                    _selectedDifficulty = AIController.Difficulty.EASY;
                    break;
                case 1:
                    _selectedDifficulty = AIController.Difficulty.MEDIUM;
                    break;
                case 2:
                    _selectedDifficulty = AIController.Difficulty.HARD;
                    break;
                case 3:
                    _selectedDifficulty = AIController.Difficulty.IMPOSSIBLE;
                    break;
            }
        });
    }

    private void SetPlayerMark(bool playAsX)
    {
        _playAsX = playAsX;
    }

    private void StartGame()
    {
        CloseModal();
    }

    protected override IEnumerator Fade(float scale, float duration)
    {
        yield return base.Fade(scale, duration);

        if (scale == 0)
        {
            _gameController.StartGame(_playAsX ? "X" : "O", _selectedDifficulty);
        }
    }
}
