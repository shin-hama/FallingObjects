using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
    void OnCollisionEnter2D() {
        ObjectsGenerator.isGameOver = true;
    }
}
