using System.Collections;
using UnityEngine;

public class CatClickAnimation : MonoBehaviour
{
    [SerializeField]
    private float scaleMultiplier = 1.1f;

    [SerializeField]
    private float duration = 0.08f;

    private Vector3 defaultScale;

    private Coroutine currentAnimation;

    private void Awake()
    {
        defaultScale = transform.localScale;
    }

    public void Animate()
    {
        if (currentAnimation != null)
            StopCoroutine(currentAnimation);

        currentAnimation = StartCoroutine(PlayAnimation());
    }

    private IEnumerator PlayAnimation()
    {
        transform.localScale = defaultScale * scaleMultiplier;

        yield return new WaitForSeconds(duration);

        transform.localScale = defaultScale;
    }
}