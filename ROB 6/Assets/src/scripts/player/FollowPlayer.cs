using UnityEngine;

/**
 * CurrentPlayer.
 *
 * @author Julien Delane
 * @version 17.10.10
 * @since 17.10.10
 */
public class followPlayer : MonoBehaviour
{
    /**
     * The player to follow.
     *
     * @unityParam
     * @since 17.10.10
     */
    public GameObject player;

    /**
     * Offset to follow the player.
     *
     * @since 17.10.10
     */
    private Vector3 offset;

    /**
     * Make the camera move when the player move to follow the player.
     *
     * @since 17.10.10
     */
    void Update()
    {
        offset = transform.position - player.transform.position;
        transform.position = player.transform.position + offset;
    }
}
