using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 4.0f;
    public bool isGameActive = true;

    void Start()
    {
        StartCoroutine(SpawnTarget());
        isGameActive = true;
    }

    //spawn ogni 4 sec di crushball
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}



