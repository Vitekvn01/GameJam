using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(QuestComplete))]
public class QuestDrop : MonoBehaviour, IDrop
{
    [SerializeField]private string QuestNameThing;
    [SerializeField] private GameObject prefabQuestThing;
    [SerializeField] private Transform spawnPosition;
    
    public void drop(Inventory inventory)
    {
        if(inventory.CheckList(QuestNameThing) == true )
        {
            // ���������� �� ������ ��������� �������.
            inventory.RemoveList(QuestNameThing);
            // ������� ��������� ������� �� �������.
            Instantiate(prefabQuestThing, spawnPosition);

            // �������� ������ ������� ��������� ��������.
            QuestComplete questComplete = GetComponent<QuestComplete>();
            questComplete.FinishQuest();
        }
            
    }
}
