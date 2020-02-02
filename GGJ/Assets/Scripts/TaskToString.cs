using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskToString : MonoBehaviour
{
    private QuestManager questManager;
    [SerializeField]
    private TextMeshProUGUI tekstMesh;

    private void Start()
    {
        questManager = GetComponent<QuestManager>();
        for(int k=0;k<questManager.wires.Count;k++)
        {
            for(int i=0;i<questManager.wires.Count;i++)
            {
                if (questManager.wires[k].DestinationPoint != questManager.wires[i].StartPosition)
                {
                    continue;
                }
                else
                {
                    Debug.Log("text func");
                    tekstMesh.text += $"From {questManager.wires[k].SharedMaterial.color.ToString("F5")} point move to {questManager.wires[i].SharedMaterial.color.ToString("F5")} point\n";
                }
            }
        }
    }
}
