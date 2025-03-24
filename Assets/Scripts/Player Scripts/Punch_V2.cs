using UnityEngine;

public class PunchController : MonoBehaviour
{
    public Transform leftFist; // Assign the left fist GameObject
    public Transform rightFist; // Assign the right fist GameObject
    public float punchSpeed = 50f; // Speed at which the fist moves
    public float punchRange = 2f; // Maximum distance the fist can move
    public float punchCooldown = 0.5f; // Time (seconds) between punches
    public int punchDamage = 20; // Damage dealt by the punch
    public Collider colliderToIgnore; // The collider to be ignored during all times (e.g., player body)

    private Camera mainCamera;
    private bool isPunching = false;
    private float lastPunchTime = -999f; // Tracks when the last punch occurred

    // Animator components for both fists
    private Animator leftFistAnimator;
    private Animator rightFistAnimator;

    void Start()
    {
        mainCamera = Camera.main;

        // Initialize animators
        leftFistAnimator = leftFist.GetComponent<Animator>();
        rightFistAnimator = rightFist.GetComponent<Animator>();

        // If colliderToIgnore is provided, make fists ignore it completely
        if (colliderToIgnore != null)
        {
            Collider leftFistCollider = leftFist.GetComponent<Collider>();
            Collider rightFistCollider = rightFist.GetComponent<Collider>();

            // Ensure fists never collide with the colliderToIgnore
            Physics.IgnoreCollision(leftFistCollider, colliderToIgnore, true);
            Physics.IgnoreCollision(rightFistCollider, colliderToIgnore, true);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isPunching && Time.time >= lastPunchTime + punchCooldown)
        {
            // Start the punch with animation
            Transform fistToPunch = GetClosestFist();
            StartCoroutine(PunchMove(fistToPunch));

            // Trigger the punch animation for the selected fist
            if (fistToPunch == leftFist)
            {
                leftFistAnimator.SetTrigger("Punch");
            }
            else
            {
                rightFistAnimator.SetTrigger("Punch");
            }
        }
    }

    Transform GetClosestFist()
    {
        Vector3 mousePos = GetMouseWorldPosition();
        float leftDistance = Vector3.Distance(leftFist.position, mousePos);
        float rightDistance = Vector3.Distance(rightFist.position, mousePos);

        return leftDistance < rightDistance ? leftFist : rightFist;
    }

    System.Collections.IEnumerator PunchMove(Transform fist)
    {
        isPunching = true;
        lastPunchTime = Time.time; // Update cooldown timer

        // Get updated mouse position
        Vector3 mousePos = GetMouseWorldPosition();
        Vector3 direction = (mousePos - fist.position).normalized;

        // Set the target to a fixed range from the fist in the direction of the cursor
        Vector3 punchTarget = fist.position + direction * punchRange;

        // Move the closest fist to the target position
        while (Vector3.Distance(fist.position, punchTarget) > 0.1f)
        {
            fist.position = Vector3.MoveTowards(fist.position, punchTarget, punchSpeed * Time.deltaTime);
            yield return null;
        }

        // Finish punching
        isPunching = false;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(mainCamera.transform.position.z); // Ensure proper depth for 2D/3D
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}
