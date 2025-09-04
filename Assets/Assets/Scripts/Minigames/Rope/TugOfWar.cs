using UnityEngine;

public class TugOfWar : MonoBehaviour
{
    public bool IsPlaying = false;
    public float FranckoStrenght;
    public float PlayerStrenght;
        

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsPlaying = true;
        }

        if (IsPlaying)
        {
            gameObject.transform.position += Vector3.right * FranckoStrenght;

            if (Input.GetMouseButtonDown(0))
            {
                gameObject.transform.position += Vector3.left * PlayerStrenght;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "TugOfWarWin")
        {
            Debug.Log("You WIN !!!");
        }
        else if(collision.tag == "TugOfWarLose")
        {
            Debug.Log("You LOSE !!!");
        }
        IsPlaying = false;
    }
}
