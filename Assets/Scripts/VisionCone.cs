using UnityEngine;

public class VisionCone : MonoBehaviour
{
    [SerializeField]
    private Detection _detection;
    [SerializeField]
    private float _coneDetectionFactor;
    [SerializeField]
    private PlayerStealth _playerStealth;
    [SerializeField]
    private MeshRenderer _enemyMeshRenderer;
    [SerializeField]
    private GameObject _enemyObject;

    private void Start()
    {
        _enemyMeshRenderer.material.color = Color.green; 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject targetObject = _playerStealth.GetVisionTarget();

            Vector3 direction = targetObject.transform.position - _enemyObject.transform.position;
            Debug.DrawRay(_enemyObject.transform.position, direction, Color.red, 1.0f);
            RaycastHit hitInfo;
            int layerMask = ~(1 << 10);
            if (Physics.Raycast(_enemyObject.transform.position, direction, out hitInfo, 50.0f, layerMask))
            {
                if (hitInfo.collider.tag == "Player")
                {
                    _detection.IncrementDetectionLevel(_playerStealth.GetVisibilityFactor() * _coneDetectionFactor * Time.deltaTime, hitInfo.collider.transform.position);
                } 
            }
        }
    }
}
