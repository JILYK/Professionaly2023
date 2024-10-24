using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System;



public class VideoFunction : MonoBehaviour
{
    public VideoClip oneVideo;
    public VideoClip twoVideo;
    public VideoClip threVideo;
    public VideoClip fourVideo;

    public VideoPlayer VideoThis;
    public bool StartVideo;
    private int Counter;
    public IEnumerator ProverkaVideoValue()
    {
        //print(VideoThis.frame + " ---> " + VideoThis.frameCount);
        if (Convert.ToInt32(VideoThis.frame) == Convert.ToInt32(VideoThis.frameCount))
        {
            //print("Next");
            ClickContent(Counter++);

        }
            yield return null;
    }
    public void ClickideoStart()
    {
        if (StartVideo)
        {
            return;
        }
        if (!StartVideo)
        {
        //print("Start");
            StartVideo = true;
            VideoThis.enabled = true;
            StartCoroutine(ProverkaVideoValue());
        }
    }
    public void ClickVideoEnd()
    {
        if (StartVideo)
        {
        VideoThis.frame = Convert.ToInt32(VideoThis.frameCount / 100 * 99);
        }
    }
    public void ClickContent(int Count)
    {
        Counter = Count;
            //print("912212121221%");
        if (Convert.ToInt32(VideoThis.frame) > Convert.ToInt32(VideoThis.frameCount / 100 * 90))
        {
            //print("90%");
        switch (Count)
        {
            case (1):
                ClickOneVideo();
                break;
            case (2):
                ClickTwoVideo();
                break;
            case (3):
                ClickThreeVideo();
                break;
            case (4):
                ClickFourVideo();
                break;
        }
        }

    }
    public void ClickOneVideo()
    {
        VideoThis.clip = oneVideo;
    }
    public void ClickTwoVideo()
    {
        VideoThis.clip = twoVideo;
    }
    public void ClickThreeVideo()
    {
        VideoThis.clip = threVideo;
    }
    public void ClickFourVideo()
    {
        VideoThis.clip = fourVideo;
    }
}
