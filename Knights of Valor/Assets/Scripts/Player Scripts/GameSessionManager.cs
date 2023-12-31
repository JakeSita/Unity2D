using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class GameSessionManager : MonoBehaviour
    {
        public Transform CurrentRespawn;

        public GameObject gameOverUI;
        public GameObject Player;
        Transform player1;
        //PlayerMovement move;


    private void Start()
    {
        Player = GameObject.Find("Player");
        player1 = Player.GetComponent<Transform>();
        //move = Player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (CurrentRespawn)
                player1.position = CurrentRespawn.position;
            else
                player1.position = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }


    public void ExitGame()
        {
            RespawnScreen(false);
            Application.Quit();
        }

        public void Respawn()
        {
        Transform playerPos = Player.GetComponent<Transform>();
        HealthSystem playerHealth = Player.GetComponent<HealthSystem>();
        Player.GetComponent<PlayerMovement>().UnlockMovement();
        playerPos.position = CurrentRespawn.position;
        playerHealth.Reset();
            RespawnScreen(false);
        }

        public void RespawnScreen(bool screen) {

            gameOverUI.SetActive(screen);
        }



        public Transform GetActiveRespawn()
        {
            return CurrentRespawn;
        }


        public void setActiveRespawn(Transform respawn) { 
            CurrentRespawn = respawn;
            Debug.Log("Active Respawn Point " + CurrentRespawn);
        }

    }
