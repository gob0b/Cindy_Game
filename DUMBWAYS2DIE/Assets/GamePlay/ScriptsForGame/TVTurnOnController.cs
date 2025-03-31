using UnityEngine;
using System.Collections;

public class TVTurnOnController : MonoBehaviour
{
    public Material tvMaterial;  // Assign the TV shader material
    public float startDelay = 2f; // Delay before the TV turns on
    public float turnOnSpeed = 1.5f; // Speed of the turn-on effect
    public GameObject startButton; // UI Button to show after TV is on

    private float progress = 0f;

    void Start()
    {
        tvMaterial.SetFloat("_TurnOnProgress", 0f); // Start with the screen off (black)
        if (startButton)
            startButton.SetActive(false); // Hide button initially

        StartCoroutine(StartWithDelay()); // Auto-start after delay
    }

    IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(startDelay); // Wait before turning on TV
        StartCoroutine(TurnOnTV()); // Start turn-on effect
    }

    IEnumerator TurnOnTV()
    {
        // Smoothly increase progress (from black to full turn-on)
        while (progress < 1f)
        {
            progress += Time.deltaTime * turnOnSpeed;
            tvMaterial.SetFloat("_TurnOnProgress", progress);
            yield return null;
        }

        if (startButton)
            startButton.SetActive(true); // Show button after TV is fully on
    }
}


