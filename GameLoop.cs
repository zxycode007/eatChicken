﻿using UnityEngine;
using System.Collections;
using System;


public class GameLoop : MonoBehaviour
{

    private  GlobalClient globalClient;
    private GameStateController m_stateController;

    void Awake()
    {
        GameObject.DontDestroyOnLoad(this);

        UnityEngine.Random.seed = (int)DateTime.Now.Ticks;
        globalClient = new GlobalClient();
        GlobalClient.Instance.Initialze();
        GameStateController m_stateController = GlobalClient.Instance.gameStateController;
    }

    // Use this for initialization
    void Start()
    {
        m_stateController.SwitchGameState(EGAME_STATE_TYPE.EGAME_STATE_BASE);
    }

    // Update is called once per frame
    void Update()
    {
        m_stateController.UpdateGameState();
    }


}
