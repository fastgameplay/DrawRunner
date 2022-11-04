using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LineDrawer : MonoBehaviour{
    private Camera _cam;
    [SerializeField] Line _linePrefab;
    
    Line _currentLine;

    void Awake(){
        _cam = Camera.main;
    }
 
 
    void Update() {
        Vector3 pos = GetMousePosition();

        if (Input.GetMouseButtonDown(0)) _currentLine = Instantiate(_linePrefab, transform.position, Quaternion.identity,transform);

        if(Input.GetMouseButton(0)) _currentLine.SetPosition(pos);
    }


    private Vector3 GetMousePosition(){
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        return ray.origin + ray.direction;
    }

}
