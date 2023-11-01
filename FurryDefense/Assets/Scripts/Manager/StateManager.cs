using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameState
{
    NONE,
    INGAME
}


public static class StateManager
{
    public static Action OnEnterInGameState { get; set; }
    public static Action OnExitInGameState { get; set; }

    private static EGameState _gameState;

    public static void ChangeState(EGameState state)
    {
        ExitState();
        _gameState = state;
        EnterState();
    }

    public static void StartState()
    {
        _gameState = EGameState.INGAME;
        EnterState();
    }

    private static void EnterState()
    {
        switch (_gameState)
        {
            case EGameState.INGAME:
                OnEnterInGameState();
                break;
        }
    }

    public static void ExitState()
    {
        switch (_gameState)
        {
            case EGameState.INGAME:
                OnExitInGameState();
                break;
        }
    }
}
