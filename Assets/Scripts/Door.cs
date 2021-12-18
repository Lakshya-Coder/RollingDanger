using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float unlockingSpeed = 2f;
    [SerializeField] private float unlockingTime = 3f;
    [SerializeField] private bool isDoorUnlocked = false;

    public void UnlockDoor()
    {
        isDoorUnlocked = true;
    }

    private void Update()
    {
        if (isDoorUnlocked)
        {
            unlockingTime -= Time.deltaTime;
            transform.Translate(Vector3.down * Time.deltaTime * unlockingSpeed);

            if (unlockingTime <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
