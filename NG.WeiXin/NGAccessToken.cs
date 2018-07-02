﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NG.WeiXin
{
    /// <summary>
    ///NGAccessToken 的摘要说明
    /// </summary>
    public class NGAccessToken
    {
        public NGAccessToken()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        string _access_token;
        string _expires_in;

        /// <summary>  
        /// 获取到的凭证   
        /// </summary>  
        public string access_token
        {
            get { return _access_token; }
            set { _access_token = value; }
        }

        /// <summary>  
        /// 凭证有效时间，单位：秒  
        /// </summary>  
        public string expires_in
        {
            get { return _expires_in; }
            set { _expires_in = value; }
        }
    }
}