using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC_Spawner : NPC_Base
{
    //NPC_Spawner[] characters;

    [SerializeField] Text[] rentalCardInfo;
    
    HouseManager house;
    private void Awake()
    {
        CreateNewTennant();
        //house = FindObjectOfType<HouseManager>();
        //NPC_name = names[Random.Range(0, names.Length)];
        //like = likes[Random.Range(0, likes.Length)];
        //dislikes = likes[Random.Range(0, likes.Length)];
        //incomeMin = Random.Range(10, 17);
        //incomeMax = Random.Range(15, 22);
        //happiness = Random.Range(0.3f,0.7f);
        //cleanliness = Random.Range(0, 10);
        //handyness = Random.Range(0, 10);
        //portrait = GetComponentInChildren<RawImage>();

    }
    // Start is called before the first frame update
    void Start()
    {
        if (like == dislikes) dislikes = likes[Random.Range(0, likes.Length)];
        rentalCardInfo[0].text = $"{NPC_name}";
        rentalCardInfo[1].text = $"{incomeMin + " - " + incomeMax }";
        rentalCardInfo[2].text = $"{cleanliness}";
        rentalCardInfo[3].text = $"{handyness}";
        if (!gender)
            portrait.texture = house.portraits[Random.Range(0, house.portraits.Length)];
        else if (gender)
            portrait.texture = house.fPortrait[Random.Range(0, house.fPortrait.Length)];
    }

    public void CreateNewTennant()
    {
        house = FindObjectOfType<HouseManager>();
        NPC_name = names[Random.Range(0, names.Length)];
        like = likes[Random.Range(0, likes.Length)];
        dislikes = likes[Random.Range(0, likes.Length)];
        incomeMin = Random.Range(10, 17);
        incomeMax = Random.Range(15, 22);
        happiness = Random.Range(0.3f, 0.7f);
        cleanliness = Random.Range(0, 10);
        handyness = Random.Range(0, 10);
        portrait = GetComponentInChildren<RawImage>();
        if (NPC_name == "Marion" || NPC_name == "Bernadette" || NPC_name == "Chelsea" || NPC_name == "Becky") gender = true;

        if (like == dislikes) dislikes = likes[Random.Range(0, likes.Length)];
        rentalCardInfo[0].text = $"{NPC_name}";
        rentalCardInfo[1].text = $"{incomeMin + " - " + incomeMax }";
        rentalCardInfo[2].text = $"{cleanliness}";
        rentalCardInfo[3].text = $"{handyness}";

        if (!gender)
            portrait.texture = house.portraits[Random.Range(0, house.portraits.Length)];
        else if (gender)
            portrait.texture = house.fPortrait[Random.Range(0, house.fPortrait.Length)];
    }
}
