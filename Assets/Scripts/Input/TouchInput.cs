using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public bool Began { get { return _began; } }
    public bool Hold { get { return _hold; } }
    public bool Ended { get { return _ended; } }
    
    public float Horizontal { get { return _movementDelta.x; } }
    public float Vertical { get { return _movementDelta.y; } }

    public Vector2 AxisRaw { get { return _movementDelta; } }

    //TODO change
    public Vector2 AxisNormalized{
        get{
            return new Vector2(_movementDelta.x/_maxThreshold.x -0.5f, _movementDelta.y/_maxThreshold.x -0.5f);
        }
    }

    private Rect _inputArea;

    private Vector2 _centerPosition, _maxThreshold, _screenSize, _movementDelta;

    private bool _began, _hold, _ended;

    #region Instance
    private static TouchInput _instance;
    public static TouchInput Instance
    {
        get{
            if (_instance == null){
                _instance = FindObjectOfType<TouchInput>();
                if (_instance == null){
                    _instance = new GameObject("Spawned TouchInput", typeof(TouchInput)).GetComponent<TouchInput>();
                }

            }
            return _instance;
        }
        set { _instance = value; }
    }
    #endregion
 
    void Awake(){
        _screenSize = new Vector2(Screen.width, Screen.height);
        _centerPosition = new Vector2( _screenSize.x*0.05f, _screenSize.y * 0.05f);
        _maxThreshold = new Vector2(_screenSize.x * 0.90f, _screenSize.y * 0.3f);
        _inputArea = new Rect(_centerPosition.x,_centerPosition.y, _maxThreshold.x,_maxThreshold.y);
        
    }

    private void Update(){
        _began = _ended = false;

#if UNITY_EDITOR
    UpdateStandalone();
#else
    UpdateMobile();
#endif

    }

    private void UpdateStandalone(){
        if (Input.GetMouseButtonDown(0))
            _began = _hold = true;
    
        else if (Input.GetMouseButtonUp(0)){
            _hold = false;
            _ended = true;
        }

        if(Input.GetMouseButton(0)) {
            if(_inputArea.Contains((Vector2)Input.mousePosition)){
                _movementDelta = (Vector2)Input.mousePosition - _centerPosition;
            }
        }
        
    }

    private void UpdateMobile(){
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
                _began = _hold = true;

            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {
                _hold = false;
                _ended = true;
            }
            
            if(_inputArea.Contains((Vector2)Input.mousePosition))
                _movementDelta = (Vector2)Input.mousePosition + _centerPosition;

        }
    }

}