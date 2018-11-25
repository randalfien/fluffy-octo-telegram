using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CollectorAndHorizontMover : MonoBehaviour {

    public GameObject Horizont;

    void StartMsg(GameObject other)
    {
        var text = other.GetComponent<TextMeshPro>();
        text.DOFade(1, 0.1f);
    }
    void Rem(GameObject o)
    {
        Destroy(o);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        var collectible = other.gameObject.GetComponent<CollectibleItem>();
        if (collectible)
        {
            other.gameObject.SetActive(false);
            collectible.TextObject.SetActive(true);

            var text = collectible.TextObject.GetComponent<TextMeshPro>();
            text.DOFade(1, 0.1f);

            FindObjectOfType<RealityScheduler>().ScheduleMe(() => Destroy(collectible.TextObject), collectible.TextDuration, gameObject.layer);

            var nextItem = collectible.NextItem;
            if (nextItem && collectible.NextInactiveOnInit)
            {
                nextItem.SetActive(true);
            }
            Horizont.transform.DOLocalMoveY((nextItem ? nextItem : Horizont).transform.localPosition.y + collectible.NextItemDistance, 1f);

        }
    }

}
