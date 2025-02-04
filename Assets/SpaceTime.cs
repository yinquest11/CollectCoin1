using UnityEngine;

public class SpaceTime : MonoBehaviour
{

    public TimeController tt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1) )
        {
            if(tt.bton.interactable ==true)
            {
            tt.BulletTime();
            }
        }
        
    }
}
