using UnityEngine;

public class Fps : MonoBehaviour
{
    private void Start()
    {
#if UNITY_ANDROID
        Application.targetFrameRate = 120;  
#endif
    }
}
