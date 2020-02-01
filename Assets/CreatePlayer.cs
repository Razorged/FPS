using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class CreatePlayer : NetworkBehaviour
{
    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer == false)
        {
            return;
        }
        Debug.Log("Spawning in...");
        CmdSpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Methods/Commands
    [Command]
    void CmdSpawnPlayer()
    {
        GameObject go = Instantiate(playerPrefab);
        NetworkServer.Spawn(go);
    }
}
