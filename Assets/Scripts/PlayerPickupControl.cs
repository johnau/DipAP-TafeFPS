using UnityEngine;

public class PlayerPickupControl : MonoBehaviour
{
    //public EventTypes.IntEvent obsolete_ammoPickupEvent;

    public EventTypes.IntAmmoEvent ammoPickupEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            AmmoPickup ammoPickup = other.GetComponent<AmmoPickup>();
            if (ammoPickup != null)
            {
                ammoPickupEvent.Invoke(ammoPickup.ammo, ammoPickup.ammoType);
                ammoPickup.Clear();
            }
        }
    }
}
