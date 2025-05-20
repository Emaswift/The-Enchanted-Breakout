using UnityEngine;

public class PotionTrigger : MonoBehaviour
{
    private Potion potion;

    void Start()
    {
        potion = GetComponentInParent<Potion>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (potion == null) return;

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Return))
        {
            Transform holdPoint = other.transform.Find("HoldPoint");

            if (holdPoint != null)
            {
                potion.PickUp(holdPoint);
            }
            else
            {
                Debug.LogWarning("No HoldPoint found on Player!");
            }
        }
    }
}