using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.Connection;

public class LevelMenu : NetworkBehaviour
{
    public static int playercount = 0;
    private Vector3 spawnp = new Vector3(40, -30, 0);
    public void Host()
    {
        NetworkManager.Singleton.StartHost(spawnp);
        gameObject.SetActive(false);
        
    }
    public void Client()
    {
        //playercount += 1;
        NetworkManager.Singleton.StartClient();
        gameObject.SetActive(false);

    }

}
