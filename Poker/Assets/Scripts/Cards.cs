using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Cards : MonoBehaviour
{
    [SerializeField] private Image image;
    public CardValue value;

    public void SetValue (CardValue cardValue)
    {
        value = cardValue;
        image.sprite = value.sprite;
}
}

[Serializable]
public class CardValue
{
    public Sprite sprite;
    public Suit suit;
    public int value;
}
public enum Suit
{
    Hearts, 
    Spades, //piki
    Diamonds, //bubni
    Clubs //trefi
}