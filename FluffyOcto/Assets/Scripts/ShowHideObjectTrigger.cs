using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideObjectTrigger : MonoBehaviour
{

    public GameObject ObjectToShow;
    public bool HideOnTrigger = true;
    public bool ChangeActiveOnStart = true;
    public float Delay = 0;

    private bool hit = false;
    private void Start()
    {
        if (ChangeActiveOnStart)
        {
            ObjectToShow.SetActive(HideOnTrigger);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hit)
        {
            Invoke(nameof(onTriggerAfterDelay), Delay);
            hit = true;
        }

    }

    private void onTriggerAfterDelay()
    {
        SpriteRenderer spriteRenderer = ObjectToShow.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null) { spriteRenderer.enabled = !HideOnTrigger; }
        else { ObjectToShow.SetActive(!HideOnTrigger); }
    }

}
