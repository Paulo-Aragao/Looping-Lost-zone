using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AndroidInputs : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 endPos;
    public Vector2 direction;

    string message;
    public string _direction_input = "none";

    void Update()
    {
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    startPos = touch.position;
                    message = "Begun ";
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    direction = touch.position - startPos;
                    message = "Moving ";
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    endPos = touch.position;
                    DragDirectionInput();
                    message = "Ending ";
                    break;
            }
        }
    }
    public void DragDirectionInput(){
       /* Se Xfinal e menor que Xinicial então o movimento é para esquerda;
        Se Xfinal e maior que Xinicial então o movimento é para direita;
        Se Yfinal e menor que Yinicial então o movimento é para baixo;
        Se Yfinal e maior que Yinicial então o movimento é para cima.*/
        // obtem a diferença entre as posicoes

        float x = endPos.x - startPos.x;

        float y = endPos.y - startPos.y;
        if (Mathf.Abs (x) > Mathf.Abs (y)) {
            if(endPos.x < startPos.x){
            _direction_input = "left";
            }else if(endPos.x > startPos.x){
                _direction_input = "right";
            }
        }else{
            if(endPos.y < startPos.y){
                _direction_input = "down";
            }else if(endPos.y > startPos.y){
                _direction_input = "up";
            }
        }
        
        
        
    }
}