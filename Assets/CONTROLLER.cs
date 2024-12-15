using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public GameObject taxi;                  // Reference to the taxi GameObject
    public Transform[] randomLocations;      // Array of 5 random locations for the character
    public Transform[] destinationLocations; // Array of 3 possible destinations for the taxi
    public ArrowBehavior arrow;              // Reference to the ArrowBehavior script
    public float detectionRange = 10f;       // Range within which the taxi triggers transport


    private Transform lastLocation;          // Last location to avoid repetition
    private Transform currentDestination;    // Current destination for the taxi
    private bool isTransported = false;      // Whether the character has been transported

    void FixedUpdate()
    {
        if (taxi == null || randomLocations.Length == 0 || destinationLocations.Length == 0) return;

        // Check if the taxi is within range and the character hasn't been transported yet
        float distanceToTaxi = Vector3.Distance(transform.position, taxi.transform.position);
        Debug.Log("Distance to taxi: " + distanceToTaxi);
        Debug.Log("Is Transported: " + isTransported);
        if (distanceToTaxi <= detectionRange && !isTransported)
        {
            TransportCharacter();
            AssignDestination();
        }
    }

    void TransportCharacter()
    {
        // Select a random location for the character
        Transform chosenLocation;
        do
        {
            int randomIndex = Random.Range(0, randomLocations.Length);
            chosenLocation = randomLocations[randomIndex];
        } while (chosenLocation == lastLocation);

        // Move the character to the chosen location
        transform.position = chosenLocation.position;
        lastLocation = chosenLocation;

        //isTransported = true; // Mark as transported
        Debug.Log("Character transported to: " + chosenLocation.name);
    }

    void AssignDestination()
    {
        // Select a random destination for the taxi
        int randomIndex = Random.Range(0, destinationLocations.Length);
        currentDestination = destinationLocations[randomIndex];

        // Notify the arrow to point at the destination
        if (arrow != null)
        {
            arrow.SetDestination(currentDestination, isTransported);
        }

        Debug.Log("Destination assigned: " + currentDestination.name);
    }

    public void ClearDestination()
    {
        Debug.Log("CLEAR DEST CALLED");
        // Clear the current destination when the taxi reaches it
        currentDestination = null;
        isTransported = false;

        if (arrow != null)
        {
            arrow.HideArrow();
        }
    }

    public Transform GetCurrentDestination()
    {
        return currentDestination;
    }
}

/*using UnityEngine;
using TMPro;  // Include the TextMeshPro namespace

public class CharacterBehavior : MonoBehaviour
{
    public GameObject taxi;                  // Reference to the taxi GameObject
    public Transform[] randomLocations;      // Array of 5 random locations for the character
    public Transform[] destinationLocations; // Array of 3 possible destinations for the taxi
    public ArrowBehavior arrow;              // Reference to the ArrowBehavior script
    public TMP_Text timeText;                // Reference to the UI TextMeshPro Text for displaying time
    public TMP_Text scoreText;               // Reference to the UI TextMeshPro Text for displaying score
    public float detectionRange = 10f;       // Range within which the taxi triggers transport
    public float maxTime = 60f;              // Max time for transporting the character

    private Transform lastLocation;          // Last location to avoid repetition
    private Transform currentDestination;    // Current destination for the taxi
    private float startTime;                 // The time when the character is transported
    private float elapsedTime;               // Time elapsed since the character was transported

    public static float cashEarned = 0;      // Static variable to hold the total cash earned

    void FixedUpdate()
    {
        if (taxi == null || randomLocations.Length == 0 || destinationLocations.Length == 0) return;

        // Update the UI texts for time and score
        if (startTime > 0)  // Check if the character has been transported (startTime has been set)
        {
            elapsedTime = Time.time - startTime; // Calculate time taken
            if (elapsedTime <= maxTime)
            {
                timeText.text = "Time: " + Mathf.RoundToInt(elapsedTime).ToString() + "s"; // Update time UI
            }
        }

        // Display score
        scoreText.text = "Cash: $" + Mathf.RoundToInt(cashEarned).ToString();

        // Check if the taxi is within range and the character hasn't been transported yet
        float distanceToTaxi = Vector3.Distance(transform.position, taxi.transform.position);
        if (distanceToTaxi <= detectionRange && startTime == 0) // Character hasn't been transported (startTime is not set)
        {
            TransportCharacter();
            AssignDestination();
        }

        // If the character has been transported, calculate the time elapsed
        if (startTime > 0 && elapsedTime > maxTime)
        {
            // If max time is exceeded, you can penalize or stop the game here
            Debug.Log("Transport time exceeded!");
            startTime = 0; // Reset startTime, effectively marking the end of the transport
        }
    }

    void TransportCharacter()
    {
        // Select a random location for the character
        Transform chosenLocation;
        do
        {
            int randomIndex = Random.Range(0, randomLocations.Length);
            chosenLocation = randomLocations[randomIndex];
        } while (chosenLocation == lastLocation);

        // Move the character to the chosen location
        transform.position = chosenLocation.position;
        lastLocation = chosenLocation;

        // Record the start time when the character is transported
        startTime = Time.time;
        Debug.Log("Character transported to: " + chosenLocation.name);
    }

    void AssignDestination()
    {
        // Select a random destination for the taxi
        int randomIndex = Random.Range(0, destinationLocations.Length);
        currentDestination = destinationLocations[randomIndex];

        // Notify the arrow to point at the destination
        if (arrow != null)
        {
            arrow.SetDestination(currentDestination);
        }

        Debug.Log("Destination assigned: " + currentDestination.name);
    }

    public void ClearDestination()
    {
        // When the taxi reaches the destination, calculate the time and earn cash
        if (startTime > 0)
        {
            float timeTaken = Time.time - startTime;
            float cash = Mathf.Max(0, maxTime - timeTaken);  // Penalize for time over maxTime
            cashEarned += cash; // Add cash to the total
            Debug.Log("Cash earned: " + cash + ". Total Cash: " + cashEarned);
        }

        Debug.Log("CLEAR DEST CALLED");

        // Clear the current destination when the taxi reaches it
        currentDestination = null;
        startTime = 0; // Reset the start time, marking that the character has been transported

        if (arrow != null)
        {
            arrow.HideArrow();
        }
    }

    public Transform GetCurrentDestination()
    {
        return currentDestination;
    }
}*/





