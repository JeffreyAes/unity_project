using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStop : MonoBehaviour
{
    public float duration = 0.02f;
    private bool _isFrozen;
    float _pendingFreezeDuration = 0f;
    void Update()
    {
        //ensures that the player will not call freezeframes while already frozen
        if(_pendingFreezeDuration > 0 && !_isFrozen){
            StartCoroutine(DoFreeze()); 
            //coroutines are a fancy way to do functions 
            //where returns "don't end the function call"
        }
    }

    //TODO:
    //TODO:
    //TODO:
    //TODO: turn the hitstop class into a "camera effects" class
    //TODO: that way, I can add screenshake and other "stuff" more conveniently
    //TODO:
    //TODO:

    public void Freeze(){
        _pendingFreezeDuration = duration;
    }

    /* DoFreeze() will:
    * save default timeScale
    * set a flag for freezeframe status (on or off)
    * stop game time
    * wait in realtime for a duration
    * then
    *
    * reset everything back to normal time
    *
    *
    */

    IEnumerator DoFreeze(){
        var originalTimeScale = Time.timeScale; //save original timescale
        _isFrozen = true; //start freezeframes
        Time.timeScale = 0f; //set timescale to 0 (time doesn't move)

        yield return new WaitForSecondsRealtime(duration); //"end" coroutine

        //sets everything back to normal
        Time.timeScale = originalTimeScale;
        _pendingFreezeDuration = 0;
        _isFrozen = false;
    }



}
