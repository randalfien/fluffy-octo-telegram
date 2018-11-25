using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProgresser : MonoBehaviour {

    public ProgressBar Progress;
    public float AdvanceBy = 0.25f;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.DownArrow)
             || Input.GetKeyDown(KeyCode.LeftArrow)
             || Input.GetKeyDown(KeyCode.RightArrow)
             || Input.GetKeyDown(KeyCode.UpArrow)
             || Input.GetKeyDown(KeyCode.W)
             || Input.GetKeyDown(KeyCode.A)
             || Input.GetKeyDown(KeyCode.S)
             || Input.GetKeyDown(KeyCode.D))
        {
            Progress.AddProgress(AdvanceBy);
        }

    }
}
