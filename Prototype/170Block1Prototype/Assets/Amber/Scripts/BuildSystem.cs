using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.EventSystems;

public class BuildSystem : MonoBehaviour {
    public GameObject ItemPrefab;
    public GameObject CanvasPrefab;
    public GameObject MiddleItemHolder;
    public GameObject ItemsSelectedPrefab;
    public List<Part> AddPart = new List<Part>();
    private GameObject adding;
    private GameObject Added;
    private Part parts;
   
  

    // Start is called before the first frame update
    void Start()
    {

        //Essentially goes through player inventory and makes a button for each part
        foreach (var part in Player.instance.inventory)
        {

            adding = Instantiate(ItemPrefab);
            adding.transform.SetParent(CanvasPrefab.transform, false);
            adding.GetComponentInChildren<Text>().text = part.DisplayName;
            adding.name = part.DisplayName;
            Button btn = adding.gameObject.GetComponent<Button>();
            string temp = adding.GetComponentInChildren<Text>().text;
            btn.onClick.AddListener(() => Build(temp));

        }
    }
    public void Build(string name)
    {

        parts = Player.instance.inventory.Find(x => x.DisplayName.Contains(name));
        AddPart.Add(parts);
        Added = Instantiate(ItemsSelectedPrefab);
        Added.transform.SetParent(MiddleItemHolder.transform, false);
        Added.GetComponentInChildren<Text>().text = parts.DisplayName;
        Added.name = parts.DisplayName;

    }
    public void removeParts(string name)
    {
        foreach(var part in AddPart)
        {
            Player.instance.inventory.Remove(part);
        }
        AddPart.Clear();
        foreach (var child in MiddleItemHolder.transform.GetComponentsInChildren<Transform>())
            Destroy(child.gameObject);
    }

    public void Scrap()
    {
        SceneManager.LoadScene(0);
    }

}
