﻿using System;
using System.Collections;
using System.Collections.Generic;

public class Game
{
    private Board board;
    private Player[] players;
    private int turn = 0;
    public Game(Board board, Player[] players)
    {
        this.board = board;
        this.players = players;
    }

    public Board Board { get { return board; } }
    public IEnumerable<Player> Players { get { return players; } }
    public int Turn { get { return turn; } }
    public Player CurrentPlayer { get { return players[turn]; } }
    public Player Winner { get { return board.DetectWinner(); } }
    public bool IsOver { get { return Winner != null || board.IsFull; } }
    
    public int IndexOfPlayer(Player player)
    {
        return Array.IndexOf(players, player);
    }

    public void Play(int column)
    {
        if (IsOver) return;
        try
        {
            CurrentPlayer.Play(column, board);
            if (!IsOver) { NextTurn(); }
        }
        catch (InvalidOperationException)
        {
            // Do nothing
        }
    }

    private void NextTurn()
    {
        turn = (turn + 1) % players.Length;
    }
}
