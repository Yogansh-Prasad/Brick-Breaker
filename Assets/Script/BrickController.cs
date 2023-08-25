using UnityEngine;
using TMPro;

public class BrickController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int number;
    [SerializeField] BrickType brickType;

    void Start() {
        if (brickType == BrickType.BREAKABLE_BRICK)
            updateText();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (brickType == BrickType.UNBREAKABLE_BRICK) 
        {
            Debug.Log("Grey Hit");
            return;
        }
            
        if (brickType == BrickType.BREAKABLE_BRICK) 
        {
            number--;
            if (number == 0)
            {
                LevelManger.Instance.updateNoOfBricksLeft();
                Destroy(gameObject);
            }
            updateText();
            Debug.Log("Normal Hit");
        }

        if (brickType == BrickType.LAVA_BRICK) // Check if it's a lava brick
        {
            Debug.Log("Lava Hit");
            BallController ball = other.gameObject.GetComponent<BallController>(); // Get BallController script
            ball.ChangeLife(); // Double the ball's speed
            ball.ChangeColor(Color.red);
            Debug.Log("Speed Change");
            /* //if (ball != null)
             {

             }*/

        }

        
    }

    void updateText(){
        text.text = number.ToString();
    }
}
