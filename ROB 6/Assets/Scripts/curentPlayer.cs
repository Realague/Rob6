using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * CurrentPlayer.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.11
 * @since 17.10.05
 */
public class curentPlayer : MonoBehaviour {

    /**
     * Current player.
     *
     * @since 17.10.05
     */
    private Image current;

    /**
     * Get an image.
     *
     * @since 17.10.05
     */
	void Start () {
        current = GetComponent<Image>();
	}

    /**
     * Display the image.
     *
     * @since 17.10.05
     */
    void Update() {
        current.sprite = cursor.current.GetComponent<SpriteRenderer>().sprite;
    }
}
