using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{

    public GameObject MenuUI;
    public LightingManager DayNight;
    public Camera menuCam;
    public Camera playerCam;
    public GameObject volcanoRock;
    Vector3 rockStartPos;
    bool launchedRock = false;
    public Transform destination;

    public GameObject Environment;
    public GameObject DamagedEnvironment;

    public GameObject HighSmoke;
    public GameObject LowSmoke;

    bool crashed = false;
    float crashTime;

    enum GameMode
    {
        MainMenu,
        Gameplay
    }

    GameMode gameMode = GameMode.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        StartMainMenu();
        rockStartPos = volcanoRock.transform.position;
        volcanoRock.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameMode)
        {
            case GameMode.MainMenu:
                UpdateMainMenu();
                break;
            case GameMode.Gameplay:
                UpdateGameplay();
                break;
        }
    }

    void UpdateMainMenu()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartGameplay();
        }
    }

    void UpdateGameplay()
    {
        if (crashed)
        {
            crashTime += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.L))
        {
            volcanoRock.SetActive(true);
            volcanoRock.transform.position = rockStartPos;
            volcanoRock.GetComponent<ParabolaController>().FollowParabola();
            launchedRock = true;
        }
        if (volcanoRock.transform.position.z > 800)
        {
            volcanoRock.SetActive(false);
            Environment.SetActive(false);
            DamagedEnvironment.SetActive(true);
            crashed = true;
        }
        if (crashTime > 3)
        {
            HighSmoke.SetActive(false);
            LowSmoke.SetActive(true);
        }
    }

    void StartMainMenu()
    {
        gameMode                        = GameMode.MainMenu;
        MenuUI.gameObject.SetActive(true);
        playerCam.enabled = false;
        menuCam.enabled = true;
        DayNight.TimeOfDay = 2f;
    }

    void StartGameplay()
    {
        gameMode                        = GameMode.Gameplay;
        MenuUI.gameObject.SetActive(false);
        playerCam.enabled = true;
        menuCam.enabled = false;
        DayNight.TimeMultiplier = 0.5f;
    }

}
