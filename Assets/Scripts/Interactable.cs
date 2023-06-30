using StarterAssets;
using UnityEngine;
using UnityEngine.Events;

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
    [SerializeField]
    private Material _outlineMaterial;

    private MeshRenderer _meshRenderer;
    private int _outlineMaterialIndex;
    private bool _isInView = true;
    
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();   
    }

    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        if (_isInView)
        {
            TurnInteractions();
        }
    }

    private void Setup()
    {
        Material[] materials = new Material[_meshRenderer.materials.Length + 1];
        _meshRenderer.materials.CopyTo(materials, materials.Length - 2);
        materials[materials.Length - 1] = _outlineMaterial;
        _outlineMaterialIndex = materials.Length - 1;
        _meshRenderer.materials = materials;
    }

    public void TurnInteractions()
    {
        if (IsPlayerInRange() && IsPlayerFocusing())
        {
            UpdateInteractableMaterial(Selectable);

            if (_input.interact)
            {
                CallbackEvent.Invoke();
            }
        }
        else
        {
            UpdateInteractableMaterial(NotSelectable);
        }

        // REMOVE THIS LATER
        _input.interact = false;
    }

    private void OnBecameVisible()
    {
        _isInView = true;
    }

    private void OnBecameInvisible()
    {
        _isInView = false;
    }

    private void UpdateInteractableMaterial(Color setColor)
    {
        if (_outlineMaterialIndex == -1 || _meshRenderer.materials[_outlineMaterialIndex] != _outlineMaterial)
        {
            UpdateOutlineMaterialIndex();
            if (_outlineMaterialIndex == -1)
            {
                return;
            }
        }
        _meshRenderer.materials[_outlineMaterialIndex].SetColor("_OutlineColor", setColor);
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

    private void UpdateOutlineMaterialIndex()
    {
        for (int i=0; i<_meshRenderer.materials.Length; i++)
        {
            if (_meshRenderer.materials[i] == _outlineMaterial)
            {
                _outlineMaterialIndex = i;
                return;
            }
        }
    }
}

