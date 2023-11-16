using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    // Variables
    [Header("Settings")]
    [SerializeField] private bool m_defaultState = true;
    [SerializeField] private float m_offValue = 0;
    [SerializeField] private float m_onValue = 1;

    [Header("References")]
    [SerializeField] private FMODUnity.StudioGlobalParameterTrigger m_parameterTrigger;

    private bool m_state;

    //Methods
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        m_state = m_defaultState;
        Set(m_state);
    }

    /// <summary>
    /// Toggle the parameters.
    /// </summary>
    public void Toggle()
    {
        m_state = !m_state;
        Set(m_state);
    }

    /// <summary>
    /// Set the parameter state using a bool value.
    /// </summary>
    public void Set(bool on)
    {
        Set(on ? m_onValue : m_offValue);
    }

    /// <summary>
    /// Set the parameter state using a float value.
    /// </summary>
    public void Set(float value)
    {
        m_parameterTrigger.Value = value;
        m_parameterTrigger.TriggerParameters();
    }
}
