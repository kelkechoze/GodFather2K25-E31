using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState CurrentState;

    public static event Action<GameState> OnGameStateChanged;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void UpdateGameState(GameState newState)
    {
        CurrentState = newState;

        switch (CurrentState)
        {
            case GameState.MainMenu:
                break;
            case GameState.MainState:
                break;
            case GameState.Labyrinth:
                break;
            case GameState.Win:
                break;
            case GameState.Loose:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        OnGameStateChanged?.Invoke(newState);
    }
}

public enum GameState
{
    MainMenu,
    MainState,
    Labyrinth,
    Win,
    Loose   
}
