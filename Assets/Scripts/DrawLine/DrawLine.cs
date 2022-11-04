using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour{
    [Header("Refrences")]
    [SerializeField] LineRenderer _drawRenderer;
    [SerializeField] RectTransform _panelTransform;

    [Header("Line Settings")]
    [SerializeField] float _resolution;


    private void AddPosition(Vector2 pos){
        if(ValidatePos(pos)) return;

        _drawRenderer.positionCount++;
        _drawRenderer.SetPosition(_drawRenderer.positionCount-1, pos);
    }

    private bool ValidatePos(Vector2 pos){
        if(!RectTransformUtility.RectangleContainsScreenPoint(_panelTransform, pos, Camera.main)) return false;
        if(_drawRenderer.positionCount == 1) return true;
        return Vector2.Distance(_drawRenderer.GetPosition(_drawRenderer.positionCount-1),pos) > _resolution;

    }
}
