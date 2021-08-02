using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private IPlayerInput input;
    [SerializeField] private float bufferTime;
    private List<ButtonInput> buttonInputs;

    public bool Jump => GetButtonStatus("Jump");
    public bool Attack => GetButtonStatus("Attack");
    public bool Roll => GetButtonStatus("Roll");
    public bool Test => GetButtonStatus("Test");

    private void Awake()
    {
        EnableInput(true);
        buttonInputs = new List<ButtonInput>();

        buttonInputs.Add(new ButtonInput("Jump", bufferTime));
        buttonInputs.Add(new ButtonInput("Attack", bufferTime));
        buttonInputs.Add(new ButtonInput("Roll", bufferTime));
        buttonInputs.Add(new ButtonInput("Test", bufferTime));
    }

    // Update is called once per frame
    void Update()
    {
        SetButtonStatuses();
    }

    public void EnableInput(bool enabled)
    {
        if (enabled)
        {
            input = new ActivePlayerInput();
        }
        else
        {
            input = new InactivePlayerInput();
        }
    }

    private bool GetButtonStatus(string name)
    {
        bool buttonStatus = false;

        foreach (ButtonInput button in buttonInputs)
        {
            if (name.Equals(button.Name))
            {
                buttonStatus = button.GetButtonStatus();
            }
        }

        return buttonStatus;
    }

    private void SetButtonStatuses()
    {
        foreach (ButtonInput button in buttonInputs)
        {
            switch (button.Name)
            {
                case ("Jump"):
                    button.SetButtonStatus(input.Jump, Time.time);
                    break;
                case ("Attack"):
                    button.SetButtonStatus(input.Attack, Time.time);
                    break;
                case ("Roll"):
                    button.SetButtonStatus(input.Roll, Time.time);
                    break;
                case ("Test"):
                    button.SetButtonStatus(input.Test, Time.time);
                    break;
            }
        }
    }

    private class ButtonInput
    {
        private string name;
        private float bufferTime;
        private float lastTimePressed;
        private bool buttonPressed;

        public ButtonInput(string name, float bufferTime)
        {
            this.name = name;
            this.bufferTime = bufferTime;
            lastTimePressed = 0f;
            buttonPressed = false;
        }

        public string Name => name;

        public bool GetButtonStatus()
        {
            if (buttonPressed)
            {
                buttonPressed = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetButtonStatus(bool buttonPressed, float currentTime)
        {
            if (buttonPressed)
            {
                this.buttonPressed = true;
                lastTimePressed = currentTime;
            }
            else
            {
                if (currentTime - lastTimePressed > bufferTime)
                {
                    this.buttonPressed = false;
                }
            }
        }
    }
}
