using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ImageMalusManager : MonoBehaviour
{

    [SerializeField] private GameObject parentOfGlasses;
    [SerializeField] private Transform[] arrayOfGlasses;

    [SerializeField] private Transform[] arrayOfSelectedSpot;

    private Transform currentGlassTransform;
    
    private Vector2 mousePos;
    public bool IsDraged = false;
    [SerializeField] private LayerMask movableLayers;
    
    public static ImageMalusManager ImageMalusManagerInstance;

    private bool asWin;
    
    
    void Awake()
    {
        if (ImageMalusManagerInstance == null)
        {
            ImageMalusManagerInstance = this;
        }
    }
    
    void Start()
    {
        arrayOfGlasses = parentOfGlasses.GetComponentsInChildren<Transform>();
        GenerateGlassesParentPosition();
        for (int i = 0; i < arrayOfSelectedSpot.Length; i++)
        {
            arrayOfSelectedSpot[i].transform.position = arrayOfGlasses[i].transform.position;
        }
    }

    private void Update()
    {
        if (asWin == false)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButton(0))
            {

                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, float.PositiveInfinity, movableLayers);

                if (hit)
                {
                    IsDraged = true;
                    currentGlassTransform = hit.transform;
                }
            }
            else
            {
                IsDraged = false;
            }

            if(IsDraged)
            {
                currentGlassTransform.transform.position = mousePos;
            }
            //Winning condition
            foreach (var spot in arrayOfSelectedSpot)
            {
                if (spot.GetComponent<DragableGlassSlot>().IsComplete == false)
                {
                    return;
                }
            }
            asWin = true;
            GameManager.Instance.RandomizeNextState(); //next State
        }
    }


    public void GenerateGlassesParentPosition()
    {
        for (int i = 0; i < arrayOfGlasses.Length; i++)
        {
            Transform tmp = arrayOfGlasses[i];
            int randomizeIdOfPos = Random.Range(0, arrayOfGlasses.Length);
            arrayOfGlasses[i] = arrayOfGlasses[randomizeIdOfPos];
            arrayOfGlasses[randomizeIdOfPos] = tmp;
        }
    }
}
