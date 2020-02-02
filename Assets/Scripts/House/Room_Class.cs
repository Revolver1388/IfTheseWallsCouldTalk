using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Class : MonoBehaviour
{
    public enum RoomState { Broken, Fixed_Dirty, Fixed_Clean }
    [SerializeField]
    public RoomState roomState;
    public enum RoomType { Kitchen, Bathroom, LivingRoom, Bedroom, Outdoor, Basement, Attic, RecRoom, WineCellar }
    [SerializeField]
    public RoomType roomType;

}
