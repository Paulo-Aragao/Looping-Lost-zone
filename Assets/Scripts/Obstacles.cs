using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacle_prefab;
    [SerializeField] private float _time_spawn = 5f;
    [SerializeField] private float _start_time_spawn = 5f;
    [SerializeField] private int _range_min = 6;
    [SerializeField] private int _range_max = 12;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("InstantiateObstacle",_start_time_spawn);
    }
    private void InstantiateObstacle(){
        int X = 0,Z = 0;
        if(GameController.Instance.GetDirection() == "forward"){
            X = 0;
            Z = 1;
        }else if(GameController.Instance.GetDirection() == "right"){
            X = 1;
            Z = 0;
        }else if(GameController.Instance.GetDirection() == "left"){
            X = -1;
            Z = 0;        
        }else if(GameController.Instance.GetDirection() == "backward"){
            X = 0;
            Z = -1;
        }
        Instantiate(_obstacle_prefab[Random.Range(0, _obstacle_prefab.Count)], new Vector3(Random.Range(_range_min, _range_min)*X, 0,Random.Range(_range_min, _range_min)*Z), Quaternion.Euler(-90, 0, 0));
        Invoke("InstantiateObstacle",_time_spawn);
    }
}
