using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTriggerArea : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCameraBase _blend;
    private GameEvent _gameEvent;

    public void SetPriority(int value)
    {
        _blend.Priority = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvent.RaiseEvent("TriggerCam");
        }
    }
}
