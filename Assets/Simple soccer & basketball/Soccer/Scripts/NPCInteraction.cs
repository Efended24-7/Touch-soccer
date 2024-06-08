using UnityEngine;
using UnityEngine.UI; // Needed for the Text component

public class NPCInteraction : MonoBehaviour
{
    public Text npcText;  // Drag your Text UI element to this field in the Inspector
    private bool isPlayerInRange = false;
    private void Start()
{
    if (npcText != null)
    {
        npcText.text = "";
    }
}
    private void Update()
    {
        // Check if the player is in range AND the left mouse button is clicked or screen is touched.
        if (isPlayerInRange && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            TalkToPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming your player has the tag "Player"
        {
            isPlayerInRange = true;
            Debug.Log("Player entered NPC range.");  // Diagnostic message
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            npcText.text = "";  // Clear the dialogue when player goes out of range
            Debug.Log("Player exited NPC range.");  // Diagnostic message
        }
    }

    private void TalkToPlayer()
    {
        // Display the NPC dialogue on the Text UI element
        npcText.text = "Hello!!!!!";
        Debug.Log("NPC should be talking now.");  // Diagnostic message
    }
}
