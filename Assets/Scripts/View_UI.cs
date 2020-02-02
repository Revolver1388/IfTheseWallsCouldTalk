using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_UI : MonoBehaviour
{

    [SerializeField] public Text bankAccountText;
    [SerializeField] public Text timeText;
    [SerializeField] public Text dayText;
    [SerializeField] Button playPauseButton;
    [SerializeField] Button doubleSpeedButton;
    [SerializeField] Button quadSpeedButton;
    [SerializeField] Button npcManagerOpenButton;
    [SerializeField] Button npcManagerCloseButton;
    [SerializeField] Button roomUpgradePanelOpenButton;
    [SerializeField] Button roomUpgradePanelCloseButton;

    // Manager Panels
    [SerializeField] GameObject npcManagerPanel;

    // Room Panels
    [SerializeField] GameObject KitchenRoomPanel;
    [SerializeField] GameObject LivingRoomPanel;
    [SerializeField] GameObject BedRoom1Panel;
    [SerializeField] GameObject BedRoom2Panel;
    [SerializeField] GameObject RecRoomPanel;
    [SerializeField] GameObject WineCellarRoomPanel;
    [SerializeField] GameObject OutDoorRoomPanel;
    [SerializeField] GameObject BathRoomPanel;
    [SerializeField] GameObject AtticRoomPanel;
    [SerializeField] GameObject BasementRoomPanel;
    [SerializeField] GameObject OutsideRoomPanel;




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
        KitchenRoomPanel.SetActive(true);
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


}


