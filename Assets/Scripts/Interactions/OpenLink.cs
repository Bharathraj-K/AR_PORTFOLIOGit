using UnityEngine;

public class OpenLink : MonoBehaviour
{
    
    public void openLink(string url){
        Application.OpenURL(url);
    }
}
