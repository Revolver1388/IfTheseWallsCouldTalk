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
    int timesPicked = 0;
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
                NPC_name = tennants[i].NPC_name;
                incomeMax = tennants[i].incomeMax;
                incomeMin = tennants[i].incomeMin;
                happiness = tennants[i].happiness;
                handyness = tennants[i].handyness;
                cleanliness = tennants[i].cleanliness;
                like = tennants[i].like;
                dislikes = tennants[i].dislikes;
                gender = tennants[i].gender;
                portrait = tennants[i].portrait;
                npc[timesPicked].gameObject.SetActive(true);
                ui.toggleTenantManagerPanel();
                timesPicked += 1;
                break;
            case 1:
                NPC_name = tennants[i].NPC_name;
                incomeMax = tennants[i].incomeMax;
                incomeMin = tennants[i].incomeMin;
                happiness = tennants[i].happiness;
                handyness = tennants[i].handyness;
                cleanliness = tennants[i].cleanliness;
                like = tennants[i].like;
                dislikes = tennants[i].dislikes;
                gender = tennants[i].gender;
                portrait = tennants[i].portrait;
                npc[timesPicked].gameObject.SetActive(true);
                ui.toggleTenantManagerPanel();
                timesPicked += 1;
                break;
            case 2:
                NPC_name = tennants[i].NPC_name;
                incomeMax = tennants[i].incomeMax;
                incomeMin = tennants[i].incomeMin;
                happiness = tennants[i].happiness;
                handyness = tennants[i].handyness;
                cleanliness = tennants[i].cleanliness;
                like = tennants[i].like;
                dislikes = tennants[i].dislikes;
                gender = tennants[i].gender;
                portrait = tennants[i].portrait;
                npc[timesPicked].gameObject.SetActive(true);
                ui.toggleTenantManagerPanel();
                timesPicked += 1;
                break;
            case 3:
                NPC_name = tennants[i].NPC_name;
                incomeMax = tennants[i].incomeMax;
                incomeMin = tennants[i].incomeMin;
                happiness = tennants[i].happiness;
                handyness = tennants[i].handyness;
                cleanliness = tennants[i].cleanliness;
                like = tennants[i].like;
                dislikes = tennants[i].dislikes;
                gender = tennants[i].gender;
                portrait = tennants[i].portrait;
                npc[timesPicked].gameObject.SetActive(true);
                ui.toggleTenantManagerPanel();
                timesPicked += 1;
                break;

            default:
                break;
        }
        tennants[i].CreateNewTennant();
    }
}
