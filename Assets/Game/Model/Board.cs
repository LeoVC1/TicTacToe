using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Board Asset", menuName = "Tic Tac Toe")]
public class Board : ScriptableObject
{
    public string[,] board = new string[3, 3]
    {
        { "", "", "" },
        { "", "", "" },
        { "", "", "" }
    };

    /// <summary>
    /// Return X, O, Draw or null
    /// </summary>
    /// <returns></returns>
    public string CheckWinner()
    {
        string winner = null;

        #region Horizontals
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == "")
                continue;

            if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
            {
                return board[i, 0];
            }
        }
        #endregion

        #region Verticals
        for (int i = 0; i < 3; i++)
        {
            if (board[0, i] == "")
                continue;

            if (board[0, i] == board[1, i] && board[0, i] == board[2, i])
            {
                return board[0, i];
            }
        }
        #endregion

        #region Diagonals
        if (board[0, 0] != "" && (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]))
        {
            return board[0, 0];
        }
        else if (board[2, 0] != "" && (board[2, 0] == board[1, 1] && board[2, 0] == board[0, 2]))
        {
            return board[2, 0];
        }
        #endregion

        if (winner == null && CheckEmptySpaces() == 0)
        {
            return "draw";
        }
        else
        {
            return winner;
        }
    }

    private int CheckEmptySpaces()
    {
        int emptySpaces = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == "")
                {
                    emptySpaces++;
                }
            }
        }

        return emptySpaces;
    }

    public void Restart()
    {
        board = new string[3, 3]
        {
            { "", "", "" },
            { "", "", "" },
            { "", "", "" }
        };
    }
}
