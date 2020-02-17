using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HouseManager : MonoBehaviour
{
    [SerializeField] NPC_Behaviors[] tennants;
    public Room_Class[] rooms;
    View_UI UI;
    public Texture[] portraits;
    [SerializeField] int score;
    [SerializeField] Room_Class[] bedrooms;
    public float dayTimer = 0.0f;
    public float dayLength = 100;
    int days = 1;
    float totalCash = 0;
    public float bank;
    float endOfDayCash;
    bool tabulate = false;
    bool dayStart = true;
    bool bedOne = false;
    bool bedTwo = false;
    bool bedThree = false;
    public bool dayOver = false;


    // Start is called before the first frame update
    void Start()
    {
      //  tennants = FindObjectsOfType<NPC_Behaviors>();
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
        OpenTennantRental();
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

    void OpenTennantRental()
    {
        if (bedrooms[1].roomState != Room_Class.RoomState.Broken && !bedTwo) { UI.OpenNpcManagerPanel(); bedTwo = true; }
        else if (bedrooms[2].roomState != Room_Class.RoomState.Broken && !bedThree) { UI.OpenNpcManagerPanel(); bedThree = true; }
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
        TallyRooms();
        totalCash = 0;
        endOfDayCash = 0;
        days += 1;
        dayStart = true;
    }

    int TallyRooms()
    {
        foreach (var room in rooms)
        {
            switch (room.applianceCount)
            {
                case 0:
                    score += 0;
                    break;
                case 1:
                    score += 1;
                    break;
                case 2:
                    score += 2;
                    break;
                case 3:
                    score += 3;
                    break;
                default:
                    break;
            }
            if (room.roomState == Room_Class.RoomState.Broken) score += 0;
            else if (room.roomState == Room_Class.RoomState.Fixed_Dirty) score += 1;
            else if (room.roomState == Room_Class.RoomState.Fixed_Clean) score += 2;
        }
        print(score);
        return score;
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
