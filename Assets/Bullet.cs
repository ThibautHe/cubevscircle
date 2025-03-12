using UnityEngine;
using DG.Tweening;
using System;

public class Bullet : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(1, 5, 1);
    public float duration = 1f;
    public float targetHeight = 10f;

    private Action onDie;

    public void AddOnDie(Action cb)
    {
        onDie += cb;
    }

    void Start()
    {

        transform.DOMoveY(targetHeight, duration).SetEase(Ease.Linear);
    }


    void OnTriggerEnter(Collider other)
    {
        // Check if the object collides with the ceiling
        if (other.CompareTag("Ceiling"))
        {
            // Destroy the object
            onDie?.Invoke();

            Destroy(gameObject);
        }

        if(other.CompareTag("bubble"))
        {
            Bubble bubble = other.GetComponent<Bubble>();
            bubble.die();
            onDie?.Invoke();

            Destroy(gameObject);
        }
    }

}
