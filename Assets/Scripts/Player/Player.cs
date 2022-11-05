using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerCollision))]
[RequireComponent(typeof(PlayerAnimation))]

public class Player : MonoBehaviour{
    public PlayerContainer Container {get; private set;}
    public PlayerAnimation Anim {get; private set;}
    PlayerMovement _movement;

    void Awake(){
        _movement = GetComponent<PlayerMovement>();
        Anim = GetComponent<PlayerAnimation>();
    }

    public void SetContainer(PlayerContainer container){
        Container = container;
    }

    public void MoveTo(Vector2 movement){
        Anim.Run();
        _movement.MoveTo(movement);
    }

    public void WinDance(){
        Anim.Win();
    }


}
