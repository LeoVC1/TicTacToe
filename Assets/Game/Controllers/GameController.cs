using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour
{
    [Header("Model References:")]
    [SerializeField]
    private Board _board;

    [Header("Controllers References:")]
    [SerializeField]
    private HumanController _humanController;
    [SerializeField]
    private AIController _aiController;

    [Header("UI References:")]
    [SerializeField]
    private UIBoardGraphics _boardGraphics;
    [SerializeField]
    private UIGameOverModal _gameOverModal;

    private Player _currentPlayer;

    /// <summary>
    /// Controls the game turn and game over
    /// </summary>
    public Player CurrentPlayer
    {
        get
        {
            return _currentPlayer;
        }
        set
        {
            _boardGraphics.UpdateBoardGraphics(_board);

            _currentPlayer = value;

            string winner = _board.CheckWinner();

            if (winner != "" && winner != null)
            {
                _gameOverModal.OpenModal(winner);
            }
            else
            {
                //Notify all players about the change of current player
                _humanController.OnChangeCurrentPlayer(value);
                _aiController.OnChangeCurrentPlayer(value);
            }
        }
    }

    public void StartGame(string humanMark, AIController.Difficulty difficulty)
    {
        _board.Restart();
        _boardGraphics.ClearBoardGraphics();

        _aiController._difficulty = difficulty;

        _humanController.SetPlayerMark(humanMark);
        _aiController.SetPlayerMark(humanMark == "X" ? "O" : "X");

        CurrentPlayer = humanMark == "X" ? Player.HUMAN : Player.AI;
    }
}
