using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkSprite : MonoBehaviour
{
    public float blinkSpeed = 2.0f; // Adjust the speed of the blinking
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Start the blinking coroutine
        StartCoroutine(Blinking());
    }

    public void StartBlink()
    {
        StartCoroutine(Blinking());
    }
    private IEnumerator Blinking()
    {
        while (true)
        {
            // Fade out (alpha = 0)
            while (spriteRenderer.color.a > 0)
            {
                Color currentColor = spriteRenderer.color;
                float newAlpha = Mathf.Max(0, currentColor.a - Time.deltaTime * blinkSpeed);
                spriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
                yield return null;
            }

            // Wait for a short duration with alpha at 0
            yield return new WaitForSeconds(0.5f);

            // Fade in (alpha = 1)
            while (spriteRenderer.color.a < 1)
            {
                Color currentColor = spriteRenderer.color;
                float newAlpha = Mathf.Min(1, currentColor.a + Time.deltaTime * blinkSpeed);
                spriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
                yield return null;
            }

            // Wait for a short duration with alpha at 1
            yield return new WaitForSeconds(0.5f);
        }
    }
}
