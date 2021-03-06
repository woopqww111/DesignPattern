﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine;
public class SceneStateController
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
    private ISceneState mState;
    private AsyncOperation mAo;
    private bool mIsRunStart = false;
    public void SetState(ISceneState state,bool isLoadScene = true)
    {
        if (mState != null)
        {
            mState.StateEnd();//让上一个场景状态做一个清理工作
        }
        mState = state;
        if (isLoadScene)
        {
            mAo = SceneManager.LoadSceneAsync(mState.SceneName);
            mIsRunStart = false;
        }
        else
        {
            mState.StateStart();
            mIsRunStart = true;
        }
      

    }
    public void StateUpdate()
    {
        if (mAo!=null&&mAo.isDone== false) return;
        
        if (mIsRunStart == false &&mAo != null && mAo.isDone == true)
        {
            mState.StateStart();
            mIsRunStart = true;
        }
        if (mState != null)
        {
            mState.StateUpdate();
        }
    }
}

