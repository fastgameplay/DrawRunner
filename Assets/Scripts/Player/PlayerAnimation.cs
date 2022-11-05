using UnityEngine;

public class PlayerAnimation : MonoBehaviour{
    [SerializeField] Animator _animator;



    public void Idle(){
        _animator.Play("Idle");
    }
    
    public void Run(){
        _animator.Play("Running");
    }
    
    public void Win(){
        _animator.Play("VictoryIdle");
    }
}
