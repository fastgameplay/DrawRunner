using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Line : MonoBehaviour{
    public List<Vector2> Points {get; private set;}
    public bool ReadyToApply {get; set;}
    [SerializeField] LineRenderer _renderer;
    [SerializeField] float _scale;
    [SerializeField] float _distanceBetweenPoints;
    
    void Awake(){
        Reset();
    }
    public void SetPosition(Vector3 pos) {
        if(!CanAppend(pos)) return;
        
        Points.Add(pos/1.2f);
    
        _renderer.positionCount++;
        _renderer.SetPosition(_renderer.positionCount-1,pos*_scale);
 
    }
    public void Reset(){
        _renderer.positionCount = 0;
        Points = new List<Vector2>();
    }
    private bool CanAppend(Vector3 pos) {
        if (_renderer.positionCount == 0) return true;
 
        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > _distanceBetweenPoints;
    }
}
