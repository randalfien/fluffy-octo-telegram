using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideObjectTrigger : MonoBehaviour
{

    public GameObject ObjectToShow;
    public bool HideOnTrigger = true;

    private void Start()
    {
        ObjectToShow.SetActive(HideOnTrigger);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ObjectToShow.GetComponent<SpriteRenderer>().enabled = !HideOnTrigger;
    }

}
