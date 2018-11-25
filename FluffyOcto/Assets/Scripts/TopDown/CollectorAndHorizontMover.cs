using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CollectorAndHorizontMover : MonoBehaviour {

    public GameObject Horizont;


    private void OnTriggerEnter2D(Collider2D other)
    {
        var collectible = other.gameObject.GetComponent<CollectibleItem>();
        if (collectible)
        {
            other.gameObject.SetActive(false);
            collectible.TextObject.SetActive(true);
            var nextItem = collectible.NextItem;
            if (nextItem != null)
            {
                if (collectible.NextInactiveOnInit)
                {
                    nextItem.SetActive(true);
                }
                Horizont.transform.DOLocalMoveY(nextItem.transform.localPosition.y + collectible.NextItemDistance, 1f);
            }
            else
            {
                Horizont.transform.DOLocalMoveY(Horizont.transform.localPosition.y + collectible.NextItemDistance, 1f);
            }

            if (collectible.ClosestThis != null)
            {
                collectible.ClosestThis.SetActive(true);
                var closingSprite = collectible.ClosestThis.GetComponent<SpriteRenderer>();
                var clr = collectible.OrigClosestThisColor;
                clr.a = 0;
                closingSprite.color = clr;
                closingSprite.DOFade(1, 0.3f);
            }
        }
    }

}
