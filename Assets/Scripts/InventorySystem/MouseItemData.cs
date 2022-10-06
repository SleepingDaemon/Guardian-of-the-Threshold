using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseItemData : MonoBehaviour
{
    public Image ItemSprite;
    public TMP_Text ItemCount;

    private void Awake()
    {
        ItemSprite.color = Color.clear;
        ItemCount.SetText("");
    }
}
