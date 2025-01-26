using UnityEngine;

public class OneShotSound : MonoBehaviour
{
    //一个生成音效的gameObject，OnMouseOver()时，Coin会 insantiate这个gameObject,在 Coin里，这个命名为Death Sound但是被赋予当前gameObject

    /* 
        AudioClip可以储存audio file, 然后被AudioSource 通过AudioSource类的PlayOneShot()方法引用AudioClip来播放声音
        在右侧面板可以替换AudipClip的实例，方便让所有引用这个Audio Source的AudioClip实例(mp3)都一起被更换
    */
    public AudioClip AudioClip;

    //用来播放Audio Clip的实例(mp3)
    private AudioSource audioSource;

    //LifeTime时这个gameObject存活的时间，从timer开始计算。这两个是用来配合的，计算结果返回给timer 直到超过LifeTime
    public float LifeTime = 1f;
    private float timer = 0f;


    //每次这个gameObject被调用时，脚本也会被调用时，也就是这个脚本Start()时， 也就是Coin insantiate它的Death Sound 也就是当前这个gameObject时
    void Start()
    {
        //声明了，现在要在当前gameObject上寻找并且GetComponent
        audioSource = GetComponent<AudioSource>();
        
        //当有get到 AudioSource这个Component 和 AudioClip有被赋予音频(返回值不为null), 并且AudioSource这个组件没有在播放
        if (audioSource && AudioClip && !audioSource.isPlaying)
        {
            //利用AudioSource类的方法PlayOneShot播放AudioClip
            audioSource.PlayOneShot(AudioClip);
        }

    }

    
    //发出声音过后要销毁自己，不要让游戏停留太多的这个gameObject
    //每一帧都调用
    void Update()
    {
        //只有timer > LifeTime才执行Destory
        if (timer < LifeTime)
        {
            /*
                有些设备一秒只调用30次Update，那么Time.deltaTime会比较大。有些设备一秒调用120次Update，那么Time.deltaTime会比较小
                so 帧率低，大；    帧率高，小
                Time.deltaTime能确保timer稳定积累
                time.deltaTime * Update次数 = 的值在所有设备上是一样的
                在 Update 方法里涉及时间相关的计算时，尽量使用 Time.deltaTime
                Time.deltaTime 就是为了解决 Update()方法在不同设备上调用次数不同所引发的时间积累和计算问题， 
            
             */

            //让timer加到超过或等于LifeTime
            timer += Time.deltaTime;

            //return timer的值，再继续加
            return;

        }

        //可以加入,1f实现基本相同的效果，但是灵活性较差
        Destroy(gameObject);

    }
}
