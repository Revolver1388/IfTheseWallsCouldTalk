using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TennantSelector : NPC_Base
{
    [SerializeField] Button[] choice;
    [SerializeField] NPC_Spawner[] tennants;
    [SerializeField] NPC_Behaviors[] npc;
    View_UI ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<View_UI>();
        tennants = GetComponentsInChildren<NPC_Spawner>();
        choice = GetComponentsInChildren<Button>();
        npc = FindObjectsOfType<NPC_Behaviors>();
        foreach (var item in npc)
        {
            item.gameObject.SetActive(false);
        }
    }
    
    public void InstantiateTennant(int i)
    { 
        switch (i)
        {
            case 0:
                npc[0].NPC_name = tennants[i].NPC_name;
                npc[0].incomeMax = tennants[i].incomeMax;
                npc[0].incomeMin = tennants[i].incomeMin;
                npc[0].happiness = tennants[i].happiness;
                npc[0].handyness = tennants[i].handyness;
                npc[0].cleanliness = tennants[i].cleanliness;
                npc[0].portrait = tennants[i].portrait;
                npc[0].like = tennants[i].like;
                npc[0].dislikes = tennants[i].dislikes;
                npc[0].gameObject.SetActive(true);
                ui.CloseNpcManagerPanel();
                break;
            case 1:
                NPC_name = tennants[i].NPC_name;
                incomeMax = tennants[i].incomeMax;
                incomeMin = tennants[i].incomeMin;
                happiness = tennants[i].happiness;
                handyness = tennants[i].handyness;
                cleanliness = tennants[i].cleanliness;
                portrait = tennants[i].portrait;
                like = tennants[i].like;
                dislikes = tennants[i].dislikes;
                npc[0].gameObject.SetActive(true);

                break;
            case 2:
                NPC_name = tennants[i].NPC_name;
                incomeMax = tennants[i].incomeMax;
                incomeMin = tennants[i].incomeMin;
                happiness = tennants[i].happiness;
                handyness = tennants[i].handyness;
                cleanliness = tennants[i].cleanliness;
                portrait = tennants[i].portrait;
                like = tennants[i].like;
                dislikes = tennants[i].dislikes;
                npc[0].gameObject.SetActive(true);

                break;
            case 3:
                NPC_name = tennants[i].NPC_name;
                incomeMax = tennants[i].incomeMax;
                incomeMin = tennants[i].incomeMin;
                happiness = tennants[i].happiness;
                handyness = tennants[i].handyness;
                cleanliness = tennants[i].cleanliness;
                portrait = tennants[i].portrait;
                like = tennants[i].like;
                dislikes = tennants[i].dislikes;
                npc[0].gameObject.SetActive(true);

                break;

            default:
                break;
        }
    }
}
