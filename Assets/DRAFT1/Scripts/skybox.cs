using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skybox : MonoBehaviour
{
    //all this from chatGPT after I typed the shader source script of the skybox to access the "cubemap transtion" property
    public Material skyboxMaterial;
    public float transitionDuration = .0f;
    public float targetTransitionValue = 1.0f; // Set your desired transition value

    private float currentTransitionValue = 0.0f;
    private bool isTransitioning = false;

    public void StartTransition()
    {
        if (!isTransitioning)
        {
            StartCoroutine(TransitionSkybox());
        }
    }

    IEnumerator TransitionSkybox()
    {
        isTransitioning = true;

        // Get the current transition value
        float startTransitionValue = skyboxMaterial.GetFloat("_CubemapTransition");

        float elapsedTime = 0.0f;
        while (elapsedTime < transitionDuration)
        {
            // Calculate transition value based on time
            currentTransitionValue = Mathf.Lerp(startTransitionValue, targetTransitionValue, elapsedTime / transitionDuration);

            // Set the transition value to the skybox material
            skyboxMaterial.SetFloat("_CubemapTransition", currentTransitionValue);

            // Wait for the next frame
            yield return null;

            // Update elapsed time
            elapsedTime += Time.deltaTime;
        }

        // Ensure the transition ends with the target value
        skyboxMaterial.SetFloat("_CubemapTransition", targetTransitionValue);

        isTransitioning = false;
    }
}