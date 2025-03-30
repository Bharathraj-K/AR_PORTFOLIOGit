using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject model;
    public GameObject[] panels;

    public void OnClick(){
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
        mainCanvas.SetActive(true);
        model.SetActive(true);
        gameObject.SetActive(false);

    }
}
