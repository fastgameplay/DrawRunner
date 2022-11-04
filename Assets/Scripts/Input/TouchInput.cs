using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public bool Began { get { return _began; } }
    public bool Hold { get { return _hold; } }
    
    public float Horizontal { get { return _movementDelta.x; } }
    public float Vertical { get { return _movementDelta.y; } }

    public Vector2 AxisRaw { get { return _movementDelta; } }

    //TODO change
    public Vector2 AxisNormalized{
        get{
            Vector2 tempDelta = ValidateDelta(_movementDelta,_maxThreshold);
            return new Vector2(tempDelta.x/_maxThreshold.x , tempDelta.y/_maxThreshold.y);
        }
    }

    private Rect _inputArea;

    private Vector2 _centerPosition, _maxThreshold, _screenSize, _movementDelta;

    private bool _began, _hold;

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
        _centerPosition = new Vector2( _screenSize.x*0.5f, _screenSize.y * 0.2f);
        _maxThreshold = new Vector2(_screenSize.x * 0.9f, _screenSize.y * 0.3f);

        
        
    }

    private void Update(){
        _began = false;
#if UNITY_EDITOR
    UpdateStandalone();
#else
    UpdateMobile();
#endif


    
    }

    private void UpdateStandalone(){
        if (Input.GetMouseButtonDown(0))
            _began = _hold = true;
    
        else if (Input.GetMouseButtonUp(0)) 
            _hold = false;

        if(Input.GetMouseButton(0)) 
            _movementDelta = (Vector2)Input.mousePosition - _centerPosition;
        
    }

    private void UpdateMobile(){
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
                _began = _hold = true;

            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {
                _hold = false;
            }

            _movementDelta = (Vector2)Input.mousePosition - _centerPosition;

        }
    }


    private Vector2 ValidateDelta(Vector2 movementDelta, Vector2 maxValue){
        if(movementDelta.x > maxValue.x) movementDelta.x = maxValue.x;
        else if(movementDelta.x < -maxValue.x) movementDelta.x = -maxValue.x;

        if(movementDelta.y > maxValue.y) movementDelta.y = maxValue.y;
        else if (movementDelta.y < -maxValue.y) movementDelta.y = -maxValue.y;

        return movementDelta;
    }
}