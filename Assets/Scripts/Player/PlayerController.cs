using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    CreateEquipment createE;

    public Interactable focus;
    public LayerMask movementMask;

    CreateEquipment create;
    Camera cam;
    PlayerMotor motor;
    
    public GameObject helmet;
    public GameObject platemail;
    public GameObject plateleg;
    Equipment equipment;

    public Sprite helmetIcon;
    public Sprite platelegIcon;
    public Sprite platemailIcon;

    public SkinnedMeshRenderer helmetMesh;
    public SkinnedMeshRenderer platelegMesh;
    public SkinnedMeshRenderer platemailMesh;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null) {
                    SetFocus(interactable);
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            trying();
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if(focus != null)
                newFocus.OnDefocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if(focus != null)
            focus.OnDefocused();

        focus = null;   
        motor.StopFollowingTarget();
    }

    void trying()
    {
        createE.CreateAsset(equipment);
        equipment.EquipmentLevelModifier = Random.Range(1, 11);
        equipment.equipSlot = EquipmentSlot.Chest;
        equipment.icon = platemailIcon;
        equipment.mesh = platemailMesh;

        equipment.baseArmor = 2;
        equipment.baseDamage = 5;
        equipment.baseHealth = 12;

        equipment.armorModifier = 3;
        equipment.damageModifier = 9;
        equipment.healthModifier = 25;

        equipment.coveredMeshRegion.Add(EquipmentMeshRegion.Arms);
        equipment.coveredMeshRegion.Add(EquipmentMeshRegion.Torse);

        platemail.GetComponent<ItemPickup>().item = equipment;
    }
}
