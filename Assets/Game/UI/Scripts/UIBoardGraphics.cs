using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBoardGraphics : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] cellTexts;

    private void Awake()
    {
        cellTexts = GetComponentsInChildren<TextMeshProUGUI>();

        ClearBoardGraphics();
    }

    public void UpdateBoardGraphics(Board board)
    {
        ClearBoardGraphics();


        for (int i = 0, k = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++, k++)
            {
                cellTexts[k].text += board.board[i, j];
            }
        }
    }

    public void ClearBoardGraphics()
    {
        foreach (TextMeshProUGUI text in cellTexts)
        {
            text.text = "";
        }
    }
}
