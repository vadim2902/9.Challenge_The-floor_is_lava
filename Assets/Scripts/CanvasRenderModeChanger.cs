using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasRenderModeChanger : MonoBehaviour
{
    public GameObject InstructionCanvas;
    public GameObject PauseCanvas;
    
    public void EnableInstructionCanvas()
    {
        InstructionCanvas.SetActive(true);
    }
    public void EnablePauseCanvas()
    {
        PauseCanvas.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            EnableInstructionCanvas();
        }

    
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (InstructionCanvas.activeSelf)
            {
                InstructionCanvas.SetActive(false);
            }
            else
            {
                if (PauseCanvas.activeSelf)
                {
                    Time.timeScale = 1f;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    PauseCanvas.SetActive(false);
                }
                else
                {
                    EnablePauseCanvas();
                    Time.timeScale = 0f;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
    }
}