using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Class : MonoBehaviour
{
    public enum RoomState { Broken, Fixed_Dirty, Fixed_Clean, Idle }
    [SerializeField]
    public RoomState roomState;
    public enum RoomType { Kitchen, Bathroom, LivingRoom, Bedroom1, Bedroom2, Bedroom3, Outdoor, Basement, Attic, RecRoom, WineCellar, Stairwell, Study }
    [SerializeField]
    public RoomType roomType;
    [SerializeField]Sprite[] images;
    SpriteRenderer sprite;
    public int applianceCount;
    [SerializeField] Appliance_Class[] appliances;
    [SerializeField] GameObject forgroundItem;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        appliances = GetComponentsInChildren<Appliance_Class>();
    }
    private void Start()
    {
        if (forgroundItem) forgroundItem.SetActive(false);
        else
            return;
    }
    private void Update()
    {

        if (roomState == RoomState.Broken) { StartCoroutine(swap(0)); }
        else if (roomState == RoomState.Fixed_Clean)
        {
            StartCoroutine(swap(1));
            if (roomType == RoomType.Kitchen) forgroundItem.SetActive(true);
        }        
    }
    IEnumerator swap(int i)
    {
        yield return new WaitForEndOfFrame();
        sprite.sprite = images[i];        
    }
}
