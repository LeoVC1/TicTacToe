using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBoardGraphics : MonoBehaviour
{
    [SerializeField]
    private Sprite spriteMarkX;
    [SerializeField]
    private Sprite spriteMarkO;
    [SerializeField]
    private Image[] cellImages;


    private void Awake()
    {
        cellImages = GetComponentsInChildren<Image>();

        ClearBoardGraphics();
    }

    public void UpdateBoardGraphics(Board board)
    {
        ClearBoardGraphics();

        for (int i = 0, k = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++, k++)
            {
                cellImages[k].sprite = (board.board[i, j] == "X") ? spriteMarkX : (board.board[i, j] == "O") ? spriteMarkO : null;

                cellImages[k].enabled = cellImages[k].sprite != null;
            }
        }
    }

    public void ClearBoardGraphics()
    {
        foreach (Image img in cellImages)
        {
            img.enabled = false;
        }
    }
}
