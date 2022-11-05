using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerContainer))]
public class PlayerSpawner : MonoBehaviour{
    [SerializeField] Vector2Int _startSize;

    PlayerContainer _playerContainer;
    Vector2[] _initialPositions;
    
    void Awake(){
        _playerContainer = GetComponent<PlayerContainer>();
    }
    void Start(){
        _initialPositions = new Vector2[_startSize.y * _startSize.x];
        int i = 0;
        for (int y = 0; y < _startSize.y; y ++){
            for (int x = 0; x < _startSize.x; x ++){
                _initialPositions[i] = new Vector2(x-0.5f, y)/10;
                i++;
            }
        }
            Debug.Log(_initialPositions);
        _playerContainer.UpdatePoints(_initialPositions);
        _playerContainer.AddPlayer( _initialPositions.Length);
    }
}
