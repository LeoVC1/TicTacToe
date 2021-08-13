using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : PlayerController
{
    [Header("Model References:")]
    [SerializeField]
    private Board _board;

    [Header("Controllers References:")]
    [SerializeField]
    private GameController _gameController;

    [Header("UI References:")]
    [SerializeField]
    private UIBoardInput _boardInput;

    public void MakeMove(int i, int j)
    {
        _board.board[i, j] = playerMark;

        _gameController.CurrentPlayer = Player.AI;
    }

    public override void SetPlayerMark(string mark)
    {
        base.SetPlayerMark(mark);

        _boardInput.SetupPlayerInputs();
    }
 
    public override void OnChangeCurrentPlayer(Player currentPlayer)
    {
        if(currentPlayer == Player.HUMAN)
        {
            _boardInput.SetInputActive(true);
        }
    }
}
