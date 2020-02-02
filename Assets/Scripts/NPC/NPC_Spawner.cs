using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Spawner : NPC_Base
{
    //NPC_Spawner[] characters;


    private void Awake()
    {
        NPC_name = names[Random.Range(0, names.Length)];
        like = likes[Random.Range(0, likes.Length)];
        dislikes = likes[Random.Range(0, likes.Length)];
        incomeMin = Random.Range(10, 17);
        incomeMax = Random.Range(15, 22);
        happiness = Random.Range(0.3f,0.7f);
        cleanliness = Random.Range(0, 10);
        handyness = Random.Range(0, 10);      
    }
    // Start is called before the first frame update
    void Start()
    {
        if (like == dislikes) dislikes = likes[Random.Range(0, likes.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
