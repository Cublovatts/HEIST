using UnityEngine;

public class Detection : MonoBehaviour
{
    public Vector3 LastKnownPosition;

    [SerializeField]
    private DetectionBar _detectionBar;

    private float _currentDetectionLevel = 0f;
    private float _maxDetectionLevel = 100f;
    private float _lastTimePlayerSeen = 0f;

    void Update()
    {
        UpdateDetectionBar();
        DecayDetectionLevel();
        DecayLastKnownPosition();
    }

    public void IncrementDetectionLevel(float detectionIncrement, Vector3 stimulusPosition)
    {
        _currentDetectionLevel += detectionIncrement;
        _currentDetectionLevel = Mathf.Clamp(_currentDetectionLevel, 0f, _maxDetectionLevel);
        LastKnownPosition = stimulusPosition;
        _lastTimePlayerSeen = Time.time;
    } 

    public float GetCurrentDetectionLevel()
    {
        return _currentDetectionLevel;
    }

    private void UpdateDetectionBar()
    {
        _detectionBar.CurrentDetection = _currentDetectionLevel;
    }

    private void DecayDetectionLevel()
    {
        _currentDetectionLevel -= 5f * Time.deltaTime;
        _currentDetectionLevel = Mathf.Clamp(_currentDetectionLevel, 0f, _maxDetectionLevel);
    }

    private void DecayLastKnownPosition()
    {
        if (Time.time - _lastTimePlayerSeen > 10f)
        {
            LastKnownPosition = gameObject.transform.position;
        }
    }
}
