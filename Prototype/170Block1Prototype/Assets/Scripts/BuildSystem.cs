using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuildSystem : MonoBehaviour {
    public GameObject directions;
    public GameObject success;
    public GameObject failure;
    public GameObject MainMenu;
    public Button first;
    public Button second;
    public Button third;
    private bool momo;
    private bool boom;
    private bool pom;


    // Start is called before the first frame update
    void Start()
    {


    }
    public void Test()
    {
        if ((momo) && (pom))
        {
            directions.SetActive(false);
            success.SetActive(true);
            MainMenu.SetActive(true);
            second.interactable = false;
        }
        else if ((pom) && (boom))
        {
            directions.SetActive(false);
            success.SetActive(true);
            first.interactable = false;
            MainMenu.SetActive(true);
        }
        else if ((momo) && (boom))
        {
            directions.SetActive(false);
            failure.SetActive(true);
            third.interactable = false;
            MainMenu.SetActive(true);

        }


    }
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void Item1()
    {

        momo = true;
        Debug.Log("boomClicked");
    }
    public void Item2()
    {
      
        boom = true;
        Debug.Log("boomClicked");
    }
    public void Item3()
    {
        
        pom = true;
        Debug.Log("pomClicked");
    }
    // Update is called once per frame
    void Update()
    {
   
    }
}
