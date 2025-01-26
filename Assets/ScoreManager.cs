using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //计算分数的方法，会在其他脚本被引用，让其他脚本填入score值,然后它使用这个score值进行AddScore方法并更换Score: 后面的分数(UI)

    //先设置一开始的分数是0
    public int CurrentScore = 0;

    //Text 是 using UnityEngine.UI; 才有的class. Text变量和GameObeject类似，可以在编辑器中拖拽并定义ScoreText是什么Text 
    public Text ScoreText;
    
    //public Text ScoreTitle;
    //加分数的函数，支持填入int, 引用从Coin脚本的Amount变量
    //当这个方法被引用时将会执行增加分数,并且改变ScoreText的UI
    public void AddScore(int score) 
    {
        //当前的分数 = 当前分数 + 被填入什么分数(被填入什么分数相当于一下加多少), Coin 的 Amount
        CurrentScore += score;

        //如果ScoreText有被赋值到 (有拖拽到Text给它)
        if (ScoreText)
        {
            //这个Text会显示的内容 (.text) 将会是 "Score: " 然后将CurrentScore的值转换成string，再赋值给ScoreText.text属性，然后覆盖原本的text内容
            ScoreText.text = "Score: " + CurrentScore.ToString();
            
        }

}

}
