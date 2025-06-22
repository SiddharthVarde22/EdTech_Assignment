using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum EFlaskType
{
    FlaskA,
    FlaskB
}

public class Flask : MonoBehaviour
{
    public Transform m_targetPos;

    [SerializeField] Color m_targetColor;
    [SerializeField] Collider m_inputCollider;
    [SerializeField] EFlaskType m_type;
    [SerializeField] ParticleSystem m_particleSystem;
    [SerializeField] MeshRenderer m_liquidRenderer;

    Material[] m_instancedMaterials;

    private void Start()
    {
        m_instancedMaterials = m_liquidRenderer.materials;
    }

    private void OnMouseDown()
    {
        SimulationManager.OnClickedFlask(this);
        m_inputCollider.enabled = false;
    }

    public void StartAnimation()
    {
        foreach(Material l_mat in m_instancedMaterials)
        {
            l_mat.DOColor(m_targetColor, "_Tint", SimulationManager.m_pourTime);
        }

        if(m_type == EFlaskType.FlaskB)
        {
            m_particleSystem.Play();
        }
    }

    public EFlaskType GetFlaskType()
    {
        return m_type;
    }
}
