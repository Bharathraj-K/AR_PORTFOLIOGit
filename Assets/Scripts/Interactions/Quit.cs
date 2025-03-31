using UnityEngine;

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in Unity Editor
        #else
            Application.Quit(); // Quit the built application
        #endif
    }
}
