using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player ActivePlayer { get; internal set; }

    [SerializeField] private Inventory _inventory;

    public Inventory Inventory => _inventory;

    private void OnValidate()
    {
        _inventory = GetComponent<Inventory>();
    }
}
