using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivityController : MonoBehaviour
{
    public Slider sensitivitySlider;
    public PlayerMovement playerMovement;

    private void Start()
    {
        if(playerMovement != null && sensitivitySlider != null)
        {
            sensitivitySlider.value = playerMovement.mouseSensitivity;
        }

        sensitivitySlider.onValueChanged.AddListener(UpdateMouseSensitivity);
    }

    private void UpdateMouseSensitivity(float newValue)
    {
        if(playerMovement != null)
        {
            playerMovement.mouseSensitivity = newValue;
        }
    }
}
