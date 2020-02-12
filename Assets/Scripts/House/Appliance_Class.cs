using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appliance_Class : MonoBehaviour
{
    public enum State { Broken, Fixed };
    public enum Type { Cooking, TV, FixingThings, Quiet, Drinking, Gardening, WorkingOut, Cosmetics, Cleanning};
    [SerializeField] string applianceName;
    public State state;
    [SerializeField]
    Sprite sprites;
    [SerializeField] float depreciation;
    public Type type;
    SpriteRenderer appearance;
    [SerializeField] NPC_Behaviors[] tennants;

    private void Start()
    {
        appearance = GetComponent<SpriteRenderer>();
        appearance.sprite = sprites;
    }

    private void OnEnable()
    {
        IncreaseHappyiness();
        if (!this.gameObject.name.Contains("Placeholder")) GetComponentInParent<Room_Class>().applianceCount++;
    }

    private void OnDisable()
    {
        if (!this.gameObject.name.Contains("Placeholder")) GetComponentInParent<Room_Class>().applianceCount--;
    }
    void IncreaseHappyiness()
    {
        foreach (var nPC in tennants)
        {
            if (nPC.myStats.like == type.ToString()) nPC.ManageHappiness(0.2f);
            if (nPC.myStats.dislikes == type.ToString()) nPC.ManageHappiness(-0.2f);
        }
    }
    //[System.Serializable]
    //public struct Appliance { public string name; public State state; [SerializeField] Sprite[] sprites; [SerializeField] float depreciation;  public Type type};
}
//  "Cooking" "TV" "Fixing Things" "Quiet" "Drinking" "Gardening" "Working Out" "Cosmetics" "Cleanning"}
