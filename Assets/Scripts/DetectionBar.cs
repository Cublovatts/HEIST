using UnityEngine;

public class DetectionBar : MonoBehaviour
{
    public float _currentDetection;

    private float _detectionMax = 100f;
    private float _maxWidth = 0.2f;

    void Update()
    {
        SetDetectionBarWidth();
    }

    private void SetDetectionBarWidth()
    {
        float targetWidth = (_currentDetection / _detectionMax) * _maxWidth;
        Vector3 localScale = transform.localScale;
        localScale.x = targetWidth;
        transform.localScale = localScale;
    }
}
