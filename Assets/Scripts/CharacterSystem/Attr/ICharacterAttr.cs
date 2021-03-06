﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


 public   class ICharacterAttr
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
     protected CharacterBaseAttr mBaseAttr;

        protected int mCurrentHP;
        protected int mLv;
        protected int mDmgDescValue;

        public ICharacterAttr(IAttrStrategy strategy,int lv,CharacterBaseAttr baseAttr)
        {
            mLv = lv;
            mBaseAttr = baseAttr;
        mStrategy = strategy;
        mDmgDescValue = mStrategy.GetCritDmg(mLv);
            mCurrentHP = baseAttr.MaxHP + mStrategy.GetExtralHPValue(mLv);
            
        }
    //增加的最大血量，抵御的伤害值，暴击增加的伤害
        protected IAttrStrategy mStrategy;

        public int critValue
        {
            get { return mStrategy.GetCritDmg(mBaseAttr.CritRate); }
        }

        public int currentHP
        {
            get { return mCurrentHP; }
        }
        public IAttrStrategy Strategy{
            get{
                return mStrategy;
            }
        }

        public CharacterBaseAttr baseAttr{
            get{
                return mBaseAttr;
            }
        }
        public void TakeDamage(int damage)
        {

            damage -= mDmgDescValue;
            if (damage < 5)
                damage = 5;
            mCurrentHP -= damage;
        }
    }

