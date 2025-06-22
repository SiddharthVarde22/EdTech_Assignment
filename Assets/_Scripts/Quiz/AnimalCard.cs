using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimalCard : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] AnimalDataSO m_animalData;
    [SerializeField] Image m_animalImage;

    bool m_isDragging = false;

    private void Start()
    {
        QuizManager.IncreaseNumberOfCards();
        m_animalImage.sprite = m_animalData.GetSprite();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        m_isDragging = true;
        m_animalImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData a_eventData)
    {
        transform.position = a_eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_isDragging = false;
        m_animalImage.raycastTarget = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(m_isDragging)
        {
            return;
        }
        // Show description popup
        QuizManager.ShowDescriptionPopup(m_animalData.GetAnimalDesription(), m_animalData.GetAnimalName());
    }
    public EAnimalType GetAnimalTypes()
    {
        return m_animalData.GetAnimalTypes();
    }
    public void OnCardGetsSorted()
    {
        gameObject.SetActive(false);
        QuizManager.DecreaseNumberOfCards();
    }

}
