using UnityEngine;

using UnityEngine.UI;
using UnityEngine.UIElements;

public class gravity : MonoBehaviour
{
    public GameObject Red;
    public GameObject Yellow;
    public GameObject Blue1;
    public GameObject Blue2;
    public GameObject Blue3;
    public GameObject Black;
    public GameObject Pig;

    public float BulletTime = 3f;

    public GameObject rer;
    private GameObject rrr;

    public bool Space;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tie();

        }


    }
    

    public void tie()
    {



        rrr=GameObject.Instantiate(rer);

        Red.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        Yellow.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        Blue1.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        Blue2.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        Blue3.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        Black.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
        Pig.GetComponent<Rigidbody2D>().gravityScale = 0.2f;



        Invoke("restore", BulletTime);
        


    }

    public void restore()
    {
        Red.GetComponent<Rigidbody2D>().gravityScale = 1f;
        Yellow.GetComponent<Rigidbody2D>().gravityScale = 1f;
        Blue1.GetComponent<Rigidbody2D>().gravityScale = 1f;
        Blue2.GetComponent<Rigidbody2D>().gravityScale = 1f;
        Blue3.GetComponent<Rigidbody2D>().gravityScale = 1f;
        Black.GetComponent<Rigidbody2D>().gravityScale = 1f;
        Pig.GetComponent<Rigidbody2D>().gravityScale = 1f;
        Destroy(rrr);


    }
}
