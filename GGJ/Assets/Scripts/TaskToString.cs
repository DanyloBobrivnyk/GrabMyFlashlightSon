using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskToString : MonoBehaviour
{
    private QuestManager questManager;
    [SerializeField]
    private TextMeshProUGUI tekstMesh;

    private int r, g, b;
    private string colorName;
    private string ConvertToWord(Color RGBA)
    {
        string colorName = ColorUtility.ToHtmlStringRGBA(RGBA);
        if (colorName == Color.white.ToString())
        {
            return "white";
        }
        else if(colorName == "000100")
        {
            return "green";
        }
        else if(colorName == "000000")
        {
            return "black";
        }
        else if (colorName == "000001")
        {
            return "blue";
        }
        else if (colorName == "010000")
        {
            return "red";
        }
        else if (colorName == "000101")
        {
            return "cyan";
        }
        return "don't know";
    }

    private void Start()
    {
        questManager = GetComponent<QuestManager>();
        for(int k=0;k<questManager.wires.Count;k++)
        {
            for(int i=0;i<questManager.wires.Count;i++)
            {
                if (questManager.wires[k].DestinationPoint == questManager.wires[i].StartPosition)
                {
                    tekstMesh.text += ($"{questManager.wires[k].SharedMaterial.name} move to {questManager.wires[i].SharedMaterial.name}\n");
                    break;

                }
                else
                {
                    continue;
                }
            }
        }
    }
}
