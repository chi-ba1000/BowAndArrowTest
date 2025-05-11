using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus : MonoBehaviour
{
    public Transform fall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Bonus()
    {
        float yposition = fall.position.y;
        if (yposition < 0)
        {
            int add = Mathf.RoundToInt (-yposition);
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.AddScore(add);
        }
    }
}
