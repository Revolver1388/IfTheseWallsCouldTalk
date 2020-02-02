using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_UI : MonoBehaviour
{

    [SerializeField] public Text bankAccountText;
    [SerializeField] public Text timeText;
    [SerializeField] public Text dayText;
    [SerializeField] public Image TimeImage;

 
    // Manager Panels
    [SerializeField] GameObject npcManagerPanel;
    [SerializeField] GameObject roomManagerPanel;

    // Room Panels
    [SerializeField] GameObject KitchenRoomPanel;
    [SerializeField] GameObject LivingRoomPanel;
    [SerializeField] GameObject BedRoom1Panel;
    [SerializeField] GameObject BedRoom2Panel;
    [SerializeField] GameObject BedRoom3Panel;
    [SerializeField] GameObject RecRoomPanel;
    [SerializeField] GameObject WineCellarRoomPanel;
    [SerializeField] GameObject OutDoorRoomPanel;
    [SerializeField] GameObject BathRoomPanel;
    [SerializeField] GameObject AtticRoomPanel;
    [SerializeField] GameObject BasementRoomPanel;
    [SerializeField] GameObject OutsideRoomPanel;
    [SerializeField] GameObject ItemConfirmModal;
    [SerializeField] Text ItemConfirmModalItemNameText;
    [SerializeField] Text ItemConfirmModalFullPriceText;
    [SerializeField] Text ItemConfirmModalDiscountPriceText;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    /// <summary>
    /// Open/Close NPC Manager Panel
    /// </summary>
    public void OpenNpcManagerPanel()
    {
        npcManagerPanel.SetActive(true);
    }

    public void CloseNpcManagerPanel()
    {
        npcManagerPanel.SetActive(false);
    }

    /// <summary>
    /// Open/Close KitchenRoomPanel
    /// </summary>
    public void OpenKitchenRoomPanel()
    {
        KitchenRoomPanel.SetActive(true);
    }

    public void CloseKitchenRoomPanel()
    {
        KitchenRoomPanel.SetActive(false);
    }



    /// <summary>
    /// Open CLose LivingRoomPanel
    /// </summary>
    public void OpenLivingRoomPanel()
    {
        LivingRoomPanel.SetActive(true);
    }

    public void CloseLivingRoomPanel()
    {
        LivingRoomPanel.SetActive(false);
    }



    /// <summary>
    /// Open Close BedRoom1Panel
    /// </summary>
    public void OpenBedRoom1Panel()
    {
        BedRoom1Panel.SetActive(true);
    }

    public void CloseBedRoom1Panel()
    {
        BedRoom1Panel.SetActive(false);
    }

    /// <summary>
    /// Open Close BedRoom2Panel
    /// </summary>
    public void OpenBedRoom2Panel()
    {
        BedRoom2Panel.SetActive(true);
    }

    public void CloseBedRoom2Panel()
    {
        BedRoom2Panel.SetActive(false);
    }

    /// <summary>
    /// Open Close BedRoom3Panel
    /// </summary>
    public void OpenBedRoom3Panel()
    {
        BedRoom3Panel.SetActive(true);
    }

    public void CloseBedRoom3Panel()
    {
        BedRoom3Panel.SetActive(false);
    }



    /// <summary>
    /// Open Close RecRoomPanel
    /// </summary>
    public void OpenRecRoomPanel()
    {
        RecRoomPanel.SetActive(true);
    }

    public void CloseRecRoomPanel()
    {
        RecRoomPanel.SetActive(false);
    }

    /// <summary>
    /// Open Close WineCellarRoomPanel
    /// </summary>
    public void OpenWineCellarRoomPanel()
    {
        WineCellarRoomPanel.SetActive(true);
    }

    public void CloseWineCellarRoomPanel()
    {
        WineCellarRoomPanel.SetActive(false);
    }


    /// <summary>
    /// Open Close OutDoorRoomPanel
    /// </summary>
    public void OpenOutDoorRoomPanel()
    {
        OutDoorRoomPanel.SetActive(true);
    }

    public void CloseOutDoorRoomPanel()
    {
        OutDoorRoomPanel.SetActive(false);
    }


    /// <summary>
    /// Open Close OutDoorRoomPanel
    /// </summary>
    public void OpenBathRoomPanel()
    {
        BathRoomPanel.SetActive(true);
    }

    public void CloseBathRoomPanel()
    {
        BathRoomPanel.SetActive(false);
    }

    /// <summary>
    /// Open Close AtticRoomPanel
    /// </summary>
    public void OpenAtticRoomPanel()
    {
        AtticRoomPanel.SetActive(true);
    }

    public void CloseAtticRoomPanel()
    {
        AtticRoomPanel.SetActive(false);
    }

    

    /// <summary>
    /// Open Close BasementRoomPanel
    /// </summary>
    public void OpenBasementRoomPanel()
    {
        BasementRoomPanel.SetActive(true);
    }

    public void CloseBasementRoomPanel()
    {
        BasementRoomPanel.SetActive(false);
    }

    /// <summary>
    /// Open Close OutsideRoomPanel
    /// </summary>
    public void OpenOutsideRoomPanel()
    {
        OutsideRoomPanel.SetActive(true);
    }

    public void CloseOutsideRoomPanel()
    {
        OutsideRoomPanel.SetActive(false);
    }

    //public void ItemButton(string itemName, int fullPrice, int discountPrice)
    //{
    //    OpenConfirmItemModal(itemName, fullPrice, discountPrice);
    //}

    public void ItemButton()
    {
        string itemName = "itemName";
        int fullPrice = 100;
        int discountPrice = 50;
        OpenConfirmItemModal(itemName, fullPrice, discountPrice);
    }


    public void OpenConfirmItemModal(string itemName, int fullPrice, int discountPrice)
    {
        ItemConfirmModal.SetActive(true);
        ItemConfirmModalItemNameText.text = itemName;
        ItemConfirmModalFullPriceText.text = "Full Price: $" + fullPrice.ToString();
        ItemConfirmModalDiscountPriceText.text = "Discount Price: $" + discountPrice.ToString();
    }

    public void CloseConfirmItemModalAndRoomPanel()
    {
        ItemConfirmModal.SetActive(false);

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
    }

    public void CloseConfirmModalOnly()
    {
        ItemConfirmModal.SetActive(false);

    }

    public void FullPriceButton()
    {
        // TODO: Purchase Item for full price via game controller
        CloseConfirmItemModalAndRoomPanel();
    }

    public void DiscountPriceButton()
    {
        // TODO: Purchase Item for discount price via game controller
        CloseConfirmItemModalAndRoomPanel();

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
    }

    public void PlayPauseButton()
    {
        // TODO: Play Pause Button
    }

    public void DoubleSpeedButton()
    {
        // TODO: Double Speed Button
    }

    public void QuadSpeedButton()
    {
        // TODO: Quad speed button
    }

    public void RepairRoomButton(string roomName)
    {
        // TODO: hook up to game controller
    }

}


