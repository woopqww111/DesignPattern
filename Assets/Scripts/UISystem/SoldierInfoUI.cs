﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

  public  class SoldierInfoUI:IBaseUI
    {
        private Image mSoldierIcon;
    private Text mSoldierName;
    private Text mHPText;
    private Slider mHPSlider;
    private Text mLv;
    private Text mAtk;
    private Text mAtkRange;
    private Text mMoveSpeed;
        public override void Init()
        {
            base.Init();
            GameObject canvas = GameObject.Find("Canvas");
            mRootUI = UnityTool.FindChild(canvas, "SoldierInfoUI");
        mSoldierIcon = UITool.FindChild<Image>(mRootUI, "SoldierIcon");
        mSoldierName = UITool.FindChild<Text>(mRootUI, "SoldierName");
        mHPText = UITool.FindChild<Text>(mRootUI, "HPNumber");
        mHPSlider = UITool.FindChild<Slider>(mRootUI, "HPSlider");
        mLv = UITool.FindChild<Text>(mRootUI, "Lv");
        mAtk = UITool.FindChild<Text>(mRootUI, "Atk");
        mAtkRange = UITool.FindChild<Text>(mRootUI, "AtkRange");
        mMoveSpeed = UITool.FindChild<Text>(mRootUI, "MoveSpeed");
        Hide();
        }
    }

