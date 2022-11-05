using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour{
    PlayerContainer _container;
    PlayerMovement _movement;


    void Awake(){
        _movement = GetComponent<PlayerMovement>();
    }

    public void SetContainer(PlayerContainer container){
        _container = container;
    }

    public void MoveTo(Vector2 movement){
        _movement.MoveTo(movement);
    }
}
