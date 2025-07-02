using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DealCards : MonoBehaviour
{
    public List<Sprite> allCardSprites; // Все карты
    public Image[] communitySlots;      // Слоты для общих карт (например, 2 или 3)
    public Image[] playerSlots;         // Слоты для карт игрока (например, 2 или 5)
    public Button dealButton;

    private List<Sprite> remainingCards; // Карты, оставшиеся после раздачи общих

    void Start()
    {
        // Создаем копию списка всех карт
        remainingCards = new List<Sprite>(allCardSprites);

        // Раздаем общие карты
        DealCommunityCards();

        // Назначаем обработчик для кнопки
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
        // Находим первый свободный слот у игрока
        for (int i = 0; i < playerSlots.Length; i++)
        {
            if (playerSlots[i].sprite == null || playerSlots[i].sprite.name == "") // Проверка на пустой слот
            {
                if (remainingCards.Count == 0)
                {
                    Debug.Log("Нет оставшихся карт");
                    return;
                }

                int randIndex = Random.Range(0, remainingCards.Count);
                Sprite sprite = remainingCards[randIndex];

                playerSlots[i].sprite = sprite;
                remainingCards.RemoveAt(randIndex);
                break; // Выдали одну карту — выходим из цикла
            }
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
