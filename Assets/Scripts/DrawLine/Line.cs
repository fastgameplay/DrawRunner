using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Line : MonoBehaviour{
    [SerializeField] private LineRenderer _renderer;
 
    [SerializeField] float _scale;
    [SerializeField] float _distanceBetweenPoints;
    private List<Vector2> _points = new List<Vector2>();

 
    public void SetPosition(Vector3 pos) {
        if(!CanAppend(pos)) return;
        
        _points.Add(pos);
    
        _renderer.positionCount++;
        _renderer.SetPosition(_renderer.positionCount-1,pos*_scale);
 
    }
    public void Reset(){
        _renderer.positionCount = 0;
        _points = new List<Vector2>();
    }
    private bool CanAppend(Vector3 pos) {
        if (_renderer.positionCount == 0) return true;
 
        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > _distanceBetweenPoints;
    }
}
