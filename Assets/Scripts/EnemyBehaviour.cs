using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public List<Vector2Int> MovePositions;


    [SerializeField] private float speed = 0.1f;
    private Vector2 nextPosition;
    // Start is called before the first frame update
    private void Start()
    {
        nextPosition = new Vector2(transform.position.x, transform.position.y);
        InvokeRepeating("CalculateNewPosition", 1, 2);
    }
    void Update()
    {
        MoveToRandomPositon();
    }
    private void MoveToRandomPositon()
    {
        gameObject.transform.position = new Vector3(Mathf.Lerp(transform.position.x, nextPosition.x, speed), Mathf.Lerp(transform.position.y, nextPosition.y, speed), 0);
    }

    private void CalculateNewPosition()
    {
        System.Random rand = new System.Random();
        Vector2 potentialNextPostion = MovePositions[rand.Next(MovePositions.Count)];
        while(potentialNextPostion == nextPosition)
        {
            potentialNextPostion = MovePositions[rand.Next(MovePositions.Count)];
        }
        nextPosition = potentialNextPostion;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            StartCoroutine(wait2Seconds());
        }
    }

    IEnumerator wait2Seconds()
    {
        yield return new WaitForSeconds(2);
        GameStateManager.ResetGame();
    }
}
