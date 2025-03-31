using System.Collections;
using UnityEngine;

public class RetroTVEffect : MonoBehaviour
{
    public Material tvMaterial; // The material with the retro TV shader
    public float delayTime = 2f; // Time before the TV turns on

    void Start()
    {
        StartCoroutine(TurnOnTV());
    }

    IEnumerator TurnOnTV()
    {
        // Set initial static values
        tvMaterial.SetFloat("_StaticAmount", 0.5f); // Control static amount
        tvMaterial.SetFloat("_Fade", 0.0f); // Start with TV off

        // Wait for delay
        yield return new WaitForSeconds(delayTime);

        // Gradually increase the fade
        float fadeTime = 2f; // How long the fade will take
        float timer = 0f;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            float fade = Mathf.Lerp(0f, 1f, timer / fadeTime);
            tvMaterial.SetFloat("_Fade", fade); // Fade the TV in
            yield return null;
        }
    }
}

