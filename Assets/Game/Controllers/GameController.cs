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
    private PlayerController humanController;
    [SerializeField]
    private PlayerController aiController;

    [Header("UI References:")]
    [SerializeField]
    private UIBoardGraphics boardGraphics;

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
            boardGraphics.UpdateBoardGraphics(_board);

            _currentPlayer = value;

            string winner = _board.CheckWinner();

            if (winner != "" && winner != null)
            {
                Debug.Log("Vencedor: " + winner);
            }
            else
            {
                //Notify all players about the change of current player
                humanController.OnChangeCurrentPlayer(value);
                aiController.OnChangeCurrentPlayer(value);
            }
        }
    }

    private void Awake()
    {
        humanController.SetPlayerMark("X");
        aiController.SetPlayerMark("O");
    }

    private void Start()
    {
        CurrentPlayer = Player.HUMAN;
    }

}
