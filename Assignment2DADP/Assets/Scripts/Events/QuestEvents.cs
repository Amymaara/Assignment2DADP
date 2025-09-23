using System;

// customer spawning help from this video
// Title: Unity- RPG Hero Diner - Customer Spawning
// Author: Design and Deploy
// Date Accessed: 23 September 2025
// Accesibility: https://www.youtube.com/watch?v=vI7VLNuyhpU&t=661s
public class QuestEvents 
{
    public event Action<string> onStartQuest;

    public void StartQuest(string id)
    {
        if (onStartQuest != null)
        {
            onStartQuest(id);
        }
    }

    public event Action<string> onAdvanceQuest;
    public void AdvanceQuest(string id)
    {
        if (onAdvanceQuest != null)
        {
            onAdvanceQuest(id);
        }
    }

    public event Action<string> onFinishQuest;
    public void FinishQuest(string id)
    {
        if (onFinishQuest != null)
        {
            onFinishQuest(id);
        }
    }

   public event Action<Quest> onQuestStateChange;
   public void QuestStateChange(Quest quest)
    {
        if (onQuestStateChange != null)
        {
            onQuestStateChange(quest);
        }
    }
  
}
