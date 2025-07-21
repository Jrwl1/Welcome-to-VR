using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

namespace UnityEngine.XR.Interaction.Toolkit
{
    public class CustomContinuousTurnProvider : LocomotionProvider
    {
        [SerializeField]
        InputActionProperty m_LeftHandTurnAction;
        public InputActionProperty leftHandTurnAction
        {
            get => m_LeftHandTurnAction;
            set => SetInputActionProperty(ref m_LeftHandTurnAction, value);
        }

        [SerializeField]
        float m_TurnSpeed = 60f;
        public float turnSpeed
        {
            get => m_TurnSpeed;
            set => m_TurnSpeed = value;
        }

        [SerializeField]
        float m_SmoothingFactor = 5.0f; // Adjust this value as needed for smoother turning
        public float smoothingFactor
        {
            get => m_SmoothingFactor;
            set => m_SmoothingFactor = value;
        }

        Vector2 m_CurrentInput;
        Vector2 m_SmoothedInput;

        protected void Update()
        {
            if (!CanBeginLocomotion())
                return;

            var leftHandValue = m_LeftHandTurnAction.action?.ReadValue<Vector2>() ?? Vector2.zero;

            // Apply turn input if it exists
            if (leftHandValue != Vector2.zero)
            {
                m_CurrentInput = leftHandValue;

                // Smooth the input
                m_SmoothedInput = Vector2.Lerp(m_SmoothedInput, m_CurrentInput, Time.deltaTime * smoothingFactor);

                var turnAmount = m_SmoothedInput.x * m_TurnSpeed * Time.deltaTime;
                TurnRig(turnAmount);
            }
        }

        protected virtual void TurnRig(float turnAmount)
        {
            var xrOrigin = system.xrOrigin;
            if (xrOrigin != null)
            {
                // Ensure the XR rig is rotated around its current position, accounting for movement or recentering
                xrOrigin.transform.Rotate(0, turnAmount, 0);
            }
            else
            {
                // Fallback in case xrOrigin is null
                transform.Rotate(0, turnAmount, 0);
            }
        }

        void SetInputActionProperty(ref InputActionProperty property, InputActionProperty value)
        {
            if (Application.isPlaying)
                property.DisableDirectAction();

            property = value;

            if (Application.isPlaying && isActiveAndEnabled)
                property.EnableDirectAction();
        }
    }
}
