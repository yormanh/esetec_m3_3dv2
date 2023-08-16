using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Card> cards;
    [SerializeField] GameObject cardCanvasPrefab;
    [SerializeField] GameObject rootCanvas;
    
    void Start()
    {
        Print();
    }

    void Print()
    {
        foreach (Card card in cards)
        {
            //CardDisplay cardDisplay = new CardDisplay();
            //cardDisplay.SetCard(card);

            GameObject obj = Instantiate(cardCanvasPrefab);
            obj.transform.SetParent(rootCanvas.transform);
            obj.GetComponent<CardDisplay>().SetCard(card);
        }

    }


    void AddEntry(Card card)
    {
        cards.Add(card);
        Print();
    }

    void RemoveEntry(Card card)
    {
        cards.Remove(card);
        Print();
    }

    void Update()
    {
        
    }
}
