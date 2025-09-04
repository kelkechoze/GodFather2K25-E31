using Unity.VisualScripting;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector2 mousePos;
    public bool IsDraged = false;
    [SerializeField] private LayerMask movableLayers;

    void Start()
    {

    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, float.PositiveInfinity, movableLayers);

            if (hit)
            {
                IsDraged = true;
            }
        }
        else
        {
            IsDraged = false;
        }

        if(IsDraged)
        {
            gameObject.transform.position = mousePos;
        }
    }
}
