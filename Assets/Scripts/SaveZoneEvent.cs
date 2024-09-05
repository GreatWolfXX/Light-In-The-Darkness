using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SaveZoneEvent : MonoBehaviour
{
    private bool _isOnTrigger;
    [HideInInspector]
    public bool isActiveSaveZone ;
    
    private AudioSource _soundReset;
    private AudioSource _soundActivate;
    
    public SpriteRenderer lightSprite;
    public Sprite activeSaveZone;
    public Sprite noActiveSaveZone;
    
    private TorchFire _torchFire;
    private Player _player;

    private const int TimerMax = 30;
    private float _timer;
    private int _countTimer;
    
    private Light2D _lightSaveZone;
    public float lightIntensityMax = 3f;
    private float _lightIntensityStep;

    private void Awake()
    {
        _soundReset = GetComponents<AudioSource>()[0];
        _soundActivate = GetComponents<AudioSource>()[1];

        _torchFire =  GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<TorchFire>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _lightSaveZone = GetComponentInChildren<Light2D>();
    }

    void Start()
    {
        lightSprite.sprite = noActiveSaveZone;
        
        _lightSaveZone.intensity = lightIntensityMax;
        _lightSaveZone.enabled = false;
        _lightIntensityStep = lightIntensityMax / TimerMax;
    }
    
    void Update()
    {
        if (
            Input.GetKeyUp(KeyCode.E) && 
            _isOnTrigger && 
            !_soundReset.isPlaying &&
            isActiveSaveZone
        )
        {
            _soundReset.Play();
            _torchFire.ResetTorch();
        }
        
        if (
            Input.GetKeyUp(KeyCode.E) && 
            _isOnTrigger && 
            !_soundActivate.isPlaying &&
            !isActiveSaveZone &&
            _player.playerTorchActive
        )
        {
            _soundActivate.Play();
            isActiveSaveZone = true;
            _countTimer = 0;
            _timer = 0f;
            _lightSaveZone.intensity = lightIntensityMax;
            _lightSaveZone.enabled = true;
            lightSprite.sprite = activeSaveZone;
        }

        if (isActiveSaveZone)
        {
            StartTimer();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isOnTrigger = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isOnTrigger = false;
        }
    }
    
    private void StartTimer()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f && _countTimer < TimerMax)
        {
            _timer++;
            _countTimer++;
            _lightSaveZone.intensity -= _lightIntensityStep;
        }
        
        if (_countTimer == TimerMax)
        {
            isActiveSaveZone = false;
            lightSprite.sprite = noActiveSaveZone;
            _lightSaveZone.enabled = false;
        }
    }
}