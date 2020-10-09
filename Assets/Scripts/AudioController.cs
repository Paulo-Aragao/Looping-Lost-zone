using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _prefabs_audio;

    [SerializeField] private AudioSource _audio_source;
    private AudioSource _audio_source_sec;
    // Start is called before the first frame update
    void Start()
    {
        _audio_source = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();
        _audio_source.loop = false;
        //ADDNewAuido();
    }
    private void Update() {
        if(!_audio_source.isPlaying){
            _audio_source.Play();
            if(GameController.Instance.GetPlayer().GetNewStar()){
                ADDNewAuido();
                GameController.Instance.GetPlayer().SetNewStar(false);
            }
            
        }
    }
    public void ADDNewAuido(){
        int id_sound = Random.Range(5, 14);
        AudioClip clip = Resources.Load("sounds/loops/"+id_sound.ToString()) as AudioClip;
        _audio_source_sec = Instantiate(_prefabs_audio);
        _audio_source_sec.Stop();
        _audio_source_sec.transform.SetParent(transform);
        _audio_source_sec.clip = clip;
        _audio_source_sec.volume = 0.48f;
        _audio_source_sec.Play();
    }
}
