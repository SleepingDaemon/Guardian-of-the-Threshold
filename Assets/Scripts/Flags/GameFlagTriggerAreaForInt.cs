﻿using UnityEngine;

public class GameFlagTriggerAreaForInt : MonoBehaviour
{
    [SerializeField] private IntGameFlag _gameFlag;
    [SerializeField] private int _amount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            _gameFlag.Modify(_amount);
    }
}
