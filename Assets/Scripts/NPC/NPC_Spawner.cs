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
        house = FindObjectOfType<HouseManager>();
        NPC_name = names[Random.Range(0, names.Length)];
        like = likes[Random.Range(0, likes.Length)];
        dislikes = likes[Random.Range(0, likes.Length)];
        incomeMin = Random.Range(10, 17);
        incomeMax = Random.Range(15, 22);
        happiness = Random.Range(0.3f,0.7f);
        cleanliness = Random.Range(0, 10);
        handyness = Random.Range(0, 10);
        portrait = GetComponentInChildren<RawImage>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (like == dislikes) dislikes = likes[Random.Range(0, likes.Length)];
        rentalCardInfo[0].text = $"{NPC_name}";
        rentalCardInfo[1].text = $"{incomeMin + " - " + incomeMax }";
        rentalCardInfo[2].text = $"{cleanliness}";
        rentalCardInfo[3].text = $"{handyness}";
        portrait.texture = house.portraits[Random.Range(0, house.portraits.Length)];

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

        if (like == dislikes) dislikes = likes[Random.Range(0, likes.Length)];
        rentalCardInfo[0].text = $"{NPC_name}";
        rentalCardInfo[1].text = $"{incomeMin + " - " + incomeMax }";
        rentalCardInfo[2].text = $"{cleanliness}";
        rentalCardInfo[3].text = $"{handyness}";
        portrait.texture = house.portraits[Random.Range(0, house.portraits.Length)];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
