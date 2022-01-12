using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private Score ScoreScript;
    private Points PointsScript;
    // Start is called before the first frame update
    void Start()
    {
        ScoreScript = GameObject.Find("Score").GetComponent<Score>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
