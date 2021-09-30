using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Sprite PaperSprite;
    public Sprite PizzaSprite;
    public Sprite FolderSprite;
    [SerializeField]
    private GameObject[] StackItems = new GameObject[8];
    [SerializeField]
    private int currentItem = 0;
    public GameObject NextText;
    public GameObject FullIndicator;
    public void AddItem(string itemName)
    {
        if(currentItem < 7)
        {
            currentItem++;
            if (itemName == "PaperCollectable")
            {
                StackItems[currentItem].GetComponent<Image>().sprite = PaperSprite;
                StackItems[currentItem].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                NextText.GetComponent<TextMeshProUGUI>().text = "Next Toss:\n\nPaper";
            }
            else if (itemName == "FolderCollectable")
            {
                StackItems[currentItem].GetComponent<Image>().sprite = FolderSprite;
                StackItems[currentItem].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                NextText.GetComponent<TextMeshProUGUI>().text = "Next Toss:\n\nFolder";
            }
            else if (itemName == "PizzaCollectable")
            {
                StackItems[currentItem].GetComponent<Image>().sprite = PizzaSprite;
                StackItems[currentItem].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                NextText.GetComponent<TextMeshProUGUI>().text = "Next Toss:\n\nPizza";
            }
            FullIndicator.SetActive(currentItem == 7);
        }
        
        
    }

    public void RemoveItem()
    {
        StackItems[currentItem].GetComponent<Image>().sprite = null;
        StackItems[currentItem].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        currentItem--;
        if(currentItem < 0)
        {
            currentItem = 0;
        }
        FullIndicator.SetActive(currentItem == 7);
        if (StackItems[currentItem].GetComponent<Image>().sprite == PaperSprite)
        {
            NextText.GetComponent<TextMeshProUGUI>().text = "Next Toss:\n\nPaper";
        }
        else if (StackItems[currentItem].GetComponent<Image>().sprite == FolderSprite)
        {
            NextText.GetComponent<TextMeshProUGUI>().text = "Next Toss:\n\nFolder";
        }
        else if (StackItems[currentItem].GetComponent<Image>().sprite == PizzaSprite)
        {
            NextText.GetComponent<TextMeshProUGUI>().text = "Next Toss:\n\nPizza";
        }
        else
        {
            NextText.GetComponent<TextMeshProUGUI>().text = "No Items!";
        }
    }
}
