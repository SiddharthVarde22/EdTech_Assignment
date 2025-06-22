using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    private static SimulationManager s_instance;

    public const string TestTubeInteraction = "Click on the Test tube";
    public const string FlaskInteraction = "Click on the Flask";
    public const float m_testTubeMoveTime = 0.5f, m_pourTime = 0.5f;

    [SerializeField] Animator m_chilsAnimator;
    [SerializeField] Simulation_UI m_simUI;
    [SerializeField] TestTube m_testTube;

    private void Awake()
    {
        s_instance = this;
    }
    private void Start()
    {
        m_simUI.SetInteractionText(TestTubeInteraction);
    }
    private void OnDestroy()
    {
        s_instance = null;
    }

    public static void OnTestTubeClicked()
    {
        s_instance.m_simUI.SetInteractionText(FlaskInteraction);
    }

    public static void OnFlaskAnimComplete(EFlaskType a_flaskType)
    {
        switch(a_flaskType)
        {
            case EFlaskType.FlaskA:
                s_instance.m_chilsAnimator.SetTrigger("Exited");
                break;
            case EFlaskType.FlaskB:
                s_instance.m_chilsAnimator.SetTrigger("Irritated");
                break;
        }
    }

    public static void OnClickedFlask(Flask a_clickedFlask)
    {
        s_instance.m_testTube.SetTargetflask(a_clickedFlask);
    }
}
