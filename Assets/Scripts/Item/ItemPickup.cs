using UnityEngine;

public class ItemPickup : Interactable {

    public Item item;

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    void Pickup() {
        //Debug.Log("Pick up " + item.name);
        bool picked = Inventory.instance.Add(item);

        if (picked)
        {
            Destroy(gameObject);
        }
    }
}
