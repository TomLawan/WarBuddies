using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;
    private Transform playerTarget;

    void Start()
    {
        // Hanapin ang Player gamit ang Tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTarget = playerObj.transform;
        }
    }

    void Update()
    {
        if (playerTarget != null)
        {
            // Gumalaw papunta sa position ng Player
            transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);
        }
    }
}
