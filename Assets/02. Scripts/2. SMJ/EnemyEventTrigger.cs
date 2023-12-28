using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

public class EnemyEventTrigger : MonoBehaviour
{
    [SerializeField] GameObject enemyObject;
    [SerializeField] List<GameObject> clueHintObjList;

    [HideInInspector]public List<String> isChecked = new List<String>();

    [SerializeField] AudioSource audioSource;
    [SerializeField] List<AudioClip> eventAudios;
    [SerializeField] Light playerFlashlight;
    [HideInInspector] bool[] isRun = new bool[11];

    int collectionStatus = 0;
    public int CollectionStatus
    {
        get { return collectionStatus; }
        set { collectionStatus = value; }
    }

    private void Update()
    {
        Ray playerLook = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit rayHit;
        if (Physics.Raycast(playerLook, out rayHit, 1.5f, LayerMask.GetMask("Clue")))
        {
            if (!isChecked.Contains(rayHit.collider.gameObject.name))
            {
                Debug.Log(rayHit.collider.gameObject.name + ", " + collectionStatus);
                isChecked.Add(rayHit.collider.gameObject.name);
                collectionStatus++;
                ActiveClueHint(int.Parse(rayHit.collider.gameObject.name));
            }
        }

        if (collectionStatus == 3 && !isRun[0])
        {
            audioSource.PlayOneShot(eventAudios[0], 0.8f);
            isRun[0] = true;
        }
        else if (collectionStatus == 5 && !isRun[1])
        {
            audioSource.PlayOneShot(eventAudios[1], 0.6f);
            isRun[1] = true;
        }
        else if (collectionStatus == 7 && !isRun[2])
        {
            LightBlinkEvent();
            isRun[2] = true;
        }
        else if (collectionStatus == 9 && !isRun[3])
        {
            audioSource.PlayOneShot(eventAudios[2], 0.8f);
            isRun[3] = true;
        }
        else if (collectionStatus == 11 && !isRun[4])
        {
            audioSource.PlayOneShot(eventAudios[3], 0.8f);
            isRun[4] = true;
        }
        else if (collectionStatus == 13 && !isRun[5])
        {
            audioSource.PlayOneShot(eventAudios[4], 0.8f);
            isRun[5] = true;
        }
        else if (collectionStatus == 15 && !isRun[6])
        {
            LightBlinkEvent();
            isRun[6] = true;
        }
        else if (collectionStatus == 17 && !isRun[7])
        {
            audioSource.PlayOneShot(eventAudios[5], 0.8f);
            isRun[7] = true;
        }
        else if (collectionStatus == 20 && !isRun[8])
        {
            audioSource.PlayOneShot(eventAudios[6], 0.8f);
            isRun[8] = true;
        }
        else if (collectionStatus == 22 && !isRun[9])
        {
            audioSource.PlayOneShot(eventAudios[7], 0.8f);
            isRun[9] = true;
        }
        else if (collectionStatus == 23 && !isRun[10])
        {
            ActiveEnemy();
            isRun[10] = true;
        }
    }

    private void LightBlinkEvent()
    {
        if(playerFlashlight.enabled)
        {
            playerFlashlight.enabled = false;
            StartCoroutine(BlinkDelay(0.2f));
            playerFlashlight.enabled = true;
            StartCoroutine(BlinkDelay(1f));
            playerFlashlight.enabled = false;
            StartCoroutine(BlinkDelay(0.4f));
            playerFlashlight.enabled = true;
            StartCoroutine(BlinkDelay(1f));
            playerFlashlight.enabled = false;
            StartCoroutine(BlinkDelay(0.3f));
            playerFlashlight.enabled = true;
            StartCoroutine(BlinkDelay(1f));
            playerFlashlight.enabled = false;
            StartCoroutine(BlinkDelay(0.5f));
            playerFlashlight.enabled = true;
            StartCoroutine(BlinkDelay(1f));
            playerFlashlight.enabled = false;
            StartCoroutine(BlinkDelay(3f));
            playerFlashlight.enabled = true;
        }
    }
    IEnumerator BlinkDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
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
