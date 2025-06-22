using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CardStorage : MonoBehaviour, IDropHandler
{
    [SerializeField]
    TextMeshProUGUI m_text;

    EAnimalType m_animaltypeToStore;
    List<AnimalCard> m_rightAnswers;
    List<AnimalCard> m_wrongAnswers;

    public void Initialize(EAnimalType a_animalTypeToStore, string a_heading)
    {
        m_animaltypeToStore = a_animalTypeToStore;
        m_rightAnswers = new List<AnimalCard>();
        m_wrongAnswers = new List<AnimalCard>();
        m_text.SetText(a_heading);
    }

    public void OnDrop(PointerEventData a_eventData)
    {
        AnimalCard l_animalCard = a_eventData.pointerDrag.GetComponent<AnimalCard>();
        if (l_animalCard.GetAnimalTypes().HasFlag(m_animaltypeToStore))
        {
            m_rightAnswers.Add(l_animalCard);
        }
        else
        {
            m_wrongAnswers.Add(l_animalCard);
        }
        l_animalCard.OnCardGetsSorted();
    }

    public List<AnimalCard> GetWrongAnswers()
    {
        return m_wrongAnswers;
    }
    public int GetCorrectScore()
    {
        return m_rightAnswers.Count;
    }
}
