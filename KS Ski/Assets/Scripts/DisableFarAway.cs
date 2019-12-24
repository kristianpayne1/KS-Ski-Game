using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFarAway : MonoBehaviour
{
    private GameObject itemActivatorObject;
    private ItemActivator activationScript;
    private ActivatorItem item;

    // Start is called before the first frame update
    void Start()
    {
        itemActivatorObject = GameObject.Find("WorldGenerator");
        activationScript = itemActivatorObject.GetComponent<ItemActivator>();
        item = new ActivatorItem {item = this.gameObject, itemPos = transform.position};
        StartCoroutine("AddToList");
    }

    void Update() {
        item.itemPos = transform.position;
    }

    IEnumerator AddToList()
    {

        yield return new WaitForSeconds(0.1f);

        activationScript.activatorItems.Add(item);
    }
}