﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public enum WeaponType
{
    Gun = 0,
    Rifle=1,
    Rocket =2,
    MAX
}

public    class IWeapon
{
     #region 常量
    #endregion
    #region  属性
    #endregion
    #region 字段
    #endregion
    #region 事件
    #endregion
    #region 方法
    #endregion
    #region Unity回调
    #endregion
    #region  事件回调
    #endregion
    #region 帮助方法
    #endregion
    protected WeaponBaseAttr mBaseAttr;
    //protected int mAtkPlusValue;
    protected GameObject mGameObject;

    protected ICharacter mOwner;

    protected ParticleSystem mParticleSystem;
    protected LineRenderer mLine;
    protected Light mLight;
    protected AudioSource mAudio;
    protected float mEffectDisplayTime = 0;

    public WeaponBaseAttr BaseAttr
    {
        get { return mBaseAttr; }
    }

    public ICharacter Owner
    {
        set { mOwner = value; }
    }

    public GameObject GameObject
    {
        get { return mGameObject; }
    }
    public IWeapon(WeaponBaseAttr baseAttr,  GameObject gameObject)
    {
        mBaseAttr = baseAttr;
        mGameObject = gameObject;
        Transform effect = mGameObject.transform.Find("Effect");
        mParticleSystem = effect.GetComponent<ParticleSystem>();
        mLine = effect.GetComponent<LineRenderer>();
        mLight = effect.GetComponent<Light>();
        mAudio = effect.GetComponent<AudioSource>();

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

    protected virtual void SetEffectDisplay() { }

    protected virtual void PlayMuzzleEffect()
    {
        //显示枪口特效
        mParticleSystem.Stop();
        mParticleSystem.Play();
        mLight.enabled = true;
    }

    protected virtual void PlayBulletEffect(Vector3 targetPosition) { }

    protected void DoPlayBulletEffect(Vector3 targetPosition, float width)
    {
        //显示子弹轨迹特效
        mLine.enabled = true;
        mLine.startWidth = width;
        mLine.endWidth = width;
        mLine.SetPosition(0, mGameObject.transform.position);
        mLine.SetPosition(1, targetPosition);
    }

    protected virtual void PlaySound() { }

    protected void DoPlaySound(string clipName)
    {
        AudioClip clip = FactoryManager.AssetFactory.LoadAudioClip(clipName);
        mAudio.clip = clip;
        mAudio.Play();
    }
}

