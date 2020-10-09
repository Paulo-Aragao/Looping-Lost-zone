using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Collider _col_top;
    [SerializeField] private Collider _col_down;
    [SerializeField] private GameObject _part_power_fireworks;
    private bool _new_star = false;
    private bool _dive_is_possible = false;

    public bool GetNewStar(){
        return _new_star;
    }
    public void SetNewStar(bool new_star){
        _new_star = new_star;
    }
    public void Jump(){
        if(_dive_is_possible){
            _col_top.gameObject.SetActive(false);
            _col_down.gameObject.SetActive(false);
            gameObject.GetComponent<Animator>().SetTrigger("Dive");
            GameController.Instance.SetSpeed(0f);
        }else{
            gameObject.GetComponent<Animator>().SetTrigger("Jump");
            _col_down.gameObject.SetActive(false);
             Invoke("ResetColliders",0.8f);
        }
    }
    public void Slice(){
        _col_top.gameObject.SetActive(false);
        Invoke("ResetColliders",1.2f);
    }
    public void ResetColliders(){
         _col_top.gameObject.SetActive(true);
         _col_down.gameObject.SetActive(true);
    }
    public void Die(){
        UIController.Instance.GetArrowLeft().SetActive(false);
        UIController.Instance.GetArrowRight().SetActive(false);
        UIController.Instance.GetRestartButton().transform.parent.gameObject.SetActive(true);
        Destroy(GameObject.FindGameObjectWithTag("spawner"));
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("dive")){
            _dive_is_possible = true;
            other.gameObject.SetActive(false);
            Invoke("FinishTimeDive",0.2f);
        }
        if(other.CompareTag("obst_thunder"))
        {
            _col_top.gameObject.SetActive(false);
            _col_down.gameObject.SetActive(false);
            CallAnimation("Thunder");
            Die();
            gameObject.GetComponent<AudioSource>().Play();
        }else if(other.CompareTag("obst_leftOrRight")){
            _col_top.gameObject.SetActive(false);
            _col_down.gameObject.SetActive(false);
             gameObject.GetComponent<AudioSource>().Play();
             Die();
            CallAnimation("Fall");
        }else if(other.CompareTag("obst_hole")){
            _col_top.gameObject.SetActive(false);
            _col_down.gameObject.SetActive(false);
             gameObject.GetComponent<AudioSource>().Play();
             Die();
            CallAnimation("FallDown");
        }else if(other.CompareTag("powerup")){
            _new_star = true;
            _part_power_fireworks.gameObject.SetActive(true);
            UIController.Instance.SetPoints(1);
            Destroy(other.gameObject);
            Invoke("FinishFireWork",0.5f);
        }
    }
    private void FinishFireWork(){
         _part_power_fireworks.gameObject.SetActive(false);
    }
    private void FinishTimeDive(){
        _dive_is_possible = false;
    }
    public void CallAnimation(string anim_name){
        gameObject.GetComponent<Animator>().SetTrigger(anim_name);
        GameController.Instance.SetSpeed(0);
        GameController.Instance.GetGround().SetSpeed(GameController.Instance.GetSpeed());
        _col_top.gameObject.SetActive(false);
        _col_down.gameObject.SetActive(false);
    }
}
