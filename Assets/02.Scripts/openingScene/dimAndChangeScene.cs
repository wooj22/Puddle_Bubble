using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dimAndChangeScene : MonoBehaviour
{
    private Renderer objectRenderer;
    private AudioSource audioSource;
    private float fadeDuration = 2.0f; // 투명도 변경에 걸리는 시간 (초)

    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();

        if (objectRenderer != null)
        {
            Color color = objectRenderer.material.color;
            color.a = 0;
            objectRenderer.material.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if (objectRenderer != null && audioSource != null)
            {
                StartCoroutine(PlayAudioAndFadeIn());
            }
        }
    }

    private IEnumerator PlayAudioAndFadeIn()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        Color color = objectRenderer.material.color;
        float startAlpha = color.a;
        float rate = 1.0f / fadeDuration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            color.a = Mathf.Lerp(startAlpha, 1, progress);
            objectRenderer.material.color = color;
            progress += rate * Time.deltaTime;
            yield return null;
        }

        color.a = 1;
        objectRenderer.material.color = color;
        SceneManager.LoadScene("Woo2");
    }
}
