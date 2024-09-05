using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        // If running in the Unity editor, this will stop play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // This will quit the application when built
            Application.Quit();
#endif
    }
}
