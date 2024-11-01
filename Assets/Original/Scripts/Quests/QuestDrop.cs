using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(QuestComplete))]
public class QuestDrop : MonoBehaviour, IDrop
{
    //[SerializeField]private string QuestNameThing;

    [SerializeField] private List<string> QuestNameThingAll = new List<string>();

    [SerializeField] private GameObject prefabQuestThing;
    [SerializeField] private Transform spawnPosition;

    [SerializeField] private GameObject destroyObject;

    public void drop(Inventory inventory)
    {
        /*
        if (inventory.CheckList(QuestNameThing) == true )
        {
            // Уничтожаем из списка квестовый предмет.
            inventory.RemoveList(QuestNameThing);
            // Создаем квестовый предмет из префаба.
            Instantiate(prefabQuestThing, spawnPosition);

            if(destroyObject != null)
            {
                Destroy(destroyObject);
            }

            // Получаем обьект который запускает анимацию.
            QuestComplete questComplete = GetComponent<QuestComplete>();
            questComplete.FinishQuest();

            gameObject.GetComponent<InteractionObject>().ChangeState(false);
        }
        else
        {
            if (GetComponent<SubtitlesContainer>() != null)
            {
                GetComponent<SubtitlesContainer>().PlaySubtitlesContainer();
            }
        }
        */

        foreach(var QuestNameThing in QuestNameThingAll)
        {
            if (inventory.CheckList(QuestNameThing) == true)
            {
                // Уничтожаем из списка квестовый предмет.
                inventory.RemoveList(QuestNameThing);
                // Создаем квестовый предмет из префаба.
                Instantiate(prefabQuestThing, spawnPosition);

                if (destroyObject != null)
                {
                    Destroy(destroyObject);
                }

                // Получаем обьект который запускает анимацию.
                QuestComplete questComplete = GetComponent<QuestComplete>();
                questComplete.FinishQuest();

                gameObject.GetComponent<InteractionObject>().ChangeState(false);
            }
            else
            {
                if (GetComponent<SubtitlesContainer>() != null)
                {
                    GetComponent<SubtitlesContainer>().PlaySubtitlesContainer();
                }
            }
        }
            
    }
}
