﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


 public   class SoldierCaptain:ISoldier
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
        protected override void PlayEffect()
        {
           DoPlayEffect("CaptainDeadEffect");
        }

        protected override void PlaySound()
        {
            DoPlaySound("CaptainDeath");
        }
    }

