using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BonneteauManager : MonoBehaviour
{
    
    private Vector2 mousePos;
    public bool IsClicked = false;
    [SerializeField] private LayerMask movableLayers;

    [SerializeField] private Vector3[] cupBasePos = new Vector3[3];
    
    public GameObject[] arrayOfCups;
    private bool isShuffling = true;

    private bool asWin = false;
    void Start()
    {
        for (int i = 0; i < cupBasePos.Length; i++)
        {
            cupBasePos[i] = arrayOfCups[i].transform.position;
        }
        GenerateCupPosition();
        StartCoroutine(TimerForCupPosition());
    }

    private void Update()
    {
        if (!isShuffling && !asWin)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButton(0))
            {

                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, float.PositiveInfinity, movableLayers);

                if (hit)
                {
                    IsClicked = true;
                    Debug.Log("Win");
                    asWin = true;
                }
            }
            else
            {
                IsClicked = false;
            }
        }
        
    }

    public void GenerateCupPosition()
    {
        for (int i = 0; i < arrayOfCups.Length; i++)
        {
            GameObject tmp = arrayOfCups[i];
            int randomizeIdOfPos = Random.Range(0, arrayOfCups.Length);
            arrayOfCups[i] = arrayOfCups[randomizeIdOfPos];
            arrayOfCups[randomizeIdOfPos] = tmp;
        }
        Debug.Log("Generated");
    }

    public void UpdateCupPos()
    {
        for (int i = 0; i < arrayOfCups.Length; i++)
        {
            arrayOfCups[i].transform.position = cupBasePos[i];
        }
    }

    private IEnumerator TimerForCupPosition()
    {
        int count = 0;
        while (isShuffling)
        {
            yield return new WaitForSeconds(0.7f);
            GenerateCupPosition();
            UpdateCupPos();
            count += 1;
            if (count == 5) isShuffling = false;
        }
        yield return null;
    }
}
