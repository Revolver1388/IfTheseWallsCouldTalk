using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Class : MonoBehaviour
{
    public enum RoomState { Broken, Fixed_Dirty, Fixed_Clean, Idle }
    [SerializeField]
    public RoomState roomState;
    public enum RoomType { Kitchen, Bathroom, LivingRoom, Bedroom, Outdoor, Basement, Attic, RecRoom, WineCellar }
    [SerializeField]
    public RoomType roomType;
    [SerializeField]Sprite[] images;
    SpriteRenderer sprite;
    public int appliances;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();  
    }
    private void Update()
    {

            if (roomState == RoomState.Broken) { StartCoroutine(swap(0)); }
            else if (roomState == RoomState.Fixed_Clean) {StartCoroutine(swap(1)); }
        
    }
    IEnumerator swap(int i)
    {
        yield return new WaitForEndOfFrame();
        sprite.sprite = images[i];        
    }
}
