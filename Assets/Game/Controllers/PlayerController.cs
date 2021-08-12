using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected string playerMark;

    public virtual void SetPlayerMark(string mark)
    {
        playerMark = mark;
    }

    public virtual void OnChangeCurrentPlayer(Player currentPlayer)
    {

    }
}

public enum Player
{
    HUMAN,
    AI
}
