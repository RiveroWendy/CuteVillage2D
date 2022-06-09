using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutHouse : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private AnimationClip _finalanimation;
    [SerializeField] bool isCollisions = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    IEnumerator ChangeScene()
    {
        _animator.SetTrigger("Cambiar");
        yield return new WaitForSeconds(_finalanimation.length);

        SceneManager.LoadScene("Village");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        StartCoroutine(ChangeScene());
        isCollisions = true;

    }
}
