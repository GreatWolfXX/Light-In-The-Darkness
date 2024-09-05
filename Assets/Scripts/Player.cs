using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [HideInInspector] 
    public bool playerOnLight = true;
    [HideInInspector] 
    public bool playerTorchActive = true;
    
    private const int TimerMax = 10;
    private float _timer;
    private int _countTimer;
    
    public Light2D globalLight;

    public GameObject eyes;
    private List<GameObject> _listEyes;
    
    private AudioSource _wolfSound;
    private PlayerController2D _characterController2D;
    private UI _ui;

    void Awake()
    {
        _wolfSound = GetComponents<AudioSource>()[1];
        _characterController2D = GetComponent<PlayerController2D>();
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }

    private void Start()
    {
        _listEyes = new List<GameObject>();
    }

    void Update()
    {
        CheckInSaveZone();
        MenuPanel();
        InfoPanel();
    }

    private void CheckInSaveZone()
    {
        if (!playerOnLight && !playerTorchActive)
        {
            if (!_ui.isMenuPanelActive)
            {
                StartTimer();
            }
        }
        else
        {
            _countTimer = 0;
            _timer = 0f;
            globalLight.intensity = 0.01f;
            foreach (var eye in _listEyes)
            {
                Destroy(eye);
            }
        }

        if (playerOnLight && _wolfSound.isPlaying)
        {
            _wolfSound.Stop();
        }
    }
    
    private void StartTimer()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f && _countTimer < TimerMax)
        {
            var x = Random.Range(-2f, 2f);
            var y = Random.Range(1f, 2.5f);
            var position = transform.position;
            if (_countTimer > 4)
            {
                _listEyes.Add(Instantiate(eyes, new Vector3(position.x + x, position.y + y, 0), Quaternion.identity));   
            }
            _timer++;
            _countTimer++;
            globalLight.intensity -= 0.001f;
            
            if (!_wolfSound.isPlaying)
            {
                _wolfSound.Play();
            }
        }

        DeathPanel();
    }

    private void MenuPanel()
    {
        if (
            Input.GetKeyUp(KeyCode.Escape) &&
            !_ui.isInfoMenuPanelActive
        )
        {
            _ui.isMenuPanelActive = !_ui.isMenuPanelActive;
            _characterController2D.enabled = !_characterController2D.enabled;
            AudioListener.pause = _ui.isMenuPanelActive;
        }
        if (_ui.isPlayBtnMenuPanelActive)
        {
            _characterController2D.enabled = !_characterController2D.enabled;
            AudioListener.pause = _ui.isMenuPanelActive;
            _ui.isPlayBtnMenuPanelActive = false;
        }
    }

    private void InfoPanel()
    {
        if (_ui.isPlayBtnInfoMenuPanelActive)
        {
            _characterController2D.enabled = true;
            AudioListener.pause = false;
            _ui.isPlayBtnInfoMenuPanelActive = false;
        }

        if (_ui.isInfoMenuPanelActive)
        {
            _characterController2D.enabled = false;
            AudioListener.pause = true;
        }
    }
    
    private void DeathPanel()
    {
        if (_countTimer == TimerMax)
        {
            _characterController2D.enabled = false;
            _ui.isDeathPanelActive = true;
        }
    }
}