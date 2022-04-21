using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform spawnPoint;
    //IsArmed?
    [SerializeField] public GameObject Player;
    private MovementController playerMovement;
    //the health ui?
    private GameObject HealthUi;


    public void Start()
    {
        
    }

    public void Setup()
    {
        //Set Player spawnPoint
        PlayerCreation();
        if(Player)
            playerMovement = Player.GetComponent<PlayerMovement>();
        //HealthUi = Player.GetComponentInChildren<Canvas>().gameObject;
    }

    public void DisableControl()
    {
        //playerMovement.enabled = false;
        //disable the ui
        //HealthUi.SetActive(false);
    }

    public void EnableControl()
    {
        playerMovement.enabled = true;
        //enable the ui
        HealthUi.SetActive(true);

    }

    public void Replace()
    {
        //reset spawn point ect  
    }

    public GameObject getPlayer()
    {
        return Player;
    }

    public void PlayerCreation()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if(Player)
            DontDestroyOnLoad(Player);
    }

    //Soit param soit find
    public void ReAffectPlayer()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            if (player == Player) continue;
            //Don't forget to destroy the GameObject scripts
            //Destroy(Player.GetComponent<PlayerMovement>());
            Destroy(Player);
            Player = player;
            DontDestroyOnLoad(player);
            break;
        }
        
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        Player.transform.position = spawnPoint.position;
    }
    
    

    public void DestroyPlayer()
    {
        GameObject obj = GameObject.Find(Player.name);
        
        Destroy(Player);
        Player = null;
    }
}
