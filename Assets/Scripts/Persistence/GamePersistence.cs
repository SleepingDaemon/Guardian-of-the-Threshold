using System.Collections;
using UnityEngine;

public class GamePersistence : MonoBehaviour
{
    public GameData _gameData;

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
        PlayerPrefs.SetString("GameData", json);
        Debug.Log(json);
        Debug.Log("Saving game data completed");
    }

    private void LoadGameFlags()
    {
        var json = PlayerPrefs.GetString("GameData");
        _gameData = JsonUtility.FromJson<GameData>(json);
        if (_gameData == null)
            _gameData = new GameData();

        FlagManager.Instance.Bind(_gameData.GameFlagDatas);
        InspectionManager.Bind(_gameData.InspectableDatas);
        Inventory.Instance.Bind(_gameData.SlotDatas);
    }
}
