using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestTube : MonoBehaviour
{
    [SerializeField] Vector3 m_targetRotation = new Vector3(0, 0, 65f);
    [SerializeField] float m_moveTime = 1, m_rotateTime = 0.5f;

    Vector3 m_startPos;
    Flask m_targetFlask;

    private void Start()
    {
        m_startPos = transform.position;
    }

    private void OnMouseDown()
    {
        // change the text
        SimulationManager.OnTestTubeClicked();
    }

    public void SetTargetflask(Flask a_targetFlask)
    {
        m_targetFlask = a_targetFlask;
        Sequence l_sequance = DOTween.Sequence();
        l_sequance.Append(transform.DOMove(a_targetFlask.m_targetPos.position, m_moveTime));
        l_sequance.Append(transform.DORotate(m_targetRotation, m_rotateTime).OnComplete(TargetFlaskColorUpdate));
        l_sequance.AppendInterval(SimulationManager.m_pourTime);
        l_sequance.Append(transform.DORotate(Vector3.zero, m_rotateTime));
        l_sequance.Append(transform.DOMove(m_startPos, m_moveTime));
        l_sequance.AppendCallback(OnAnimationComplete);
    }

    void TargetFlaskColorUpdate()
    {
        m_targetFlask.StartAnimation();
    }
    void OnAnimationComplete()
    {
        SimulationManager.OnFlaskAnimComplete(m_targetFlask.GetFlaskType());
    }
}
