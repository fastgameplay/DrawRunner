using UnityEngine;
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerCollision : MonoBehaviour{
    
    Player _player;
    void Awake(){
        _player = GetComponent<Player>();
        
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "PickUpPlayer"){
            _player.Container.AddPlayer();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Enemy"){
            Destroy(gameObject);
        }

    }
}
