using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    [Range(50, 150)]
    public int balls;
    public float degrees;

    private List<GameObject> ballList;

    private void Start()
    {
        ballList = new List<GameObject>();
    }

    void OnMouseUpAsButton()
    {
        float step = degrees / (float)balls;
        float colorStep = 1.0f / (float)balls;
        Vector2 direction = new Vector2(0.0f, -10.0f * step);

        if (ballList.Count > 0)
        {
            foreach (var ball in ballList)
            {
                Destroy(ball.gameObject);
            }
            ballList.Clear();
        }
        Vector3 fixedMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 position = Camera.main.ScreenToWorldPoint(fixedMousePosition);
        for (int i = 0; i < balls; i++)
        {
            GameObject newBall = Instantiate(ballPrefab, position, Quaternion.identity);
            direction = direction.Rotate(step);
            newBall.GetComponent<Ball>().ApplyForce(direction);
            newBall.GetComponent<Ball>().ApplyColor(Color.HSVToRGB(colorStep * i, 1.0f, 1.0f));
            ballList.Add(newBall);
        }
    }
}
