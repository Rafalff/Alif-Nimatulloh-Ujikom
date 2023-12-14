using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _value = 25;
    //private void OnCollisionEnter(Collision collision) {
    //    if (collision.gameObject.CompareTag("Animal")) {
    //        var animal = collision.gameObject.GetComponent<AnimalController>();
    //        Debug.Log("food");
    //        animal.TakeFood();
    //    }
    //}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Animal")) {
            var animal = other.gameObject.GetComponent<AnimalController>();
            animal.TakeFood(_value);
            Destroy(this.gameObject);
        }
    }
}
