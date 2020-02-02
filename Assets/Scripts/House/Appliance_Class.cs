using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appliance_Class : MonoBehaviour
{
    public enum State { Broken, Fixed };
    public enum Type { Cooking, TV, FixingThings, Quiet, Drinking, Gardening, WorkingOut, Cosmetics, Cleanning};

    [System.Serializable]
    public struct Appliance { public string name; public State state; [SerializeField] Sprite[] sprites; [SerializeField] float depreciation;  public Type type; };
}
//  "Cooking" "TV" "Fixing Things" "Quiet" "Drinking" "Gardening" "Working Out" "Cosmetics" "Cleanning"}
