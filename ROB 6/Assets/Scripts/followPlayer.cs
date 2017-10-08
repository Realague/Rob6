using UnityEngine;

public class followPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        offset = transform.position - player.transform.position;
        transform.position = player.transform.position + offset;
    }
}
