using UnityEngine;

public class DollarScaler : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 targetScale;
    public bool isScaling = false;
    private float scaleDuration = 0.1f;

    private void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale * 0.9f; // Scale down to 50%
    }

    private void Update()
    {
        if (isScaling)
        {
            // Perform scaling
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime / scaleDuration);

            // Check if we reached the target scale
            if (Vector3.Distance(transform.localScale, targetScale) < 0.01f)
            {
                // Scale back to original
                isScaling = false;
                StartCoroutine(ScaleBack());
            }
        }
    }

    private void OnMouseDown()
    {
        if (!isScaling)
        {
            isScaling = true;
        }
    }

    private System.Collections.IEnumerator ScaleBack()
    {
        // Wait for a moment before scaling back
        yield return new WaitForSeconds(0.5f);

        // Scale back up
        float elapsedTime = 0f;
        while (elapsedTime < scaleDuration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsedTime / scaleDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }



        transform.localScale = originalScale; // Ensure it ends exactly at the original scale


    }

    public void StartScaling()
    {
        isScaling = true;
    }
}
