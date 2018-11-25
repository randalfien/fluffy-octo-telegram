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

    private GameObject Text;
    
    private void Start()
    {
        if (ChangeActiveOnStart)
        {
            ObjectToShow.SetActive(HideOnTrigger);
        }
        if (transform.childCount > 0)
        {
            Text = transform.GetChild(0).gameObject;
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
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = !HideOnTrigger;
            Text?.SetActive(!HideOnTrigger);
        }
        else
        {
            ObjectToShow.SetActive(!HideOnTrigger);
        }
    }

}
