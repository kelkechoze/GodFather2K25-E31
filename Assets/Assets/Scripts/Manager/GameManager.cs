using System;
using UnityEngine;
using Random = UnityEngine.Random;

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
            case GameState.Rope:
                break;
            case GameState.ImageMalus:
                break;
            case GameState.Bonneteau:
                break;
            case GameState.Win:
                break;
            case GameState.Loose:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        OnGameStateChanged?.Invoke(newState);
        Debug.Log(newState.ToString());
    }

    public void RandomizeNextState()
    {
        GameState newState = (GameState)Random.Range(0, (int)GameState.Loose);
        if (newState != CurrentState && newState != GameState.MainMenu && newState != GameState.Loose &&  newState != GameState.Win &&  newState != GameState.MainState)
        {
            UpdateGameState(newState);
        }
    }
}

public enum GameState
{
    MainMenu,
    MainState,
    Labyrinth,
    Rope,
    Bonneteau,
    ImageMalus,
    Win,
    Loose   
}
