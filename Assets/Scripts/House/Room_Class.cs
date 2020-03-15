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
    bool startClock = false;
    [SerializeField] float cleannningClock;
    float maxCleanningTime = 120;
    View_UI ui;
    private void Awake()
    {
        ui = FindObjectOfType<View_UI>();
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
        if (gameObject.tag != "TwoArrayAsset")
        {
            if (roomState == RoomState.Broken) { StartCoroutine(swap(0)); }
            else if (roomState == RoomState.Fixed_Dirty) { StartCoroutine(swap(1)); cleannningClock = 0; startClock = false; }
            else if (roomState == RoomState.Fixed_Clean)
            {
                StartCoroutine(swap(2));
                startClock = true;
                if (startClock) CleanClock();
                if (roomType == RoomType.Kitchen) forgroundItem.SetActive(true);
            }
        }
        else if (gameObject.tag == "TwoArrayAsset")
        {
            if (roomState == RoomState.Broken) StartCoroutine(swap(0));
            else if (roomState == RoomState.Fixed_Clean) StartCoroutine(swap(1));
        }
    }

    IEnumerator swap(int i)
    {
        yield return new WaitForEndOfFrame();
        sprite.sprite = images[i];        
    }

    public void CleanClock()
    {
        if (cleannningClock <= maxCleanningTime)
        {
            cleannningClock += 1 * Time.deltaTime;
        }
        else if (cleannningClock > maxCleanningTime) roomState = RoomState.Fixed_Dirty; /*ui.npcUpdater.text = $"{ roomType + " is dirty."}" ;*/
    }
}
