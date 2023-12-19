using System.Collections.Generic;
using System;
using UnityEngine;
using HFPS.Systems;
using System.Collections;

public class EnemyEventTrigger : MonoBehaviour
{
    public static EnemyEventTrigger Instance;

    [SerializeField] GameObject enemyObject;
    [SerializeField] List<GameObject> clueHintObjList;

    [HideInInspector]public List<String> isChecked = new List<String>();
    int collectionStatus = 0;
    public int CollectionStatus
    {
        get { return collectionStatus; }
        set { collectionStatus = value; }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (collectionStatus == 10)
            ActiveEnemy();
    }

    public void ActiveEnemy()
    {
        enemyObject.SetActive(true);
    }

    public void ActiveClueHint(int num)
    {
        clueHintObjList[num-1].SetActive(true);
    }
}
