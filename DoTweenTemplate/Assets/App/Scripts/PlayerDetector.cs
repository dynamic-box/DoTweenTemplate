using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerDetector : MonoBehaviour
{
    #region Collision Sounds
    [SerializeField] private AudioSource coinSound;

    #endregion


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);  
        if (other.gameObject.layer == LayerMask.NameToLayer("Coin"))
        {
            //increase coin count

            coinSound.Stop();

            coinSound.Play();

            Vector2 coinScreenPos = Camera.main.WorldToScreenPoint(other.transform.position);


            Destroy(other.gameObject);
        }

        other.GetComponent<Collider>().enabled = false;

    }

}
