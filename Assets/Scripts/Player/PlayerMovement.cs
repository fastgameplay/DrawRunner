using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    [SerializeField] float _speed = 1f;

    Vector3 _targetPosition;
    bool isActive;

    void Update(){
       movement();
    }

    public void MoveTo(Vector2 pos){
        isActive = true;
        _targetPosition = new Vector3(pos.x, 0, pos.y);
    }

    private void movement(){
        if (Vector3.Distance(_targetPosition, transform.localPosition) > 0.01){
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _targetPosition, _speed * Time.deltaTime);
            return;
        }
        if(isActive == true){
            transform.localPosition = _targetPosition;
            isActive = false;
        }
    }
}
