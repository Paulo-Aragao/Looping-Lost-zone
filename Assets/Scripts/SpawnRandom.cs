using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacle_prefab;
    [SerializeField] private float _time_spawn = 5f;
    [SerializeField] private float _start_time_spawn = 5f;
    [SerializeField] private int _range_min = -5;
    [SerializeField] private int _range_max = 5;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnerItem",_start_time_spawn);
    }
    private void SpawnerItem(){
        Instantiate(_obstacle_prefab[Random.Range(0, _obstacle_prefab.Count)], new Vector3(Random.Range(_range_min, _range_min), 0,Random.Range(_range_min, _range_min)), Quaternion.Euler(-90, 0, 0));
        Invoke("SpawnerItem",_time_spawn);
    }
    
}
