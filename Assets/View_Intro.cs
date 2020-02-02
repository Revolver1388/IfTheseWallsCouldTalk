using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class View_Intro : MonoBehaviour
{

    [SerializeField] GameObject aboutPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OpenAbout()
    {
        aboutPanel.SetActive(true);
    }
    public void CloseAbout()
    {
        aboutPanel.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Main 1");
    }

}
