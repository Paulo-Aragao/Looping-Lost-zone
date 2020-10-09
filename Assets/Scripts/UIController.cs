using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{
   [SerializeField] private GameObject _arrow_left;
   [SerializeField] private GameObject _arrow_right;
   [SerializeField] private TextMeshProUGUI _points;
   [SerializeField] private TextMeshProUGUI _credits;
   [SerializeField] private GameObject _restart_button;
   [SerializeField] private GameObject _spawners_prefab;
   private int _pointsInt = 0;

    public GameObject GetRestartButton(){
        return _restart_button;
    }
    public GameObject GetArrowLeft(){
        return _arrow_left;
    }
    public GameObject GetArrowRight(){
        return _arrow_right;
    }
    public void SetPoints(int points){
        _pointsInt += points;
        _points.text = _pointsInt.ToString();
    }
    public TextMeshProUGUI GetPoints(){
        return _points;
    }

    private static UIController _instance;
    public static UIController Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<UIController>();
            }

            return _instance;
        }
    }
    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        _points.text = _pointsInt.ToString();
    }
    private float _opacity = 1f;
    void Update()
    {
        _opacity -= 0.003f;
        _credits.color = new Color(255,255,255,_opacity);
    }
    public void Restart(){
        GameController.Instance.SetSpeed(5f);
        //GameController.Instance.GetPlayer().gameObject.GetComponent<Animator>().SetTrigger("Restart");
        Instantiate(_spawners_prefab);
        _restart_button.transform.parent.gameObject.SetActive(false);
        _pointsInt = 0;
        SetPoints(0);
    }
    public void ReturnMenu(){
        Application.Quit();
    }
}
