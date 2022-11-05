using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContainer : MonoBehaviour{

    [SerializeField] Player _playerPrefab;
    [SerializeField] Line _drawLine;

    List<Player> _players = new List<Player>();
    Vector2[] _points;

    private int _safeJumpSize{
        get{return _jumpSize;}
        set{
            if( value < 1) _jumpSize = 1;
            else _jumpSize = value;
        }
    }
    private int _jumpSize;

    void Update(){
        if(_drawLine.ReadyToApply){
            UpdatePoints();
            UpdatePlayerPositions();
            _drawLine.ReadyToApply = false;
        }
    }

    void UpdatePoints(){
        _points = _drawLine.Points.ToArray();
    }
    public void UpdatePoints(Vector2[] points){
        _points = points;
    }

    void UpdatePlayerPositions(){
        _safeJumpSize = _points.Length / _players.Count;

        for (int i = 0; i < _players.Count; i++){
            _players[i].MoveTo(_points[Random.Range(0,_points.Length)] );
        } 
    }

    public void AddPlayer(){
        Player player = Instantiate(_playerPrefab, transform.position, Quaternion.identity, transform);
        _players.Add(player);

        if(_points != null)
            UpdatePlayerPositions();
    }

    public void AddPlayer(int quantity){
        if(quantity < 1) return;

        for (int i = 0; i < quantity; i++){
            AddPlayer();
        }
    }
}
