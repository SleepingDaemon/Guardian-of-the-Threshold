using System.Collections;
using UnityEngine;

public class GamePersistence : MonoBehaviour
{
    private GameData _gameData;

    private void Start()
    {
        LoadGameFlags();
    }

    private void OnDisable()
    {
        SaveGameFlags();
    }

    private void SaveGameFlags()
    {
        
        var json = JsonUtility.ToJson(_gameData);
        Debug.Log(json);
        Debug.Log("Saving game data completed");
    }

    private void LoadGameFlags()
    {
        _gameData = new GameData();
    }
}
