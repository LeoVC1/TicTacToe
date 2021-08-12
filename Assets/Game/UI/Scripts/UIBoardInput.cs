using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBoardInput : MonoBehaviour
{
    [Header("External References:")]
    [SerializeField]
    private HumanController humanController;
    [SerializeField]
    private Board board;

    [Header("UI References:")]
    [SerializeField]
    private CanvasGroup m_CanvasGroup;
    [SerializeField]
    private Button[] buttons;

    /// <summary>
    /// Setup all buttons in the UI with the player mark
    /// </summary>
    /// <param name="playerMark"></param>
    public void SetupPlayerInputs()
    {
        int k = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++, k++)
            {
                SetupButton(buttons[k], i, j);
            }
        }
    }

    private void SetupButton(Button button, int i, int j)
    {
        button.onClick.AddListener(delegate
        {
            SetInputActive(false);

            humanController.MakeMove(i, j);
        });

        button.interactable = true;
    }

    public void SetInputActive(bool enable)
    {
        if (enable)
        {
            UpdateAvailableButtons();
        }

        m_CanvasGroup.interactable = enable;
    }

    public void UpdateAvailableButtons()
    {
        for (int i = 0, k = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++, k++)
            {
                if(board.board[i, j] != "")
                {
                    buttons[k].interactable = false;
                }
            }
        }
    }
}
