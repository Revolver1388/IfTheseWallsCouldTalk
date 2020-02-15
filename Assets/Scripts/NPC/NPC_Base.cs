using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC_Base : MonoBehaviour
{
    protected string[] names = { "Matt", "Cam", "Kyle", "Marion", "Bernadette", "Chelsea", "Leif", "Bob", "Becky", "Peter", "Paul", "Heyzues", "Venom"};
    protected string[] likes = { "Cooking", "TV", "Fixing Things", "Quiet", "Drinking", "Gardening", "Working Out", "Cosmetics", "Cleanning"};
    [SerializeField] public RawImage portrait;
    public string NPC_name;
    public float happiness;
    public int incomeMin;
    public int incomeMax;
    public string like;
    public string dislikes;
    public int cleanliness;
    public int handyness;
    //must link the NPC attripbutes to the items in the game, e.g. if an NPC is happy cooking, their happyness is tied to the state of the kitchen
}
