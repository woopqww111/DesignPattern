﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;


 public  abstract class ICharacter
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


     protected ICharacterAttr mAttr;
     protected GameObject mGameObject;
     protected NavMeshAgent mNavMeshAgent;
     protected AudioSource mAudio;
     protected Animation mAnim;
    protected bool mIsKilled = false;
    protected bool mCanDestroy = false;
    protected float mDestroyTimer = 2;
     protected IWeapon mWeapon;

     public IWeapon Weapon
     {
         set
         {
             mWeapon = value;
            mWeapon.Owner = this;
            //Transform weaponPoint = mGameObject.transform.Find()
             GameObject child = UnityTool.FindChild(mGameObject, "weapon-point");
             UnityTool.Attach(child,mWeapon.GameObject);
         }
         get{
             return mWeapon;
         }
     }

     public float atkRange
     {
         get { return mWeapon.BaseAttr.AtkRange; }
     }
     public void Attack(ICharacter target)
     {
       mWeapon.Fire(target.Position);
        mGameObject.transform.LookAt(target.Position);
        PlayAnim("attack");
        target.UnderAttack(mWeapon.BaseAttr.Atk + mAttr.critValue);
     }

     public GameObject gameObject
     {
         set
         {
             mGameObject = value;
             mNavMeshAgent = mGameObject.GetComponent<NavMeshAgent>();
             mAudio = mGameObject.GetComponent<AudioSource>();
             mAnim = mGameObject.GetComponentInChildren<Animation>();
         }
         get{
             return mGameObject;
         }
     }

     public virtual void UnderAttack(int damage)
     {
         mAttr.TakeDamage(damage);
        //被攻击效果，，视效 只有敌人有

        //死亡 音效，视频特效，只有展示有

     }

     public virtual void Killed()
     {
         //TODO:
         mIsKilled = true;
        mNavMeshAgent.isStopped = true;

     }
     public void Release(){
         GameObject.Destroy(mGameObject);
     }
     public abstract void UpdateFSMAI(List<ICharacter> targets);
     public abstract void RunVisitor(ICharacterVisitor visitor);
     public void Update()
     {
         if(mIsKilled){
             mDestroyTimer-=Time.deltaTime;
             if(mDestroyTimer<=0){
                 mCanDestroy = true;
                 return;
             }
         }
         mWeapon.Update();
     }
     public void PlayAnim(string animName)
     {
         mAnim.CrossFade(animName);
     }
    public bool isKilled{
        get{
            return mIsKilled;
        }
    }
     public void MoveTo(Vector3 targetPosition)
     {
         mNavMeshAgent.SetDestination(targetPosition);
        PlayAnim("move");
     }
     protected void DoPlaySound(string soundName)
     {
         AudioClip clip = FactoryManager.AssetFactory.LoadAudioClip(soundName);
         mAudio.clip = clip;
         mAudio.Play();
     }
     protected void DoPlayEffect(string effectName)
     {
         //加载特效 TODO
         GameObject effectGO = FactoryManager.AssetFactory.LoadEffect(effectName);
         effectGO.transform.position = Position;
         //控制销毁 TODO
         effectGO.AddComponent<DestroyForTime>();

     }
    public bool CanDestroy{
        get{
            return mCanDestroy;
        }
    }
     public ICharacterAttr attr
     {
         set { mAttr = value; }
         get{
             return mAttr;
         }
     }
    public Vector3 Position
     {
         get
         {
            if (mGameObject == null)
             {
                 Debug.LogError("gameObject为空");
                return Vector3.zero;
             }
             return mGameObject.transform.position;

        }
    }
 
 }

