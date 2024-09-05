using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnZone : MonoBehaviour
{
    public GameObject wood;
    public GameObject anvil;
    public GameObject stump;
    public GameObject stall;
    public GameObject nails;
    public GameObject axe;
    public GameObject hammer;
    private List<GameObject> _woodSpawnZones;
    private List<GameObject> _anvilSpawnZones;
    private List<GameObject> _stumpSpawnZones;
    private List<GameObject> _stallSpawnZones;
    private List<GameObject> _nailsSpawnZones;
    private List<GameObject> _axeSpawnZones;
    private List<GameObject> _hammerSpawnZones;

    private void Awake()
    {
        _woodSpawnZones = GameObject.FindGameObjectsWithTag("Wood Spawn Zone").ToList();
        _anvilSpawnZones = GameObject.FindGameObjectsWithTag("Anvil Spawn Zone").ToList();
        _stumpSpawnZones = GameObject.FindGameObjectsWithTag("Stump Spawn Zone").ToList();
        _stallSpawnZones = GameObject.FindGameObjectsWithTag("Stall Spawn Zone").ToList();
        _nailsSpawnZones = GameObject.FindGameObjectsWithTag("Nails Spawn Zone").ToList();
        _axeSpawnZones = GameObject.FindGameObjectsWithTag("Axe Spawn Zone").ToList();
        _hammerSpawnZones = GameObject.FindGameObjectsWithTag("Hammer Spawn Zone").ToList();
    }

    void Start()
    {
        Spawn(wood, _woodSpawnZones);
        Spawn(anvil, _anvilSpawnZones);
        Spawn(stump, _stumpSpawnZones);
        Spawn(stall, _stallSpawnZones);
        Spawn(nails, _nailsSpawnZones);
        Spawn(axe, _axeSpawnZones);
        Spawn(hammer, _hammerSpawnZones);
    }

    void Spawn(GameObject element, List<GameObject> listSpawnZones)
    {
        var spawnZonesSize = listSpawnZones.Count;
        var spawnZonePosition = listSpawnZones[Random.Range(0, spawnZonesSize)].transform.position;
        Instantiate(element, spawnZonePosition, Quaternion.identity);
    }
}