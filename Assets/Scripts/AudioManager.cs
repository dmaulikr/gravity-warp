﻿using UnityEngine;

public class AudioManager : MonoBehaviour
{

    /* Player Audio */
    public AudioClip[] landClip = new AudioClip[3];
    public AudioClip[] footsteps = new AudioClip[3];
    public AudioClip sliding;

    /* Box Audio */
    public AudioClip[] metalClips = new AudioClip[3];
    public AudioClip[] woodClips = new AudioClip[3];
    public AudioClip boxCrush;    

    /* Glue Audio */
    public AudioClip splat;

    /* Door Audio */
    public AudioClip door;

    /* Button Audio */
    public AudioClip toggleOn;
    public AudioClip toggleOff;
    public AudioClip release;

    /* Lever Change */
    public AudioClip change;
    public AudioClip spikeKill;
    public AudioClip laserKill;
    
    public AudioClip GetLanding()
    {
        return landClip[Random.Range(0, landClip.Length)];
    }

    public AudioClip GetFootstep()
    {
        return footsteps[Random.Range(0, footsteps.Length)];
    }

    public AudioClip GetBoxHit(bool b)
    {
        if (b)
        {
            return metalClips[Random.Range(0, metalClips.Length)];
        }
        return woodClips[Random.Range(0, woodClips.Length)];
    }

    public AudioClip GetBoxSlide()
    {
        return sliding;
    }

    public AudioClip GetGlueSplat()
    {
        return splat;
    }

    public AudioClip GetDoorClip()
    {
        return door;
    }

    public AudioClip GetButtonToggle(bool b)
    {
        if (b)
        {
            return toggleOn;
        }
        return toggleOff;
    }

    public AudioClip GetButton()
    {
        return release;
    }

    public AudioClip GetLeverChange()
    {
        return release;
    }

    public AudioClip GetBoxCrush()
    {
        return boxCrush;
    }

    public AudioClip GetSpikeKill()
    {
        return spikeKill;
    }

    public AudioClip GetLaserKill()
    {
        return laserKill;
    }
}
