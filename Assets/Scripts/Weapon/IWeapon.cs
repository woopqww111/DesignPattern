﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public abstract   class IWeapon
{
    protected int mAtk;
    protected float mAtkRange;
    protected int mAtkPlusValue;
    protected GameObject mGameObject;

    protected ICharacter mOwner;

    protected ParticleSystem mParticleSystem;
    protected LineRenderer mLine;
    protected Light mLight;
    protected AudioSource mAudio;
    protected float mEffectDisplayTime = 0;

    public float atkRange
    {
        get { return mAtkRange; }
    }
    public void Update()
    {
        if (mEffectDisplayTime > 0)
        {
            mEffectDisplayTime -= Time.deltaTime;
            if (mEffectDisplayTime <= 0)
            {
                DisableEffect();
            }
        }
    }

    private void DisableEffect()
    {
        mLine.enabled = false;
        mLight.enabled = false;
    }

    public  void Fire(Vector3 targetPosition)
    {
       PlayMuzzleEffect();
       PlayBulletEffect(targetPosition);
        //设置特效显示时间
        SetEffectDisplay();
        //播放声音
        PlaySound();
        
    }

    protected abstract void SetEffectDisplay();

    protected virtual void PlayMuzzleEffect()
    {
        //显示枪口特效
        mParticleSystem.Stop();
        mParticleSystem.Play();
        mLight.enabled = true;
    }

    protected abstract void PlayBulletEffect(Vector3 targetPosition);

    protected void DoPlayBulletEffect(Vector3 targetPosition, float width)
    {
        //显示子弹轨迹特效
        mLine.enabled = true;
        mLine.startWidth = width;
        mLine.endWidth = width;
        mLine.SetPosition(0, mGameObject.transform.position);
        mLine.SetPosition(1, targetPosition);
    }

    protected abstract void PlaySound();

    protected void DoPlaySound(string clipName)
    {
        AudioClip clip = null;//TODO
        mAudio.clip = clip;
        mAudio.Play();
    }
}
