using UnityEngine;
using Cinemachine;
using System;

public class PlayerSpawner : MonoBehaviour
{
    [Header("Dependencies")]
    public PlayerPathSO playerPath;
    public GameObject playerPrefab;
    public CinemachineVirtualCamera followCamera;
    public GameObject playerParent;

    public void InstantiatePlayerOnLevel()
    {
        GameObject player = GetPlayer();
        Transform entrance = GetLevelEntrance(playerPath.levelEntrance);

        player.transform.position = entrance.transform.position;
        player.transform.parent = playerParent.transform;
        followCamera.Follow = player.transform;

        //when player is instantiated and moved, reset the path
        playerPath.levelEntrance = null;
    }

    private GameObject GetPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject == null)
            playerObject = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        return playerObject;
    }
    private Transform GetLevelEntrance(LevelEntranceSO playerEntrance)
    {
        if(playerEntrance == null)
        {
            // Np path for player, Instantiate it at default position
            return transform.GetChild(0).transform;
        }
        var levelEntrances = FindObjectsOfType<LevelEntrance>();

        foreach (LevelEntrance levelEntrance in levelEntrances)
        {
            if (levelEntrance.entrance == playerEntrance)
                return levelEntrance.gameObject.transform;
        }

        return transform.GetChild(0).transform;
    }

}
