using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3.0f;
    public Transform InteractionTransform;

    bool isFocus = false;
    Transform player;

    bool interacted = false;

    public virtual void Interact()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isFocus && !interacted)
        {
            float distance = Vector3.Distance(player.transform.position, InteractionTransform.transform.position);
            if(distance <= radius)
            {
                Interact();
                interacted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        interacted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        interacted = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (InteractionTransform == null)
            InteractionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractionTransform.transform.position, radius);
    }
    
    
}
