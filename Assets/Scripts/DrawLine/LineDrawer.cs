using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LineDrawer : MonoBehaviour{
    private Camera _cam;

    [SerializeField] Line _line;
    [SerializeField] Vector3 _offset;

    Line _currentLine;

    TouchInput input;
    private float _horizontalInput {get {return input.AxisNormalized.x;} }
    private float _verticalInput {get {return input.AxisNormalized.y;} }
    void Awake(){
        input = TouchInput.Instance;
        _line.transform.localPosition = _offset;
    }
 
 
    void Update() {

        if (input.Began) _line.Reset();
        if (input.Hold) _line.SetPosition(new Vector3 (_horizontalInput,_verticalInput,0));
        if(input.Ended) _line.ReadyToApply = true;
    }


}
