using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
	public GameObject TextObject;
	public GameObject NextItem;
	private void Start()
	{
		TextObject.SetActive(false);
	}
}
