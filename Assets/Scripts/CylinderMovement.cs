using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CylinderMovement : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    [SerializeField] private Transform _cylinder;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Ball _ball;
    [SerializeField] private TMP_Text _startText;

    private void OnEnable()
    {
        _ball.Failed += DisableInput;
    }

    private void DisableInput()
    {
        gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var cylinderRotation = _cylinder.transform.rotation;
        var currentRotationY = cylinderRotation.eulerAngles.y;

        currentRotationY += -eventData.delta.x * _rotateSpeed * Time.deltaTime;
        cylinderRotation.eulerAngles = new Vector3(0, currentRotationY, 0);
        
        _cylinder.rotation = cylinderRotation;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startText.enabled = false;
    }
}
