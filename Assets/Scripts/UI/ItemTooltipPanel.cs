using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemTooltipPanel : MonoBehaviour, IPointerClickHandler
{
    public static ItemTooltipPanel Instance { get; private set; }

    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Image _icon;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        Instance = this;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ShowItem(Item item)
    {
        if (item == null)
        {
            ToggleVisibility(false);
        }
        else
        {
            ToggleVisibility(true);
            _name.SetText(item.name);
            _description.SetText(item.Description);
            _icon.sprite = item.Icon;
        }
    }

    public void ToggleVisibility(bool visibility)
    {
        _canvasGroup.alpha = visibility ? 1f : 0f;
        _canvasGroup.interactable = visibility;
        _canvasGroup.blocksRaycasts = visibility;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ToggleVisibility(false);
    }
}
