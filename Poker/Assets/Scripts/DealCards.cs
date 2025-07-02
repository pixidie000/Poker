using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DealCards : MonoBehaviour
{
    public List<Sprite> allCardSprites; // ��� �����
    public Image[] communitySlots;      // ����� ��� ����� ���� (��������, 2 ��� 3)
    public Image[] playerSlots;         // ����� ��� ���� ������ (��������, 2 ��� 5)
    public Button dealButton;

    private List<Sprite> remainingCards; // �����, ���������� ����� ������� �����

    void Start()
    {
        // ������� ����� ������ ���� ����
        remainingCards = new List<Sprite>(allCardSprites);

        // ������� ����� �����
        DealCommunityCards();

        // ��������� ���������� ��� ������
        dealButton.onClick.AddListener(DealPlayerCard);
    }

    void DealCommunityCards()
    {
        for (int i = 0; i < communitySlots.Length; i++)
        {
            if (remainingCards.Count == 0) break;

            int randIndex = Random.Range(0, remainingCards.Count);
            Sprite sprite = remainingCards[randIndex];

            communitySlots[i].sprite = sprite;

            remainingCards.RemoveAt(randIndex);
        }
    }

    public void DealPlayerCard()
    {
        // ������� ������ ��������� ���� � ������
        for (int i = 0; i < playerSlots.Length; i++)
        {
            if (playerSlots[i].sprite == null || playerSlots[i].sprite.name == "") // �������� �� ������ ����
            {
                if (remainingCards.Count == 0)
                {
                    Debug.Log("��� ���������� ����");
                    return;
                }

                int randIndex = Random.Range(0, remainingCards.Count);
                Sprite sprite = remainingCards[randIndex];

                playerSlots[i].sprite = sprite;
                remainingCards.RemoveAt(randIndex);
                break; // ������ ���� ����� � ������� �� �����
            }
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
