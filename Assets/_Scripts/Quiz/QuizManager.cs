using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    private static QuizManager s_instance;

    [SerializeField] TextMeshProUGUI m_nameText, m_descriptionText, m_scoreTetx;
    [SerializeField] GameObject m_descriptionPopup, m_resultScreen, m_showWrongAnswersButton;
    [SerializeField] CardStorage m_blueStorage, m_redStorage;
    [SerializeField] RectTransform m_wrongAnswerParent;

    int m_totalNumberOfCards = 0;

    private void Awake()
    {
        s_instance = this;
        InitializeCardStorages();
    }
    private void OnDestroy()
    {
        s_instance = null;
    }

    public static void IncreaseNumberOfCards()
    {
        s_instance.m_totalNumberOfCards++;
    }
    public static void DecreaseNumberOfCards()
    {
        s_instance.m_totalNumberOfCards--;
        if(s_instance.m_totalNumberOfCards <= 0)
        {
            // Show Final Screen
            s_instance.ShowResultScreen();
        }
    }
    public static void ShowDescriptionPopup(string a_description, string a_name)
    {
        s_instance.m_nameText.SetText(a_name);
        s_instance.m_descriptionText.SetText(a_description);
        s_instance.m_descriptionPopup.SetActive(true);
    }
    public void HideDescriptionPopup()
    {
        m_descriptionPopup.SetActive(false);
    }

    private void InitializeCardStorages()
    {
        int l_randomNumber = Random.Range(0, 5);
        EAnimalType l_blueAnimalType = EAnimalType.Flying, l_redAnimalType = EAnimalType.NonFlying;
        string l_blueHeading = null, l_redHeading = null;

        switch(l_randomNumber)
        {
            case 0:
                l_blueAnimalType = EAnimalType.Flying;
                l_redAnimalType = EAnimalType.NonFlying;
                l_blueHeading = "Flying";
                l_redHeading = "Non Flying";
                break;
            case 1:
                l_blueAnimalType = EAnimalType.Herbivorous;
                l_redAnimalType = EAnimalType.Omnivorous;
                l_blueHeading = "Herbivorous";
                l_redHeading = "Omnivorous";
                break;
            case 2:
                l_blueAnimalType = EAnimalType.Insect;
                l_redAnimalType = EAnimalType.NonInsect;
                l_blueHeading = "Insect";
                l_redHeading = "Non insect";
                break;
            case 3:
                l_blueAnimalType = EAnimalType.LivesInGroup;
                l_redAnimalType = EAnimalType.LivesSolo;
                l_blueHeading = "Group";
                l_redHeading = "Solo";
                break;
            case 4:
                l_blueAnimalType = EAnimalType.LaysEggs;
                l_redAnimalType = EAnimalType.GivesBirth;
                l_blueHeading = "Eggs";
                l_redHeading = "Birth";
                break;
        }
        m_blueStorage.Initialize(l_blueAnimalType, l_blueHeading);
        m_redStorage.Initialize(l_redAnimalType, l_redHeading);
    }

    private void ShowResultScreen()
    {
        int l_score = m_blueStorage.GetCorrectScore() + m_redStorage.GetCorrectScore();
        m_scoreTetx.SetText($"You have given {l_score} Correct answers");
        m_resultScreen.SetActive(true);
    }
    public void OnExitPressed()
    {
        m_resultScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void ShowWrongAnswers()
    {
        List<AnimalCard> l_wrongAnswers = new List<AnimalCard>();
        l_wrongAnswers.AddRange(m_blueStorage.GetWrongAnswers());
        l_wrongAnswers.AddRange(m_redStorage.GetWrongAnswers());
        m_showWrongAnswersButton.SetActive(false);

        for(int i = 0; i < l_wrongAnswers.Count; i++)
        {
            l_wrongAnswers[i].transform.SetParent(m_wrongAnswerParent);
            l_wrongAnswers[i].gameObject.SetActive(true);
        }
        m_wrongAnswerParent.gameObject.SetActive(true);
        l_wrongAnswers = null;
    }
}
