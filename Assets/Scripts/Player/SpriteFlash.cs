using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    // List of SpriteRenderers to flash and their original colors
    private List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
    private List<Color> originalColors = new List<Color>(); 

    void Awake()
    {
        // Get all SpriteRenderers in this GameObject and its children
        spriteRenderers.AddRange(GetComponentsInChildren<SpriteRenderer>());

        // Store the original colors for each SpriteRenderer
        foreach (var spriteRenderer in spriteRenderers)
        {
            originalColors.Add(spriteRenderer.color);
        }
    }

    public IEnumerator FlashCoroutine(float flashDuration, Color flashColor, int numberOfFlashes)
    {
        // Total time divided by the number of flashes
        float flashInterval = flashDuration / (numberOfFlashes * 2); 
        float elapsedTime = 0f;

        for (int i = 0; i < numberOfFlashes * 2; i++)
        {
            // Flash all sprite renderers to the flash color
            for (int j = 0; j < spriteRenderers.Count; j++)
            {
                spriteRenderers[j].color = (i % 2 == 0) ? flashColor : originalColors[j];
            }

            // Wait for the interval
            elapsedTime = 0f;
            while (elapsedTime < flashInterval)
            {
                elapsedTime += Time.deltaTime;
                yield return null; 
            }
        }

        // Reset all sprite renderers to their original colors after flashing
        for (int j = 0; j < spriteRenderers.Count; j++)
        {
            spriteRenderers[j].color = originalColors[j]; 
        }
    }
}
