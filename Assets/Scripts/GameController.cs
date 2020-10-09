using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private SliderGround _ground; 
   
    [SerializeField] private float _speed = 5.0f;

    private string _direction = "forward";
    private PlayerController _player;
    //singleton declaration
   
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameController>();
            }

            return _instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    public void SetSpeed(float speed){
        _speed = speed;
        _ground.SetSpeed(_speed);
    }
    public float GetSpeed(){
        return _speed;
    }
    public SliderGround GetGround(){
        return _ground;
    }
    public string GetDirection(){
        return _direction;
    }
    public PlayerController GetPlayer(){
        return _player;
    }
    public void ChangeDirection(string input_direction){
        if(_direction == "forward"){
            if(input_direction == "right"){
                _direction = "right";
            }else{
                _direction = "left";
            }
        }else if(_direction == "right"){
            if(input_direction == "right"){
                _direction = "backward";
            }else{
                _direction = "forward";
            }
        }else if(_direction == "left"){
            if(input_direction == "right"){
                _direction = "forward";
            }else{
                _direction = "backward";
            }
        }else if(_direction == "backward"){
            if(input_direction == "right"){
                _direction = "left";
            }else{
                _direction = "right";
            }
        }
        _ground.ChangeGroundDirection(_direction);
        _ground.SetSpeed(_speed);
        
    }
}
