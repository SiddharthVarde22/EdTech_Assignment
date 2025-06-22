using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Simulation_UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_interactionText;

    public void OnQuitButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void SetInteractionText(string a_text)
    {
        m_interactionText.SetText(a_text);
    }
}
