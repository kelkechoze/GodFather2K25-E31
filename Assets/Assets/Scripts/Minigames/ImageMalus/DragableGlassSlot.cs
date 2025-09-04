using System;
using UnityEngine;

public class DragableGlassSlot : MonoBehaviour
{
    [field: SerializeField] public bool IsComplete { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Dragable"))
        {
            other.gameObject.layer = LayerMask.NameToLayer("Default");
            other.gameObject.transform.position = transform.position;
            ImageMalusManager.ImageMalusManagerInstance.IsDraged = false;
            IsComplete = true;
        }
    }
}
