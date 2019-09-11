using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFarAway : MonoBehaviour
{
    private GameObject itemActivatorObject;
    private ItemActivator activationScript;

    // Start is called before the first frame update
    void Start()
    {
        itemActivatorObject = GameObject.Find("WorldGenerator");
        activationScript = itemActivatorObject.GetComponent<ItemActivator>();

        StartCoroutine("AddToList");
    }

    IEnumerator AddToList()
    {

        yield return new WaitForSeconds(0.1f);

        activationScript.activatorItems.Add(new ActivatorItem {item = this.gameObject, itemPos = transform.position});
    }
}
