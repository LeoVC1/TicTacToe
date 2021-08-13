using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : PlayerController
{
    [Header("Model References:")]
    [SerializeField]
    private Board _board;

    [Header("Controllers References:")]
    [SerializeField]
    private GameController _gameController;

    [HideInInspector]
    public string HumanMark = "O";

    [Header("Settings:")]
    public Difficulty _difficulty = Difficulty.IMPOSSIBLE;

    public enum Difficulty
    {
        EASY = 0,
        MEDIUM = 5,
        HARD = 8,
        IMPOSSIBLE = 20
    }

    /// <summary>
    /// Find and make the best move for AI (uses Minimax recursive function)
    /// </summary>
    public void FindBestMove()
    {
        int bestScore = int.MinValue;

        (int, int) move = (-1, -1);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_board.board[i, j] == "")
                {
                    _board.board[i, j] = playerMark;

                    int score = Minimax(0, false);

                    _board.board[i, j] = "";

                    if (score > bestScore)
                    {
                        bestScore = score;

                        move = (i, j);
                    }
                }
            }
        }

        _board.board[move.Item1, move.Item2] = playerMark;

        _gameController.CurrentPlayer = Player.HUMAN;
    }

    private int Minimax(int depth, bool isMaximizing)
    {
        string result = _board.CheckWinner();

        if (result != "" && result != null)
        {
            return EvaluateBoardWinner(result); //Return the board evaluation if we have a winner
        }
        
        if (isMaximizing) //Returns the max score of the current depth (AI turn)
        {
            int bestScore = int.MinValue;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_board.board[i, j] == "")
                    {
                        _board.board[i, j] = playerMark;

                        int score = Minimax(depth + 1, false);

                        _board.board[i, j] = "";

                        bestScore = Mathf.Max(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
        else //Returns the min score of the current depth (Player turn)
        {
            int bestScore = int.MaxValue;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_board.board[i, j] == "")
                    {
                        _board.board[i, j] = HumanMark;

                        int score = Minimax(depth + 1, true);

                        _board.board[i, j] = "";

                        bestScore = Mathf.Min(score, bestScore);
                    }
                }
            }

            return bestScore;
        }
    }

    /// <summary>
    /// Evalute the board configuration winner and apply some randomness with difficult
    /// </summary>
    /// <param name="mark"></param>
    /// <returns></returns>
    private int EvaluateBoardWinner(string mark)
    {
        if(mark == playerMark)
        {
            return 10 - Random.Range(0, 20 - (int)_difficulty);
        }
        else if(mark == HumanMark)
        {
            return -10 + Random.Range(0, 20 - (int)_difficulty);
        }
        else
        {
            return 0;
        }
    }

    public override void SetPlayerMark(string mark)
    {
        base.SetPlayerMark(mark);

        HumanMark = mark == "X" ? "O" : "X"; 
    }

    public override void OnChangeCurrentPlayer(Player currentPlayer)
    {
        if(currentPlayer == Player.AI)
        {
            FindBestMove();
        }
    }
}

