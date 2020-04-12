using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public GameObject ChatPanel;
    public GameObject SettingPanel;

    public void SetResolution1280720()
    {
        FullScreenMode fullScreenMode = Screen.fullScreenMode;
        Screen.SetResolution(1280, 720, fullScreenMode);
    }

    public void SetResolution19201080()
    {
        FullScreenMode fullScreenMode = Screen.fullScreenMode;
        Screen.SetResolution(1920, 1080, fullScreenMode);
    }

    public void SetResolutionSD()
    {
        FullScreenMode fullScreenMode = Screen.fullScreenMode;
        Screen.SetResolution(Screen.width, Screen.height, fullScreenMode);
    }

    public void SetFullScreenMode()
    {
        FullScreenMode fullScreenMode = Screen.fullScreenMode;
        if (fullScreenMode != FullScreenMode.Windowed)
        {
            Screen.fullScreen = false;
            return;
        }
        else
        {
            Screen.fullScreen = true;
            return;
        }
    }

    public void GoesSettings()
    {
        ChatPanel.SetActive(false);
        SettingPanel.SetActive(true);
    }

    public void GoesChatting()
    {
        ChatPanel.SetActive(true);
        SettingPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
