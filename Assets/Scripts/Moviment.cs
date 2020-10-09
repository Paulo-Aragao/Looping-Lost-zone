using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    [SerializeField] private float _speed = 11.0f;
    [SerializeField] private AndroidInputs _android_input;
    private bool _turnRight;
    private bool _turnLeft;
    private float _rotation_val;
    private float _temp;
    private string _direction;
    private bool _input_delay_direction = false;
    private bool _input_delay_action = false;
    private Animator _anim;
    private PlayerController _player;

    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        _player = gameObject.GetComponent<PlayerController>();
    }
    void DelayChangeDirection(){
        GameController.Instance.ChangeDirection(_direction);
    }
    void DelayInputDirection(){
        _input_delay_direction = false;
    }
    void DelayInputAction(){
        _input_delay_action = false;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0,0,0);
        if(((Input.GetAxisRaw("Horizontal") > 0 && !_input_delay_direction))
                            ||(_android_input._direction_input == "right" && !_input_delay_direction)){
            _android_input._direction_input = "none";
            //_anim.SetTrigger("Right");
            _input_delay_direction = true;
            GameController.Instance.GetGround().SetSpeed(GameController.Instance.GetSpeed()/2);
            _turnLeft = true;
            _direction = "right";
            Invoke("DelayInputDirection",1.2f);
            Invoke("DelayChangeDirection",0.6f);
        }
        if(((Input.GetAxisRaw("Horizontal") < 0 && !_input_delay_direction))
                            ||(_android_input._direction_input == "left" && !_input_delay_direction)){
            _android_input._direction_input = "none";
            //_anim.SetTrigger("Left");
            _input_delay_direction = true;
            GameController.Instance.GetGround().SetSpeed(GameController.Instance.GetSpeed()/2);
            _turnRight = true;
            _direction = "left";
            Invoke("DelayInputDirection",1.2f);
            Invoke("DelayChangeDirection",0.6f);
        }
        if(((Input.GetAxisRaw("Vertical") > 0 && !_input_delay_action))
                            ||(_android_input._direction_input == "up" && !_input_delay_action)){
            _android_input._direction_input = "none";
            _player.Jump();
            _input_delay_action = true;
            Invoke("DelayInputAction",0.8f);
        }
        if(((Input.GetAxisRaw("Vertical") < 0 && !_input_delay_action))
                            ||(_android_input._direction_input == "down" && !_input_delay_action)){
            _android_input._direction_input = "none";
            _anim.SetTrigger("Slice");
            _player.Slice();
            _input_delay_action = true;
            Invoke("DelayInputAction",0.8f);
        }
    }
    void LateUpdate()
    { 
        if(_turnLeft)
        {
            if(_temp > 90){
                    _turnLeft = false;
                _temp = 0f;
            }
            else{
                    _rotation_val = Mathf.Lerp(0f,90f,Time.deltaTime);
                    transform .Rotate(new Vector3(0, _rotation_val, 0));
                    _temp += _rotation_val;
            }
            
        }
        else if(_turnRight)
        {
            if(_temp < -90){
                    _turnRight = false;
                _temp = 0f;
            }
            else{
                    _rotation_val = Mathf.Lerp(0f,-90f,Time.deltaTime);
                    transform .Rotate(new Vector3(0, _rotation_val, 0));
                    _temp += _rotation_val;
            }
            
        }
    }
}
