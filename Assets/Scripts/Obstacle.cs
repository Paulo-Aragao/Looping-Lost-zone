using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 _destiny;
    private string _direction_player = "forward";
    [SerializeField] private string _type = "default";
    public void SetDestiny(Vector3 destiny){
        _destiny = destiny;
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,5f);
        _destiny = new Vector3(0,0,0);
        if(GameController.Instance.GetDirection() == "forward"){
            _direction_player = "forward";
            _destiny = new Vector3(transform.position.x,transform.position.y,(-100)*transform.position.z);
        }else if(GameController.Instance.GetDirection() == "right"){
            _direction_player = "right";
            _destiny = new Vector3((-100)*transform.position.x,transform.position.y,transform.position.z);
        }else if(GameController.Instance.GetDirection() == "left"){
            _direction_player = "left";
            _destiny = new Vector3((-100)*transform.position.x,transform.position.y,transform.position.z);
        }else if(GameController.Instance.GetDirection() == "backward"){
            _direction_player = "backward";
            _destiny = new Vector3(transform.position.x,transform.position.y,(-100)*transform.position.z);
        }
        if(_type == "left"){
            UIController.Instance.GetArrowLeft().SetActive(true);
        }else if(_type == "right"){
            UIController.Instance.GetArrowRight().SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float step = 4f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _destiny, step);
        if(_direction_player != GameController.Instance.GetDirection()){
            ChangeDirection();
        }
        if(_type == "right" && Input.anyKeyDown){
            if(Input.GetKeyDown(KeyCode.D)){
                Destroy(gameObject,0.1f);
            }else if(Input.GetKeyDown(KeyCode.A)){
                GameController.Instance.GetPlayer().CallAnimation("Error");
                GameController.Instance.GetPlayer().Die();
            }
            UIController.Instance.GetArrowRight().SetActive(false);
        }else if(_type == "left" && Input.anyKeyDown){
            if(Input.GetKeyDown(KeyCode.A)){
                Destroy(gameObject,0.1f);
            }else if(Input.GetKeyDown(KeyCode.D)){
                GameController.Instance.GetPlayer().CallAnimation("Error");
                GameController.Instance.GetPlayer().Die();
            }
            UIController.Instance.GetArrowLeft().SetActive(false);
        }
    }
    private void ChangeDirection(){
        if(GameController.Instance.GetDirection() == "forward"){
            _direction_player = "forward";
            _destiny = new Vector3(transform.position.x,transform.position.y,-100);
        }else if(GameController.Instance.GetDirection() == "right"){
            _direction_player = "right";
            _destiny = new Vector3(-100,transform.position.y,transform.position.z);
        }else if(GameController.Instance.GetDirection() == "left"){
            _direction_player = "left";
            _destiny = new Vector3(100,transform.position.y,transform.position.z);
        }else if(GameController.Instance.GetDirection() == "backward"){
            _direction_player = "backward";
            _destiny = new Vector3(transform.position.x,transform.position.y,100);
        }
    }
}
