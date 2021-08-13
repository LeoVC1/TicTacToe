using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverModal : UIModal
{
    [Header("UI References:")]
    [SerializeField]
    private UIStartGameModal startGameModal;
    [SerializeField]
    private TextMeshProUGUI _winnerText;
    [SerializeField]
    private TextMeshProUGUI _playerPontuation;
    [SerializeField]
    private TextMeshProUGUI _aiPontuation;
    [SerializeField]
    private Button btnRestart;

    private void Awake()
    {
        btnRestart.onClick.AddListener(CloseModal);
    }

    public void OpenModal(string winner)
    {
        int playerWins = 0;
        int aiWins = 0;

        if (winner == "draw")
        {
            _winnerText.text = "DRAW!";

            playerWins = PlayerPrefs.GetInt("PlayerWins");
            aiWins = PlayerPrefs.GetInt("AIWins");
        }
        else
        {
            bool playerWin = startGameModal._playAsX && winner == "X" || !startGameModal._playAsX && winner == "O";

            _winnerText.text = (playerWin ? "Player": "Engine") + " wins!";

            playerWins = PlayerPrefs.GetInt("PlayerWins");
            aiWins = PlayerPrefs.GetInt("AIWins");

            if(playerWin)
            {
                playerWins++;
                PlayerPrefs.SetInt("PlayerWins", playerWins);
            }
            else
            {
                aiWins++;
                PlayerPrefs.SetInt("AIWins", aiWins);
            }
        }

        _playerPontuation.text = playerWins.ToString();
        _aiPontuation.text = aiWins.ToString();

        base.OpenModal();
    }

    protected override IEnumerator Fade(float scale, float duration)
    {
        yield return base.Fade(scale, duration);

        if (scale == 0)
        {
            startGameModal.OpenModal();
        }
    }
}
