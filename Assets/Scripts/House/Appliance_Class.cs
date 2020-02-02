using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appliance_Class : MonoBehaviour
{
    public enum State { Broken, Fixed };
    [System.Serializable]
    public struct Appliance { public string name; public State state; [SerializeField] Sprite[] sprites; };
}
