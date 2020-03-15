using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class View_UI : MonoBehaviour
{

    #region : Imports and Variables etc.......................

    AudioManager audioManager;


    [SerializeField] HouseManager houseManager;
    [SerializeField] public Text bankAccountText;

    //[SerializeField] public Text timeText;
    [SerializeField] public Text dayText;
    [SerializeField] public Image TimeImage;
    [SerializeField] GameObject[] Item;
    [SerializeField] Button[] theButtons;
    string choice;
    // Public bools that indicate whether a given room is available or not
    // Stairwells
    public bool StairwellFirstFloor = true;
    public bool StairwellSecondFloor = false;
    public bool StairwellThirdFloor = false;
    // First Floor
    public bool Kitchen = true;
    public bool Bedroom1 = true;
    public bool Outside = true;
    // Second Floor
    public bool LivingRoom = true;
    public bool Bedroom2 = true;
    public bool Bedroom3 = true;
    //Basement
    public bool Basement;
    public bool WineCellar;
    public bool RecRoom;
    // Third Floor
    public bool Study;
    // Bathroom
    public bool Bathroom = true;
    // Attic
    public bool Attic;
    string itemName;
    string fullPrice;
    string discountPrice;
    Image itemImage;
    //Music Buttons
    [SerializeField] Button musicOnButton;
    [SerializeField] Button musicOffButton;

    //Calendar Panel
    [SerializeField] GameObject calendarPanel;

    // Manager Panels
    [SerializeField] GameObject npcManagerPanel;
    [SerializeField] GameObject roomManagerPanel;
    [SerializeField] public GameObject tennantButton;

    // Room Panels
    [SerializeField] GameObject KitchenRoomPanel;
    [SerializeField] GameObject LivingRoomPanel;
    [SerializeField] GameObject BedRoom1Panel;
    [SerializeField] GameObject BedRoom2Panel;
    [SerializeField] GameObject BedRoom3Panel;
    [SerializeField] GameObject RecRoomPanel;
    [SerializeField] GameObject WineCellarRoomPanel;
    [SerializeField] GameObject BathRoomPanel;
    [SerializeField] GameObject AtticRoomPanel;
    [SerializeField] GameObject BasementRoomPanel;
    [SerializeField] GameObject OutsideRoomPanel;
    [SerializeField] GameObject StudyRoomPanel;

    //Room Buttons
    [SerializeField] GameObject KitchenButton;
    [SerializeField] GameObject LivingRoomButton;
    [SerializeField] GameObject Bedroom1Button;
    [SerializeField] GameObject Bedroom2Button;
    [SerializeField] GameObject Bedroom3Button;
    [SerializeField] GameObject RecRoomButton;
    [SerializeField] GameObject WineCellarButton;
    [SerializeField] GameObject BathroomButton;
    [SerializeField] GameObject AtticButton;
    [SerializeField] GameObject BasementButton;
    [SerializeField] GameObject OutsideButton;
    [SerializeField] GameObject StudyButton;

    // Item Confirm stuff
    [SerializeField] GameObject ItemConfirmModal;
    [SerializeField] Text ItemConfirmModalItemNameText;
    [SerializeField] Text ItemConfirmModalFullPriceText;
    [SerializeField] Text ItemConfirmModalDiscountPriceText;
    [SerializeField] Image ItemConfirmModalImage;
    //[SerializeField] GameObject KitchenItems;
    //[SerializeField] GameObject LivingroomItems;
    //[SerializeField] GameObject BathroomItems;
    //[SerializeField] GameObject Bedroom1Items;
    //[SerializeField] GameObject Bedroom2Items;
    //[SerializeField] GameObject Bedroom3Items;
    //[SerializeField] GameObject BasementItems;
    //[SerializeField] GameObject WinecellarItems;
    //[SerializeField] GameObject RecRoomItems;
    //[SerializeField] GameObject StudyItems;
    //[SerializeField] GameObject OutsideItems;
    //[SerializeField] GameObject AtticItems;








    #endregion


    #region : Start and Update...................

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        tennantButton = GameObject.FindGameObjectWithTag("NPCButton");
        //audioManager.PlayMusic("Normal");
        foreach (var item in Item)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) audioManager.NextSong();

        if (Kitchen) { KitchenButton.SetActive(true); }
        else { KitchenButton.SetActive(false); }

        if (LivingRoom) { LivingRoomButton.SetActive(true); }
        else { LivingRoomButton.SetActive(false); }

        if (Bathroom) { BathroomButton.SetActive(true); }
        else { BathroomButton.SetActive(false); }

        if (Bedroom1) { Bedroom1Button.SetActive(true); }
        else { Bedroom1Button.SetActive(false); }

        if (Bedroom2) { Bedroom2Button.SetActive(true); }
        else { Bedroom2Button.SetActive(false); }

        if (Bedroom3) { Bedroom3Button.SetActive(true); }
        else { Bedroom3Button.SetActive(false); }

        if (Basement) { BasementButton.SetActive(true); }
        else { BasementButton.SetActive(false); }

        if (WineCellar) { WineCellarButton.SetActive(true); }
        else { WineCellarButton.SetActive(false); }

        if (RecRoom) { RecRoomButton.SetActive(true); }
        else { RecRoomButton.SetActive(false); }

        if (Study) { StudyButton.SetActive(true); }
        else { StudyButton.SetActive(false); }

        if (Outside) { OutsideButton.SetActive(true); }
        else { OutsideButton.SetActive(false); }

        if (Attic) { AtticButton.SetActive(true); }
        else { AtticButton.SetActive(false); }


        // Bool logic that connects starwell repair to availability of rooms in the room manager

        if (StairwellFirstFloor)
        {
            LivingRoom = true;
            Bedroom2 = true;
            Bedroom3 = true;
        }

        if (StairwellSecondFloor)
        {
            Study = true;
        }

        if (StairwellThirdFloor)
        {
            Attic = true;
        }


        // Update the clock
        TimeImage.fillAmount = ((houseManager.dayTimer) / houseManager.dayLength);



    }



    #endregion


    #region: Open/Close Panels................

    /// <summary>
    /// Open/Close NPC Manager Panel
    /// </summary>
    public void OpenNpcManagerPanel()
    {
        if (npcManagerPanel.activeSelf)
        {
            npcManagerPanel.SetActive(false);
        }
        else
        {
            npcManagerPanel.SetActive(true);
        }
        audioManager.PlayOneShotByName("OpenPanel");
    }

    public void CloseNpcManagerPanel()
    {
        npcManagerPanel.SetActive(false);
        tennantButton.SetActive(true);
        audioManager.PlayOneShotByName("ClosePanel");

    }

    /// <summary>
    /// Open/Close KitchenRoomPanel
    /// </summary>
    public void OpenKitchenRoomPanel()
    {
        KitchenRoomPanel.SetActive(true);       
        audioManager.PlayOneShotByName("OpenPanel");

    }

    public void CloseKitchenRoomPanel()
    {
        KitchenRoomPanel.SetActive(false);
        audioManager.PlayOneShotByName("ClosePanel");

    }



    /// <summary>
    /// Open CLose LivingRoomPanel
    /// </summary>
    public void OpenLivingRoomPanel()
    {
        LivingRoomPanel.SetActive(true);
        audioManager.PlayOneShotByName("OpenPanel");

    }

    public void CloseLivingRoomPanel()
    {
        LivingRoomPanel.SetActive(false);
        audioManager.PlayOneShotByName("ClosePanel");

    }



    /// <summary>
    /// Open Close BedRoom1Panel
    /// </summary>
    public void OpenBedRoom1Panel()
    {
        BedRoom1Panel.SetActive(true);
        audioManager.PlayOneShotByName("OpenPanel");

    }

    public void CloseBedRoom1Panel()
    {
        BedRoom1Panel.SetActive(false);
        audioManager.PlayOneShotByName("ClosePanel");

    }

    /// <summary>
    /// Open Close BedRoom2Panel
    /// </summary>
    public void OpenBedRoom2Panel()
    {
        BedRoom2Panel.SetActive(true);
        audioManager.PlayOneShotByName("OpenPanel");

    }

    public void CloseBedRoom2Panel()
    {
        BedRoom2Panel.SetActive(false);
        audioManager.PlayOneShotByName("ClosePanel");

    }

    /// <summary>
    /// Open Close BedRoom3Panel
    /// </summary>
    public void OpenBedRoom3Panel()
    {
        BedRoom3Panel.SetActive(true);
        audioManager.PlayOneShotByName("OpenPanel");

    }

    public void CloseBedRoom3Panel()
    {
        BedRoom3Panel.SetActive(false);
        audioManager.PlayOneShotByName("ClosePanel");

    }



    /// <summary>
    /// Open Close RecRoomPanel
    /// </summary>
    public void OpenRecRoomPanel()
    {
        RecRoomPanel.SetActive(true);
        audioManager.PlayOneShotByName("OpenPanel");

    }

    public void CloseRecRoomPanel()
    {
        RecRoomPanel.SetActive(false);
        audioManager.PlayOneShotByName("ClosePanel");

    }

    /// <summary>
    /// Open Close WineCellarRoomPanel
    /// </summary>
    public void OpenWineCellarRoomPanel()
    {
        WineCellarRoomPanel.SetActive(true);
        audioManager.PlayOneShotByName("OpenPanel");

    }

    public void CloseWineCellarRoomPanel()
    {
        WineCellarRoomPanel.SetActive(false);
        audioManager.PlayOneShotByName("ClosePanel");

    }





    /// <summary>
    /// Open Close OutDoorRoomPanel
    /// </summary>
    public void OpenBathRoomPanel()
    {
        BathRoomPanel.SetActive(true);
        audioManager.PlayOneShotByName("OpenPanel");

    }

    public void CloseBathRoomPanel()
    {
        BathRoomPanel.SetActive(false);
        audioManager.PlayOneShotByName("ClosePanel");

    }

    /// <summary>
    /// Open Close AtticRoomPanel
    /// </summary>
    public void OpenAtticRoomPanel()
    {
        AtticRoomPanel.SetActive(true);
        audioManager.PlayOneShotByName("OpenPanel");

    }

    public void CloseAtticRoomPanel()
    {
        AtticRoomPanel.SetActive(false);
        audioManager.PlayOneShotByName("ClosePanel");

    }



    /// <summary>
    /// Open Close BasementRoomPanel
    /// </summary>
    public void OpenBasementRoomPanel()
    {
        BasementRoomPanel.SetActive(true);
        audioManager.PlayOneShotByName("OpenPanel");

    }

    public void CloseBasementRoomPanel()
    {
        BasementRoomPanel.SetActive(false);
        audioManager.PlayOneShotByName("ClosePanel");

    }

    /// <summary>
    /// Open Close OutsideRoomPanel
    /// </summary>
    public void OpenOutsideRoomPanel()
    {
        OutsideRoomPanel.SetActive(true);
        audioManager.PlayOneShotByName("OpenPanel");

    }

    public void CloseOutsideRoomPanel()
    {
        OutsideRoomPanel.SetActive(false);
        audioManager.PlayOneShotByName("ClosePanel");

    }


    /// <summary>
    /// Open Close StudyRoomPanel
    /// </summary>
    public void OpenStudyRoomPanel()
    {
        StudyRoomPanel.SetActive(true);
        audioManager.PlayOneShotByName("OpenPanel");

    }

    public void CloseStudyRoomPanel()
    {
        StudyRoomPanel.SetActive(false);
        audioManager.PlayOneShotByName("ClosePanel");

    }

    #endregion


    #region: Item stuff.....................

    public void ItemButton()
    {
        choice = EventSystem.current.currentSelectedGameObject.transform.gameObject.name;
        itemName = EventSystem.current.currentSelectedGameObject.transform.gameObject.GetComponentInChildren<Text>().text;
        fullPrice = EventSystem.current.currentSelectedGameObject.transform.gameObject.GetComponentInChildren<FullPrice>().GetComponent<Text>().text;
        discountPrice = EventSystem.current.currentSelectedGameObject.transform.gameObject.GetComponentInChildren<DiscountPrice>().GetComponent<Text>().text;
        itemImage = EventSystem.current.currentSelectedGameObject.transform.gameObject.GetComponentInChildren<ItemImage>().GetComponent<Image>();

        OpenConfirmItemModal(itemName, fullPrice, discountPrice,itemImage);
    }

    public void OpenConfirmItemModal(string itemName, string fullPrice, string discountPrice, Image image)
    {
        ItemConfirmModal.SetActive(true);
        ItemConfirmModalItemNameText.text = itemName;
        ItemConfirmModalFullPriceText.text = "Full Price: $" + fullPrice;
        ItemConfirmModalDiscountPriceText.text = "Discount Price: $" + discountPrice;
        ItemConfirmModalImage.sprite = itemImage.sprite;
        audioManager.PlayOneShotByName("OpenPanel");
        CloseAllPurchasePanels();
    }

    public void CloseConfirmItemModalAndRoomPanel()
    {
        ItemConfirmModal.SetActive(false);
        CloseAllPurchasePanels();
    }

    public void CloseConfirmModalOnly()
    {
        ItemConfirmModal.SetActive(false);
    }

    public void FullPriceButton()
    {
        if (int.Parse(fullPrice) <= houseManager.bank)
        {
            CloseConfirmItemModalAndRoomPanel();
            for (int i = 0; i < theButtons.Length; i++)
            {
                if (theButtons[i].name == choice)
                    Item[i].SetActive(true);
            }
            houseManager.bank -= int.Parse(fullPrice);
            bankAccountText.text = "$" + houseManager.bank;
            choice = null;
            audioManager.PlayOneShotByName("Purchase");
        }
        else
        {
            audioManager.PlayOneShotByName("CantBuy");
            StartCoroutine(ChangeTextColor(bankAccountText, Color.red, Color.green));
        }
    }

    public void DiscountPriceButton()
    {
        if (int.Parse(discountPrice) <= houseManager.bank)
        {
            CloseConfirmItemModalAndRoomPanel();
            for (int i = 0; i < theButtons.Length; i++)
            {
                if (theButtons[i].name == choice)
                    Item[i].SetActive(true);
            }
            houseManager.bank -= int.Parse(discountPrice);
            bankAccountText.text = "$" + houseManager.bank;
            choice = null;
            audioManager.PlayOneShotByName("Purchase");
        }
        else
        {
            audioManager.PlayOneShotByName("CantBuy");
            StartCoroutine(ChangeTextColor(bankAccountText, Color.red, Color.green));
        }
    }

    IEnumerator ChangeTextColor(Text t, Color a, Color b)
    {
        t.color = a;
        yield return new WaitForSeconds(.3f);
        t.color = b;
        yield return new WaitForSeconds(.3f);
        t.color = a;
        yield return new WaitForSeconds(.3f);
        t.color = b;
        yield return new WaitForSeconds(.3f);
        t.color = a;
        yield return new WaitForSeconds(.3f);
        t.color = b;
    }
    void CloseAllPurchasePanels()
    {
        if (KitchenRoomPanel.activeSelf)
        {
            KitchenRoomPanel.SetActive(false);
        }
        else if (LivingRoomPanel.activeSelf)
        {
            LivingRoomPanel.SetActive(false);
        }
        else if (BathRoomPanel.activeSelf)
        {
            BathRoomPanel.SetActive(false);
        }
        else if (BedRoom1Panel.activeSelf)
        {
            BedRoom1Panel.SetActive(false);
        }
        else if (BedRoom2Panel.activeSelf)
        {
            BedRoom2Panel.SetActive(false);
        }
        else if (BedRoom3Panel.activeSelf)
        {
            BedRoom3Panel.SetActive(false);
        }
        else if (AtticRoomPanel.activeSelf)
        {
            AtticRoomPanel.SetActive(false);
        }
        else if (BasementRoomPanel.activeSelf)
        {
            BasementRoomPanel.SetActive(false);
        }
        else if (WineCellarRoomPanel.activeSelf)
        {
            WineCellarRoomPanel.SetActive(false);
        }
        else if (RecRoomPanel.activeSelf)
        {
            RecRoomPanel.SetActive(false);
        }
        else if (OutsideRoomPanel.activeSelf)
        {
            OutsideRoomPanel.SetActive(false);
        }
        else if (StudyRoomPanel.activeSelf)
        {
            StudyRoomPanel.SetActive(false);
        }

    }
    #endregion


    #region: Buttons and such.......................

    public void MusicOffButton()
    {
        //Debug.Log("music button pushed");
        musicOffButton.gameObject.SetActive(false);
        musicOnButton.gameObject.SetActive(true);
        audioManager.StopMusic();
    }

    public void MusicOnButton()
    {
        //Debug.Log("music button pushed");
        musicOffButton.gameObject.SetActive(true);
        musicOnButton.gameObject.SetActive(false);
        StartCoroutine(audioManager.PlayMusic("Normal"));
    }

    public void CalendarButton()
    {
        //Debug.Log("Calender button pushed");
        if (calendarPanel.activeSelf)
        {
            calendarPanel.SetActive(false);
        }
        else
        {
            calendarPanel.SetActive(true);
        }
    }

    public void RoomManagerButton()
    {
        if (roomManagerPanel.activeSelf)
        {
            roomManagerPanel.SetActive(false);
        }
        else
        {
            roomManagerPanel.SetActive(true);
        }
        audioManager.PlayOneShotByName("RoomManager");

    }

    public void PlayPauseButton()
    {
        if (Time.timeScale == 1) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void DoubleSpeedButton()
    {
        Time.timeScale = 2;
    }

    public void QuadSpeedButton()
    {
        Time.timeScale = 4;
    }

    public void RepairRoomButton(string roomName)
    {
        CloseAllPurchasePanels();
        foreach (var item in houseManager.rooms)
        {
            if (item.name == roomName)
            {
                item.roomState = Room_Class.RoomState.Fixed_Clean;
            }
        }
    }

    #endregion




}
