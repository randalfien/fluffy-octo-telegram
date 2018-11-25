using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAdvProgressbar : MonoBehaviour {

    public ProgressBar Progress;
    public float AdvanceBy = 0.25f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Progress.AddProgress(AdvanceBy);
    }
}
