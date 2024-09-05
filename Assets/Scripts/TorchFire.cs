using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TorchFire : MonoBehaviour
{
    public Light2D lightTorch;
    public ParticleSystem glowTorchParticleSystem;
    public ParticleSystem fireTorchParticleSystem;
    public float lightPowerMax = 3f;
    public float fireSizeMax = 0.7f;
    private float _lightPower;
    private const float LightPowerStep = 0.05f;
    private float _fireSizeStep;
    private float _timer = 1f;

    private Player _player;

    private UI _ui;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }

    void Start()
    {
        var particleMainFire = fireTorchParticleSystem.main;
        lightTorch.intensity = lightPowerMax;
        _lightPower = lightTorch.intensity;
        particleMainFire.startSize = fireSizeMax;
        _fireSizeStep = fireSizeMax / (lightPowerMax / LightPowerStep);
    }
    
    void Update()
    {
        if (!_ui.isMenuPanelActive && !_ui.isInfoMenuPanelActive)
        {
            TorchTimer();
        }
    }

    private void TorchTimer()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0f && _lightPower > 0f)
        {
            var particleMainGlow = glowTorchParticleSystem.main;
            var particleMainFire = fireTorchParticleSystem.main;

            _timer += 1f;
            
            _lightPower = lightTorch.intensity - LightPowerStep;
            
            lightTorch.intensity = _lightPower;
            
            particleMainGlow.startSize = _lightPower;
            particleMainFire.startSize = particleMainFire.startSize.constant - _fireSizeStep;
        }

        if (_lightPower < 0f)
        {
            lightTorch.intensity = 0f;
            _player.playerTorchActive = false;
        }
    }

    public void ResetTorch()
    {
        var particleMainFire = fireTorchParticleSystem.main;
        lightTorch.intensity = lightPowerMax;
        _lightPower = lightTorch.intensity;
        particleMainFire.startSize = fireSizeMax;
        _player.playerTorchActive = true;
    }
}