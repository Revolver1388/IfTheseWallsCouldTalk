using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behaviors : MonoBehaviour
{
    NPC_Spawner myStats;
    // Start is called before the first frame update
    void Start()
    {
        myStats = this.gameObject.GetComponent<NPC_Spawner>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void manageHappiness(float y)
    {
        myStats.happiness += y;
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        //cleanliness and cleanning rooms
        if (c.gameObject.GetComponent<Room_Class>().roomState == Room_Class.RoomState.Fixed_Dirty)
        {
            if (myStats.cleanliness >= 6)
            {
                if (myStats.cleanliness >= 6 && myStats.like.Contains("Cleanning")) { manageHappiness(0.1f); print(":D Cleaning the " + c.gameObject.GetComponent<Room_Class>().roomType); }
                else if (myStats.dislikes.Contains("Cleanning")) { manageHappiness(-0.05f); print(":O GROSS!! Im not cleaning that up"); }
                else { manageHappiness(-0.2f); print(":( Cleanning the " + c.gameObject.GetComponent<Room_Class>().roomType); }
            }
            else print(":| This " + c.gameObject.GetComponent<Room_Class>().roomType + " is a mess");
        }

    }
}
