using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public GameObject taxi;            // Reference to the taxi GameObject
    private Transform currentTarget;   // The current destination the arrow is pointing to
    private bool isArrowVisible = false;
    public float detectionRange = 50f; // Distance at which the taxi is close enough to the destination to show the arrow
    void FixedUpdate()
    {
       // Debug.Log("Distance to destination: " + detectionRange);
        // If there is no target or taxi, hide the arrow and return
        if (currentTarget == null || taxi == null)
        {
            HideArrow();
            return;
        }

        // Check the range between the taxi and the current target (destination)
        float distanceToDestination = Vector3.Distance(taxi.transform.position, currentTarget.position);

        // If taxi is within range of the target destination, show the arrow
        if (distanceToDestination <= detectionRange && !isArrowVisible)
        {
            ShowArrow();
        }

        // Move the arrow above the destination and point downward
        if (isArrowVisible)
        {
            MoveAndOrientArrow();
        }

        // Check if the taxi has reached the destination
        if (distanceToDestination <= 5f)
        {
            Debug.Log("Destination reached!");
            HideArrow();

            // Notify the character to clear the destination
            var character = taxi.GetComponent<CharacterBehavior>();
            if (character != null)
            {
                character.ClearDestination();
            }
        }
    }

    public void SetDestination(Transform target,bool isTransported)
    {
        isTransported = true;
        currentTarget = target; // Set the current target
        ShowArrow();            // Show the arrow
    }

    private void MoveAndOrientArrow()
    {
        // Move the arrow 3 units above the destination
        Vector3 arrowPosition = currentTarget.position + new Vector3(0, 3, 0);
        transform.position = arrowPosition;

        // Rotate the arrow to always point downward towards the target
        Vector3 directionToTarget = currentTarget.position - transform.position;
        directionToTarget.y = 0; // Ignore the y-axis for rotation
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0); // Rotate it to face downward
    }

    public void ShowArrow()
    {
        gameObject.SetActive(true); // Enable the arrow GameObject
        isArrowVisible = true;
    }

    public void HideArrow()
    {
        gameObject.SetActive(false); // Disable the arrow GameObject
        isArrowVisible = false;
    }
}


/*using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public GameObject taxi;            // Reference to the taxi GameObject
    private Transform currentTarget;   // The current destination the arrow is pointing to
    private bool isArrowVisible = false;
    public float detectionRange = 50f; // Distance at which the taxi is close enough to the destination to show the arrow

    void FixedUpdate()
    {
        // If there is no target or taxi, hide the arrow and return
        if (currentTarget == null || taxi == null)
        {
            HideArrow();
            return;
        }

        // Check the range between the taxi and the current target (destination)
        float distanceToDestination = Vector3.Distance(taxi.transform.position, currentTarget.position);

        // If taxi is within range of the target destination, show the arrow
        if (distanceToDestination <= detectionRange && !isArrowVisible)
        {
            ShowArrow();
        }

        // Move the arrow above the destination and point downward
        if (isArrowVisible)
        {
            MoveAndOrientArrow();
        }

        // Check if the taxi has reached the destination
        if (distanceToDestination <= 5f)
        {
            Debug.Log("Destination reached!");
            HideArrow();

            // Notify the character to clear the destination
            var character = taxi.GetComponent<CharacterBehavior>();
            if (character != null)
            {
                character.ClearDestination();
            }
        }
    }

    public void SetDestination(Transform target, bool isTransported)
    {
        currentTarget = target; // Set the current target
        ShowArrow();             // Show the arrow
    }

    private void MoveAndOrientArrow()
    {
        // Move the arrow 3 units above the destination
        Vector3 arrowPosition = currentTarget.position + new Vector3(0, 3, 0);
        transform.position = arrowPosition;

        // Rotate the arrow to always point downward towards the target
        Vector3 directionToTarget = currentTarget.position - transform.position;
        directionToTarget.y = 0; // Ignore the y-axis for rotation
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0); // Rotate it to face downward
    }

    public void ShowArrow()
    {
        gameObject.SetActive(true); // Enable the arrow GameObject
        isArrowVisible = true;
    }

    public void HideArrow()
    {
        gameObject.SetActive(false); // Disable the arrow GameObject
        isArrowVisible = false;
    }
}*/
