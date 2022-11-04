using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LineDrawer : MonoBehaviour{
    private Camera _cam;
    [SerializeField] private Line _linePrefab;
    [SerializeField] private RectTransform _field;
 
    public const float RESOLUTION = .1f;
 
    private Line _currentLine;
    void Start()
    {
         _cam = Camera.main;   
    }
 
 
    void Update() {
        Vector2 pos = _cam.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(pos + " : " + Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) _currentLine = Instantiate(_linePrefab, transform.position, Quaternion.identity,transform);
 
        if(Input.GetMouseButton(0)) _currentLine.SetPosition(pos);
    }

}
