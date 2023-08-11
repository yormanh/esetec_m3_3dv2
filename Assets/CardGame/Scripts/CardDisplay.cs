using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] Card card;

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI attackText;
    [SerializeField] Image image;


    public void SetCard(Card value)
    {
        card = value;
    }
    void Start()
    {
        //Debug.Log(card.name);
        //card.Print();
        nameText.text = card.name;
        descriptionText.text = card.description;
        attackText.text = card.attack.ToString();
        image.sprite = card.image;
    }

    
    void Update()
    {
        
    }
}
