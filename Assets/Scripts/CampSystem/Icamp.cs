﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Icamp {

    #region 常量
    #endregion
    #region  属性
        public int TrainCount{
            get{
                return mCommands.Count;
            }
        }
        
        
        public float TrainRemainingTime{
            get{
                return mTrainTimer;
            }
            
        }
        public string name{
            get{
                return mName;
            }
        }
        public string iconSprite{
            get{
                return mIconSprite;
            }
        }
        public SoldierType soldierType{
            get{
                return mSoldierType;
            }
        }
        public Vector3 Position{
            get{
                return mPosition;
            }
        }
        public float TrainTime{
            get{
                return mTrainTime;
            }
        }
        public abstract int lv{
            get;
        }
        public abstract WeaponType WeaponType{
            get;
        }
        public abstract int EnergyCostCampUpgrade{get;}
        public abstract int EnergyCostWeaponUpgrade{get;}
        public abstract int EnergyCostTrain{get;}
    #endregion
    #region 字段
        protected GameObject mGameObject;
        protected string mName;
        protected string mIconSprite;
        protected SoldierType mSoldierType;
        protected Vector3 mPosition;//集合点
        protected float mTrainTime;
        public List<ITrainCommand> mCommands;
        private float mTrainTimer = 0;
        protected int mEnergyCostCampUpgrade;
        protected int mEnergyCostWeaponUpgrade;
        protected int mEnergyCostTrain;
        protected IEnergyCostStrategy energyCostStrategy;
    #endregion
    #region 事件
    #endregion
    #region 方法
        public Icamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 position, float trainTime)
        {
            mGameObject = gameObject;
            mName = name;
            mIconSprite = icon;
            mSoldierType = soldierType;
            mPosition = position;
            mTrainTime = trainTime;
            mCommands = new List<ITrainCommand>();
            mTrainTimer = mTrainTime;
        
        }
        public virtual void Update(){
            UpdateCommand();
        }
        public void UpdateCommand(){
            if(mCommands.Count<=0){
                return;
            }
            mTrainTimer-=Time.deltaTime;
            if(mTrainTimer<=0){
                mCommands[0].Execute();
                mCommands.RemoveAt(0);
                mTrainTimer = mTrainTime;
            }
        }
        protected abstract void UpdateEnergyCost();
        public abstract void UpgradeCamp();
        public abstract void UpgradeWeapon();
        public abstract void Train();
        public  void Cancel(){
            if(mCommands.Count>0){
                mCommands.RemoveAt(mCommands.Count-1);       
                if(mCommands.Count==0){
                    mTrainTimer = mTrainTime;
                }
            }
        }
    #endregion
    #region Unity回调
    #endregion
    #region  事件回调
    #endregion
    #region 帮助方法
    #endregion
    

    
    
   
}
