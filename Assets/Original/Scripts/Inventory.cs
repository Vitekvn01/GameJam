using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    /// <summary>
    /// ������ ����� ���������.
    /// </summary>
    private List<string> things = new List<string>();

    /// <summary>
    /// �������� ���� ���������.
    /// </summary>
    /// <param name="list"></param>
    public void AddList(string list)
    {  
        things.Add(list);
        Debug.Log(things[0]);
        Debug.Log(things.Count);
    }

    /// <summary>
    /// ���������� ���� ���������.
    /// </summary>
    /// <param name="list"></param>
    private void RemoveList(string list)
    {
        for (int i = 0; i < things.Count; i++)
        {
            if(things[i] == list)
            {
                things.RemoveAt(i);
                return;
            }
        }
    }


}
