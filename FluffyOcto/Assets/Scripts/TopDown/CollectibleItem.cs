using TMPro;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
	public GameObject TextObject;

	public GameObject NextItem;
	public GameObject ClosestThis;

    public float NextItemDistance = 150f;
    public bool NextInactiveOnInit = true;

    public float TextDuration = 7;

	[HideInInspector] public Color OrigClosestThisColor;
	private void Start()
	{
        var text = TextObject.GetComponent<TextMeshPro>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
        TextObject.SetActive(false);


        if (NextInactiveOnInit && NextItem)
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
