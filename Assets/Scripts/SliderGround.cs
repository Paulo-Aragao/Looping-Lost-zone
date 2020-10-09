using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderGround : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    private float _X = 0f;
    private float _Y = -1f;
    private float _curX;
    private float _curY;
 
    public float GetSpeed(){
        return _speed;
    }
    public void SetSpeed(float speed){
        _speed = speed;
    }
    // Use this for initialization
    void Start () {
        _curX = GetComponent<Renderer>().material.mainTextureOffset.x;
        _curY = GetComponent<Renderer>().material.mainTextureOffset.y;
    }
    public void ChangeGroundDirection(string direction){
        if(direction == "right"){
            _X = -1f;
            _Y = 0f;
        }else if(direction == "left"){
            _X = 1f;
            _Y = 0f;
        }else if(direction == "forward"){
            _X = 0f;
            _Y = -1f;
        }else {
            _X = 0f;
            _Y = 1f;
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        _curX += Time.deltaTime * _X * _speed;
        _curY += Time.deltaTime * _Y * _speed;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(_curX, _curY));
    }
}
