﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarTech.ELife.Base
{
    public class BuildingModel
    {
        //小区、大厦基础表
        public BuildingModel()
        { }
        #region Model
        private string _building_id;
        private string _building_name;
        private string _area_id;
        private string _map_x;
        private string _map_y;
        private int? _orderby;
        private string _addressdetail;
        /// <summary>
        /// 小区编号（8位唯一编号组成，非自增）
        /// </summary>
        public string Building_id
        {
            set { _building_id = value; }
            get { return _building_id; }
        }
        /// <summary>
        /// 小区名称
        /// </summary>
        public string Building_name
        {
            set { _building_name = value; }
            get { return _building_name; }
        }
        /// <summary>
        /// 所属区域编号
        /// </summary>
        public string Area_id
        {
            set { _area_id = value; }
            get { return _area_id; }
        }
        /// <summary>
        /// X轴坐标（经度）
        /// </summary>
        public string Map_x
        {
            set { _map_x = value; }
            get { return _map_x; }
        }
        /// <summary>
        /// Y轴坐标（纬度）
        /// </summary>
        public string Map_y
        {
            set { _map_y = value; }
            get { return _map_y; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? orderby
        {
            set { _orderby = value; }
            get { return _orderby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AddressDetail
        {
            set { _addressdetail = value; }
            get { return _addressdetail; }
        }
        #endregion Model

    }
}
