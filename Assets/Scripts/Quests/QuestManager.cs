using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private QuestPanel _questPanel;
    [SerializeField] private List<Quest> _allQuests;

    private List<Quest> _activeQuests = new List<Quest>();

    public static QuestManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddQuest(Quest quest)
    {
        _activeQuests.Add(quest);
        _questPanel.SelectQuest(quest);
        _questPanel.Show();
    }

    public void AddQuestByName(string questName)
    {
        var quest = _allQuests.FirstOrDefault(t => t.name == questName);
        if (quest != null)
            AddQuest(quest);
        else
            print($"Missing quest {questName}");
    }

    public void ProgressQuests()
    {
        foreach (var quest in _activeQuests)
        {
            quest.TryProgress();
        }
    }
}
