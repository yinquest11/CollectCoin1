using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TimeController : MonoBehaviour
{
    [Range(0f,2f)]public float DefaultTimeScale=1;

    [SerializeField,Range(0f,2f)]float bulletTimeScale;

    public float timeRecoverDuration;

    private GUIStyle labelStyle;

    

    public GameObject RedPanel;

    public Button bton;

    public Text txtx;

    private Image imge;

    private Color originalColor;

    public Tme soud;

    public GameObject DeadEyeS;

    public GameObject DeadEyeSClone;

    





    private void Awake()
    {
        Time.timeScale = DefaultTimeScale;
        imge = RedPanel.GetComponent<Image>();
        originalColor = imge.color;
        
    }
   public void Start ()
   {
    
   }
   
   public void Update()
   {
        if(bton.interactable ==false)
        {
            float c = 1- Time.timeScale;
            txtx.text = c.ToString();
        }
        else
            txtx.text = "";
   }
  

    public void BulletTime()
    {
        DeadEyeSClone = Instantiate(DeadEyeS);

         RedPanel.SetActive(true);
         imge.color = originalColor;
         soud.source.volume = 0.3f;
         
        Time.timeScale= bulletTimeScale;
        
        StartCoroutine(TimeRecoveryCoroutine());
        
        


    }

    IEnumerator TimeRecoveryCoroutine()
    {
        Color start = imge.color;
        bton.interactable = false;
        float ratio = 0f;
        
        while(ratio<1)
        {
            
            ratio += Time.unscaledDeltaTime / timeRecoverDuration;
            Time.timeScale = Mathf.Lerp(bulletTimeScale,DefaultTimeScale,ratio);

            float newA = Mathf.Lerp(start.a,0f,ratio);
            Color newColor = new Color(start.r,start.g,start.b,newA);

            imge.color=newColor;

            yield return null;
        }
        

        bton.interactable = true;
        soud.source.volume = 1f;
        RedPanel.SetActive(false);
        Destroy(DeadEyeSClone);
        
        
    }
}
