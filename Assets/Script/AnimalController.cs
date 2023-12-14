using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private UIManager manager;

    [SerializeField] private float _moveSpeed;
    private int _hunger = 0;
    [SerializeField] private int _hungerNeed;
    [SerializeField] private int _score;
    private void Start() {
        manager = FindObjectOfType<UIManager>();
    }

    private void Update() {
        Movement();
    }

    private void Movement() {
        Vector3 movement = new Vector3(0f, 0f, 0.5f);

        transform.Translate(movement * _moveSpeed * Time.deltaTime);
    }

    public void TakeFood(int value) {
        _hunger += value;

        if(_hunger >= _hungerNeed) {
            manager.AddScore(_score);
            Debug.Log("done");
            Destroy(this.gameObject);
        }
    }
}
