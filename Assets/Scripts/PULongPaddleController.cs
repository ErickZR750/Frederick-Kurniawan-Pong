// I SURRENDER.
// After so many hours of trying time, I've decided I'm done.
// I rather kill myself instead of beating around this script and PowerUpManager script any further.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULongPaddleController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public int increaseByNumberOfTimes;
    public int duration;
    public Transform leftPaddle;
    public Transform rightPaddle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            Debug.Log("Starting ResetPaddleScale coroutine.");
            IncreasePaddleScale();
            StartCoroutine(ResetPaddleScale());
            manager.RemovePowerUp(gameObject);
        }
    }

    void IncreasePaddleScale()
    {
        if (leftPaddle != null)
        {
            leftPaddle.localScale = new Vector3(leftPaddle.localScale.x, leftPaddle.localScale.y * increaseByNumberOfTimes, 2);
        }

        if (rightPaddle != null)
        {
            rightPaddle.localScale = new Vector3(rightPaddle.localScale.x, rightPaddle.localScale.y * increaseByNumberOfTimes, 2);
        }
    }


    IEnumerator ResetPaddleScale()
    {
        Debug.Log("Coroutine dimulai, durasinya " + duration + " detik");
        yield return new WaitForSeconds(duration);
        Debug.Log("Sedang mereset paddle ke ukuran semula");

        if (leftPaddle != null)
        {
            leftPaddle.transform.localScale = new Vector3(leftPaddle.transform.localScale.x, leftPaddle.transform.localScale.y / increaseByNumberOfTimes, 2);
        }

        if (rightPaddle != null)
        {
            rightPaddle.transform.localScale = new Vector3(rightPaddle.transform.localScale.x, rightPaddle.transform.localScale.y / increaseByNumberOfTimes, 2);
        }
        Debug.Log("Codingan berhasil");
    }
}
