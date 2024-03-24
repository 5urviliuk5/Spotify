using UnityEngine;

public class CircleDancer : MonoBehaviour
{
    public int count = 10;
    public GameObject prefab;
    public float radius = 3f;
    public float sensitivity = 5f;
    public float rotateSpeed = 10f;
    public float minScale = 0.2f;

    void Start()
    {
        for (float i = 0; i < count; i++)
        {
            var angle = i / count * Mathf.PI * 2f;
            var x = Mathf.Cos(angle);
            var y = Mathf.Sin(angle);
            var pos = new Vector3(x, y, 0) * radius;

            var obj = Instantiate(prefab, pos, Quaternion.identity, transform);
            // obj.transform.LookAt(transform);
        }

        Analyzer.onVolumeChanged.AddListener(Dance);
    }

    void Dance(float volume)
    {
        var intensity = Mathf.Pow(volume, sensitivity);
        transform.Rotate(0, 0, intensity * Time.deltaTime * rotateSpeed);
        transform.localScale = Vector3.one * (minScale + volume);
    }
}