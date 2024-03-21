using UnityEngine;

public class Dancer : MonoBehaviour
{
    public float sens = 0.5f;
    public float maxSize = 3;
    public GameObject particles;

    void Start()
    {
        Analyzer.onVolumeChanged.AddListener(Dance);
    }

    public void Dance(float volume)
    {
        volume -= 0.15f;
        if (volume < 0f) volume = 0f;
        transform.localScale = Vector3.one * (0.5f + Mathf.Pow(0.5f + volume, sens) * maxSize);
        if (volume > 0.5f)
        {
            Instantiate(particles);
        }
    }
}