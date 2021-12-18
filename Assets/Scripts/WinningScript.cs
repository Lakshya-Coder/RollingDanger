using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningScript : MonoBehaviour
{
    [SerializeField] private Material winningMaterial;
    [SerializeField] private GameObject winningUI;

    IEnumerator WinningRoutine()
    {
        GetComponent<MeshRenderer>().material = winningMaterial;
        winningUI.SetActive(true);

        Time.timeScale = 0.25f;

        yield return new WaitForSeconds(1f);

        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WinningRoutine());
        }
    }
}