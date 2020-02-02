using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behaviors : NPC_Base
{
    NPC_Base myStats;
    public int meanIncome;
    [SerializeField]
    GameObject temp;
    bool clean = false;
    bool fix = false;
    [SerializeField] ParticleSystem[] ps;
    // Start is called before the first frame update
    void Start()
    {
        myStats = this.gameObject.GetComponent<NPC_Base>();
        ps = GetComponentsInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        meanIncome = (myStats.incomeMax + myStats.incomeMin) / 2;
        if (clean == true)
        {
                if (myStats.cleanliness >= 6 && myStats.cleanliness < 8) StartCoroutine(Cleanning(10, temp.GetComponent<Room_Class>()));
                else if (myStats.cleanliness >= 8 && myStats.cleanliness <= 10) StartCoroutine(Cleanning(7, temp.GetComponent<Room_Class>()));
                else if (myStats.cleanliness >= 6 && myStats.like == "Cleanning") StartCoroutine(Cleanning(10, temp.GetComponent<Room_Class>()));
        }
        else if (fix == true)
        {
            if (myStats.handyness >= 6 && myStats.handyness < 8) StartCoroutine(Fixing(10, temp.GetComponent<Room_Class>()));
            else if (myStats.handyness >= 8 && myStats.handyness <= 10) StartCoroutine(Fixing(7, temp.GetComponent<Room_Class>()));
            else if (myStats.cleanliness >= 6 && myStats.like == "Fixing Things") StartCoroutine(Fixing(10, temp.GetComponent<Room_Class>()));
        }
    }
   

    public void ManageHappiness(float y)
    {
        myStats.happiness += y;
    }

    IEnumerator Cleanning(float t, Room_Class x)
    {
        clean = false;
        print("cleanning");
        yield return new WaitForSeconds(t);
        x.roomState = Room_Class.RoomState.Fixed_Clean;
    }

    IEnumerator Fixing(float t, Room_Class x)
    {
        StartCoroutine(MovingAround(ps[0],t));
        fix = false;
        yield return new WaitForSeconds(t);
        ps[1].Play();
        x.roomState = Room_Class.RoomState.Fixed_Clean;
    }

    IEnumerator MovingAround(ParticleSystem p, float t)
    {
        yield return new WaitForSeconds(0.2f);
        p.Play();
        yield return new WaitForSeconds(t);
        p.Stop();
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (myStats.happiness >= Random.Range(0.7f, 1))
        {
            if (c.gameObject.GetComponent<Room_Class>().roomState == Room_Class.RoomState.Fixed_Dirty)
            {
                if (myStats.cleanliness >= Random.Range(6, 10))
                {
                    temp = c.gameObject;
                    if (myStats.cleanliness >= 6 && myStats.like.Contains("Cleanning")) { ManageHappiness(0.1f); print(":D Cleaning the " + c.gameObject.GetComponent<Room_Class>().roomType); clean = true; temp = c.gameObject; }
                    else if (myStats.dislikes.Contains("Cleanning")) { ManageHappiness(-0.2f); print(":O GROSS!! Im not cleaning that up"); }
                    else { ManageHappiness(-0.1f); print(":( Cleanning the " + c.gameObject.GetComponent<Room_Class>().roomType); clean = true; temp = c.gameObject; }
                }
                else print(":| This " + c.gameObject.GetComponent<Room_Class>().roomType + " is a mess");
            }


            else if (c.gameObject.GetComponent<Room_Class>().roomState == Room_Class.RoomState.Broken)
            {
                if (myStats.handyness >= Random.Range(6,10))
                {
                    if (myStats.handyness >= 6 && myStats.like.Contains("Fixing Things")) { ManageHappiness(0.1f); print(":D Fixing the " + c.gameObject.GetComponent<Room_Class>().roomType); fix = true; temp = c.gameObject; }
                    else if (myStats.dislikes.Contains("Fixing Things")) { ManageHappiness(-0.2f); print(":O GROSS!! Im not fixing that up"); }
                    else { ManageHappiness(-0.1f); print(":( Fixxing the " + c.gameObject.GetComponent<Room_Class>().roomType); fix = true; temp = c.gameObject; }
                }
                else print(":| This " + c.gameObject.GetComponent<Room_Class>().roomType + " is wrecked");
            }
        }
    }
}
