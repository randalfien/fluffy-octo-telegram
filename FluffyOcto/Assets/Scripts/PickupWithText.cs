using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PickupWithText : MonoBehaviour {

    public GameObject ObjectToShow;
    public bool HideOnTrigger = true;

    private bool activated;

    private void Start()
    {
        ObjectToShow.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ObjectToShow.SetActive(true);
        if (!activated)
        {
            activated = true;
            ObjectToShow.transform
                .DOMoveY(ObjectToShow.transform.localPosition.y + 100, 5)
                .SetDelay(1.5f)
                .OnComplete(() => ObjectToShow.SetActive(false));

        }
    }

}
