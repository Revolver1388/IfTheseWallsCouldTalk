using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    NPC_Behaviors[] tennants;
    Room_Class[] rooms;
    View_UI UI;

    protected float dayTimer = 0.0f;
    private float dayLength = 120;
    int days = 1;
    float totalCash = 0;
    float bank;
    float endOfDayCash;
    bool tabulate = false;
    bool dayStart = true;
    public bool dayOver = false;
    // Start is called before the first frame update
    void Start()
    {
        tennants = FindObjectsOfType<NPC_Behaviors>();
        rooms = FindObjectsOfType<Room_Class>();
        UI = FindObjectOfType<View_UI>();
    }

    // Update is called once per frame
    void Update()
    {
        UI.dayText.text = $"{"Day: " + days}";
        if (dayStart)
        {
            if (dayTimer < dayLength) { dayTimer += 1 * Time.deltaTime; }
            else if (dayTimer >= dayLength) { dayOver = true; dayStart = false; }
        }

        if (dayOver == true)
        {
            //if (tabulate) AddIncome();
            //tabulate = false;
            //if (totalCash < endOfDayCash)
            //{               
            //    UI.bankAccountText.text = $"{ Mathf.Floor(totalCash += 1 * Time.deltaTime)}";
            //}
            /*           else if(totalCash >= endOfDayCash)*/
            StartCoroutine(EndOfDayFade());
        }
    }

    //void TimeOfDay()
    //{
    //    UI.timeText.text = $"{Mathf.Floor((dayTimer * (1440/2)))}:{Mathf.Floor((dayTimer *((1448/2))%60))}";
    //}

    IEnumerator EndOfDayFade()
    {
        dayTimer = 0;
        dayOver = false;
        yield return new WaitForSeconds(2);
        bank = bank + AddIncome();
        UI.bankAccountText.text = $"{bank}";
        totalCash = 0;
        endOfDayCash = 0;
        days += 1;
        dayStart = true;
    }

    float AddIncome()
    {
        foreach (var npc in tennants)
        {
            endOfDayCash += npc.meanIncome;
        }
       
        return endOfDayCash;
        
    }
}
