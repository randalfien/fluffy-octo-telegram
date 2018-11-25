using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
	public GameObject TextObject;

	public GameObject NextItem;
	public GameObject ClosestThis;

    public float NextItemDistance = 150f;
    public bool NextInactiveOnInit = true;

	[HideInInspector] public Color OrigClosestThisColor;
	private void Start()
	{
		TextObject.SetActive(false);
        if (NextInactiveOnInit)
        {
            NextItem?.SetActive(false);
        }

        if (ClosestThis != null)
		{
			ClosestThis.SetActive(false);
			OrigClosestThisColor = ClosestThis.GetComponent<SpriteRenderer>().color;
		}
	}

}
