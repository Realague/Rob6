using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour {

    public string next;

    void OnTriggerEnter2D(Collider2D coll)
    {
        SceneManager.LoadScene(next);
    }
}
