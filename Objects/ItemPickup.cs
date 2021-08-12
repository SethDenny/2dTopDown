using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public float radius = .3f;
    [SerializeField]
    PlayerMovement player;
    public Item item;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < radius)
        {
             PickUp();    
            
        }
    }
    void PickUp()
    {
        Debug.Log("picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
            
    }
}
