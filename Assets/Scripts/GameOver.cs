using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
    void OnCollisionExit2D () {
        ObjectsGenerator.isGameOver = true;
    }
}
