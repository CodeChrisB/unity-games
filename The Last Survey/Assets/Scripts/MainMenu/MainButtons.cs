using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtons : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float delay;
    [SerializeField]
    float time;
    [SerializeField]
    public LeanTweenType type;
    void Start()
    {
        gameObject.SetActive(false);
        LeanTween.delayedCall(delay, Animation);
    }

    void Animation() {
        if (gameObject == null)
            return;
        gameObject.SetActive(true);
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 1f).setEase(type); 
    }
}
