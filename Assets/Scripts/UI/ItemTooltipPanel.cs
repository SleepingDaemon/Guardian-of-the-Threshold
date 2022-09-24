using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltipPanel : MonoBehaviour
{
    public static ItemTooltipPanel Instance { get; private set; }

    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Image _icon;

    private void Awake() => Instance = this;

    public void ShowItem(Item item)
    {
        _name.SetText(item.name);
        _description.SetText(item.Description);
        _icon.sprite = item.Icon;
    }
}
