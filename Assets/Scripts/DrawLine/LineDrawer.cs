using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LineDrawer : MonoBehaviour{
    private Camera _cam;

    [SerializeField] Line _line;
    [SerializeField] Vector3 _offset;
    [SerializeField] float _scale;

    Line _currentLine;

    TouchInput input;
    private float _horizontalInput {get {return input.AxisNormalized.x * _scale;}}
    private float _verticalInput {get {return input.AxisNormalized.y * _scale;}}
    void Awake(){
        input = TouchInput.Instance;
        _line.transform.localPosition = _offset;
    }
 
 
    void Update() {

        if (input.Began) _line.Reset();
        if(input.Hold) _line.SetPosition(new Vector3 (_horizontalInput,_verticalInput,0));
    }


}
