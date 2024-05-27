using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptOne : MonoBehaviour
{
    public Vector2 direction = new Vector2(1, 2);
    public Color gbp = new Color(255, 255, 2);

    public Color run = new Color(255, 0, 0);
    public SpriteRenderer colorForPlayer;
    // Start is called before the first frame update
    void Start()
    {

        colorForPlayer.color = run;

           
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
