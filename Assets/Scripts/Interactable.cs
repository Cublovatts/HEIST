using StarterAssets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public UnityEvent CallbackEvent;
    public Color NotSelectable;
    public Color Selectable;

    [SerializeField]
    private float _maxInteractionDistance;
    [SerializeField]
    private float _maxAngleDifference;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private StarterAssetsInputs _input;

    private MeshRenderer _meshRenderer;
    

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // player in range and focusing on interactable object
        if (IsPlayerInRange() && IsPlayerFocusing())
        {
            _meshRenderer.materials[0].SetColor("_OutlineColor", Selectable);

            // show highlight

            // if player presses interact button, trigger some function
            if (_input.interact)
            {
                CallbackEvent.Invoke();
            }
            

        } else
        {
            _meshRenderer.materials[0].SetColor("_OutlineColor", NotSelectable);
        }

        // REMOVE THIS LATER
        _input.interact = false;
    }

    private bool IsPlayerInRange()
    {
        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) < _maxInteractionDistance)
        {
            return true;
        } else 
        { 
            return false; 
        }
    }

    private bool IsPlayerFocusing()
    {
        Vector3 cameraDir = Camera.main.transform.forward;
        Vector3 objectDir = Vector3.Normalize(gameObject.transform.position - Camera.main.transform.position);

        float angleDifference = Vector3.Angle(cameraDir, objectDir);

        if (angleDifference < _maxAngleDifference)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
