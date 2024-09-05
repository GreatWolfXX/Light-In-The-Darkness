using System;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [HideInInspector] 
    public int woodScoreCount;
    [HideInInspector] 
    public int planksScoreCount;
    [HideInInspector] 
    public int appleScoreCount;
    [HideInInspector] 
    public int nailsScoreCount;
    [HideInInspector] 
    public int nailsFixedScoreCount;
    [HideInInspector] 
    public int axeScoreCount;
    [HideInInspector] 
    public int hammerScoreCount;
    
    public const int WoodScoreCountMax = 3;
    public const int PlanksScoreCountMax = 6;
    public const int AppleScoreCountMax = 3;
    public const int NailsScoreCountMax = 4;
    public const int NailsFixedScoreCountMax = 4;
    public const int AxeScoreCountMax = 1; 
    public const int HammerScoreCountMax = 1;
    
    public TextMeshProUGUI woodScore;
    public TextMeshProUGUI planksScore;
    public TextMeshProUGUI appleScore;
    public TextMeshProUGUI nailsScore;
    public TextMeshProUGUI nailsFixedScore;
    public TextMeshProUGUI axeScore;
    public TextMeshProUGUI hammerScore;

    [HideInInspector] 
    public bool isDeathPanelActive = false;
    [HideInInspector] 
    public bool isMenuPanelActive = false;
    [HideInInspector] 
    public bool isPlayBtnMenuPanelActive = false;
    [HideInInspector] 
    public bool isInfoMenuPanelActive = true;
    [HideInInspector] 
    public bool isPlayBtnInfoMenuPanelActive = false;
    public GameObject deathPanel;
    public GameObject menuPanel;
    public GameObject infoPanel;

    [HideInInspector] public bool isChangedUI = true;

    private void Start()
    {
        deathPanel.SetActive(false);
    }

    void Update()
    {
        if (isChangedUI)
        {
            woodScore.text = WoodScoreCountMax.ToString() + "/" + woodScoreCount.ToString();
            planksScore.text = PlanksScoreCountMax.ToString() + "/" + planksScoreCount.ToString();
            appleScore.text = AppleScoreCountMax.ToString() + "/" + appleScoreCount.ToString();
            nailsScore.text = NailsScoreCountMax.ToString() + "/" + nailsScoreCount.ToString();
            nailsFixedScore.text = NailsFixedScoreCountMax.ToString() + "/" + nailsFixedScoreCount.ToString();
            axeScore.text = AxeScoreCountMax.ToString() + "/" + axeScoreCount.ToString();
            hammerScore.text = HammerScoreCountMax.ToString() + "/" + hammerScoreCount.ToString();
            isChangedUI = false;
        }

        deathPanel.SetActive(isDeathPanelActive);

        menuPanel.SetActive(isMenuPanelActive);

        infoPanel.SetActive(isInfoMenuPanelActive);
    }
}