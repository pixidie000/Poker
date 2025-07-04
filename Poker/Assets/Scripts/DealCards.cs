using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DealCards : MonoBehaviour
{
    public List<CardValue> allCardSprites;
    public Image[] communitySlots;
    public Image[] playerSlots;
    public Button dealButton;
    private List<CardValue> remainingCards;
    public GameObject combos;
    private bool isCombosOpn = false;
    private float checkCount = 0;
    public GameObject cardCloser;
    void Start()
    {
        remainingCards = new List<CardValue>(allCardSprites);
        DealCommunityCards();
        dealButton.onClick.AddListener(DealPlayerCard);
    }
    private void Update()
    {
        if (checkCount == 5)
        {
            cardCloser.SetActive(false);
        }
    }

    void DealCommunityCards()
    {
        for (int i = 0; i < communitySlots.Length; i++)
        {
            if (remainingCards.Count == 0) break;

            int randIndex = Random.Range(0, remainingCards.Count);
            Sprite sprite = remainingCards[randIndex].sprite;

            communitySlots[i].sprite = sprite;

            remainingCards.RemoveAt(randIndex);
        }
    }

    public void DealPlayerCard()
    {
        for (int i = 0; i < playerSlots.Length; i++)
        {
            if (playerSlots[i].sprite == null || playerSlots[i].sprite.name == "")
            {
                if (remainingCards.Count == 0)
                {
                    Debug.Log("Нет оставшихся карт");
                    return;
                }

                int randIndex = Random.Range(0, remainingCards.Count);
                Sprite sprite = remainingCards[randIndex].sprite;

                playerSlots[i].sprite = sprite;
                remainingCards.RemoveAt(randIndex);
                break;
            }
        }
        checkCount++;
    }
    public void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OpenCombs()
    {
        if (!isCombosOpn)
        {
            combos.SetActive(true);
            isCombosOpn = true;
        }
        else
        {
            combos.SetActive(false);
            isCombosOpn = false;
        }
    }
}
