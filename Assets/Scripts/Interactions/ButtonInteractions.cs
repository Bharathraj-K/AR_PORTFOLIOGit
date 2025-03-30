using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject model;

    //public GameObject modelBody;

    public GameObject quitCanvas;
    public GameObject[] panels;
    void Start()
    {
        foreach(GameObject panel in panels)
        {
            panel.SetActive(false);
        }
        quitCanvas.SetActive(false);
    }
    public void ShowPanel(int panelIndex)
    {
        mainCanvas.SetActive(false);
        model.SetActive(false);
        //modelBody.SetActive(false);
        quitCanvas.SetActive(true);       

        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        
        if (panelIndex >= 0 && panelIndex < panels.Length)
        {
            panels[panelIndex].SetActive(true);
        }
        Debug.Log($"Panel {panelIndex} active? " + panels[panelIndex].activeSelf);

        
    }
}
