﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Shoot.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.11.19
 * @since 17.10.11
 */
public class Shoot : MonoBehaviour
{
    /**
     * Speed of bullets.
     *
     * @unityParam
     * @since 17.10.11
     */
    [SerializeField]
    private float speed = 100.0f;

    /**
     * Positions of the bullet.
     *
     * @unityParam
     * @since 17.10.11
     */
    [SerializeField]
    private GameObject playerPosition;

    /**
     * Move the bullet.
     *
     * @since 17.10.11
     */
	private void Update()
    {
        playerPosition.transform.Translate(Vector2.left * (Time.deltaTime * speed));
        Destroy(this.gameObject, 3.0f);
    }
}
