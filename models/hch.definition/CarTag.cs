using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace hch.definition
{
    /// <summary>
    /// 车辆活动类型
    /// </summary>
    [Flags]
    public enum CarActivity
    {
        /// <summary>
        /// 无
        /// </summary>
        [Display(Description = "无")]
        None = 0,
        /// <summary>
        /// 急售
        /// </summary>
        [Display(Description = "急售")]
        Anxious = 1,
        /// <summary>
        /// 超值
        /// </summary>
        [Display(Description = "超值")]
        Supervalu = 2,
        /// <summary>
        /// 未上市
        /// </summary>
        [Display(Description = "活动车")]
        Event = 4,
        /// <summary>
        /// 未上市
        /// </summary>
        [Display(Description = "运损车")]
        Damaged = 8,
        /// <summary>
        /// 特价
        /// </summary>
        [Display(Description = "特价")]
        Special = 16,
    }
    /// <summary>
    /// 车辆销售情况
    /// </summary>
    [Flags]
    public enum CarSell
    {
        /// <summary>
        /// 在售
        /// </summary>
        [Display(Description = "在售")]
        Sale = 0,
        /// <summary>
        /// 下架
        /// </summary>
        [Display(Description = "下架")]
        Sold = 1,


    }

    /// <summary>
    /// 品牌类别、热门
    /// </summary>
    [Flags]
    public enum CarBrandType
    {
        /// <summary>
        /// 无
        /// </summary>
        [Display(Description = "无")]
        None = 0,
        /// <summary>
        /// 热门
        /// </summary>
        [Display(Description = "热门")]
        Hot = 1,
        /// <summary>
        /// 普通
        /// </summary>
        [Display(Description = "普通")]
        Ordinary = 2,


    }
    /// <summary>
    /// 车系级别
    /// </summary>
    [Flags]
    public enum CarSeriesGrade
    {
        /// <summary>
        /// 无
        /// </summary>
        [Display(Description = "无")]
        None = 0,
        /// <summary>
        /// 微型车
        /// </summary>
        [Display(Description = "微型车")]
        Miniature = 1,
        /// <summary>
        /// 小型车
        /// </summary>
        [Display(Description = "小型车")]
        Small = 2,
        /// <summary>
        /// 紧凑型车
        /// </summary>
        [Display(Description = "紧凑型车")]
        Compact = 4,
        /// <summary>
        /// 中型车
        /// </summary>
        [Display(Description = "中型车")]
        Middle = 8,
        /// <summary>
        /// 中大型车
        /// </summary>
        [Display(Description = "中大型车")]
        MiddleLarge = 16,
        /// <summary>
        /// 大型车
        /// </summary>
        [Display(Description = "大型车")]
        Large = 32,
        /// <summary>
        /// SUV
        /// </summary>
        [Display(Description = "SUV")]
        SUV = 64,
        /// <summary>
        /// MPV
        /// </summary>
        [Display(Description = "MPV")]
        MPV = 128,
        /// <summary>
        /// 跑车
        /// </summary>
        [Display(Description = "跑车")]
        SportsCar = 256,
        /// <summary>
        /// 皮卡
        /// </summary>
        [Display(Description = "皮卡")]
        Pickup = 512,
        /// <summary>
        /// 微面
        /// </summary>
        [Display(Description = "微面")]
        Minibus = 1024,
        /// <summary>
        /// 轻客
        /// </summary>
        [Display(Description = "轻客")]
        Coach = 2048,
    }
    /// <summary>
    /// 车辆能源
    /// </summary>
    [Flags]
    public enum CarEnergy
    {
        /// <summary>
        /// 无
        /// </summary>
        [Display(Description = "无")]
        None = 0,
        /// <summary>
        /// 汽油
        /// </summary>
        [Display(Description = "汽油")]
        Gasoline = 1,
        /// <summary>
        /// 柴油
        /// </summary>
        [Display(Description = "柴油")]
        Diesel = 2,
        /// <summary>
        /// 油电混合
        /// </summary>
        [Display(Description = "油电混合")]
        Hybrid = 4,
        /// <summary>
        /// 纯电动
        /// </summary纯电动
        [Display(Description = "纯电动")]
        Electric = 8,
        /// <summary>
        /// 插电式混动
        /// </summary>
        [Display(Description = "插电式混动")]
        PHEV = 16,
    }

    /// <summary>
    /// 车辆驱动
    /// </summary>
    [Flags]
    public enum CarDrive
    {
        /// <summary>
        /// 无
        /// </summary>
        [Display(Description = "无")]
        None = 0,
        /// <summary>
        /// 前驱
        /// </summary>
        [Display(Description = "前驱")]
        Precursor = 1,
        /// <summary>
        /// 后驱
        /// </summary>
        [Display(Description = "后驱")]
        Rear = 2,
        /// <summary>
        /// 四驱
        /// </summary>
        [Display(Description = "四驱")]
        Quattro = 4,

    }
    /// <summary>
    /// 车辆变速箱
    /// </summary>
    [Flags]
    public enum CarGearbox
    {
        /// <summary>
        /// 无
        /// </summary>
        [Display(Description = "无")]
        None = 0,
        /// <summary>
        /// 手动
        /// </summary>
        [Display(Description = "手动")]
        Precursor = 1,
        /// <summary>
        /// 自动
        /// </summary>
        [Display(Description = "自动")]
        Rear = 2,

    }

    /// <summary>
    /// 车辆座位
    /// </summary>
    [Flags]
    public enum CarSeat
    {
        /// <summary>
        /// 无
        /// </summary>
        [Display(Description = "无")]
        None = 0,
        /// <summary>
        /// 2座
        /// </summary>
        [Display(Description = "2座")]
        Two = 1,
        /// <summary>
        /// 4座
        /// </summary>
        [Display(Description = "4座")]
        Four = 2,
        /// <summary>
        /// 5座
        /// </summary>
        [Display(Description = "5座")]
        Five = 4,
        /// <summary>
        /// 6座
        /// </summary>
        [Display(Description = "6座")]
        Six = 8,
        /// <summary>
        /// 7座
        /// </summary>
        [Display(Description = "7座")]
        Seven = 16,
        /// <summary>
        /// 7座以上
        /// </summary>
        [Display(Description = "7座以上")]
        SevenAbove = 32,
    }
    /// <summary>
    /// 车辆配置
    /// </summary>
    [Flags]
    public enum CarConfiguration
    {
        /// <summary>
        /// 全景天窗
        /// </summary>
        [Display(Description = "全景天窗")]
        PanoramicSunroof = 0,
        /// <summary>
        /// 电动天窗
        /// </summary>
        [Display(Description = "电动天窗")]
        PowerSunroof = 1,
        /// <summary>
        /// 电动座椅
        /// </summary>
        [Display(Description = "电动座椅")]
        PowerSeat = 2,
        /// <summary>
        /// 环车影像
        /// </summary>
        [Display(Description = "环车影像")]
        PanoramaImage = 4,
        /// <summary>
        /// 氙气大灯
        /// </summary>
        [Display(Description = "氙气大灯")]
        XenonLight = 8,
        /// <summary>
        /// LED大灯
        /// </summary>
        [Display(Description = "LED大灯")]
        LEDLight = 16,
        /// <summary>
        /// GPS导航
        /// </summary>
        [Display(Description = "GPS导航")]
        GPS = 32,
        /// <summary>
        /// 定速巡航
        /// </summary>
        [Display(Description = "定速巡航")]
        CruiseControl = 64,
        /// <summary>
        /// 真皮座椅
        /// </summary>
        [Display(Description = "真皮座椅")]
        LeatherSeat = 128,
        /// <summary>
        /// 倒车雷达
        /// </summary>
        [Display(Description = "倒车雷达")]
        ParkingSensors = 256,
        /// <summary>
        /// 全自动空调
        /// </summary>
        [Display(Description = "全自动空调")]
        AutoAircon = 512,
        /// <summary>
        /// 多功能方向盘
        /// </summary>
        [Display(Description = "多功能方向盘")]
        MFL = 1024,
        /// <summary>
        /// 倒车影像
        /// </summary>
        [Display(Description = "倒车影像")]
        BackupCamera = 2048,
        /// <summary>
        /// 无钥匙启动
        /// </summary>
        [Display(Description = "无钥匙启动")]
        KeylessStart = 4096,
        /// <summary>
        /// 无钥匙进入
        /// </summary>
        [Display(Description = "无钥匙进入")]
        KeylessEntry = 8192,
        /// <summary>
        /// 座椅加热
        /// </summary>
        [Display(Description = "座椅加热")]
        SeatHeating = 16384,
        /// <summary>
        /// 日间行车灯
        /// </summary>
        [Display(Description = "日间行车灯")]
        DRL = 32768,
        /// <summary>
        /// 自动泊车
        /// </summary>
        [Display(Description = "自动泊车")]
        AutoPark = 65536,
        /// <summary>
        /// 蓝牙/车载电话
        /// </summary>
        [Display(Description = "蓝牙/车载电话")]
        BluetoothPhone = 131072,
        /// <summary>
        /// 胎压监测
        /// </summary>
        [Display(Description = "胎压监测")]
        TPMS = 262144,

    }

    /// <summary>
    /// 品牌国别
    /// </summary>
    [Flags]
    public enum CarBrandCountry
    {
        /// <summary>
        /// 无
        /// </summary>
        [Display(Description = "无")]
        None = 0,
        /// <summary>
        /// 德系
        /// </summary>
        [Display(Description = "德系")]
        Germany = 1,
        /// <summary>
        /// 日系
        /// </summary>
        [Display(Description = "日系")]
        Japanese = 2,
        /// <summary>
        /// 美系
        /// </summary>
        [Display(Description = "美系")]
        American = 4,
        /// <summary>
        /// 法系
        /// </summary>
        [Display(Description = "法系")]
        Frence = 8,
        /// <summary>
        /// 韩系
        /// </summary>
        [Display(Description = "韩系")]
        Korea = 16,
        /// <summary>
        /// 英系
        /// </summary>
        [Display(Description = "英系")]
        England = 32,
        /// <summary>
        /// 国产
        /// </summary>
        [Display(Description = "国产")]
        China = 64,
        /// <summary>
        /// 其他
        /// </summary>
        [Display(Description = "其他")]
        Other = 128,

    }

    /// <summary>
    /// 排放标准
    /// </summary>
    [Flags]
    public enum CarEmissionStandard
    {
        /// <summary>
        /// 无
        /// </summary>
        [Display(Description = "无")]
        None = 0,
        /// <summary>
        /// 国1
        /// </summary>
        [Display(Description = "国Ⅰ")]
        China1 = 1,
        /// <summary>
        ///国2
        /// </summary>
        [Display(Description = "国Ⅱ")]
        China2 = 2,
        /// <summary>
        /// 国3
        /// </summary>
        [Display(Description = "国Ⅲ")]
        China3 = 4,
        /// <summary>
        /// 国4
        /// </summary>
        [Display(Description = "国Ⅳ")]
        China4 = 8,
        /// <summary>
        /// 国5
        /// </summary>
        [Display(Description = "国Ⅴ")]
        China5 = 16,
        /// <summary>
        /// 其他
        /// </summary>
        [Display(Description = "其他")]
        Other = 32,
    }

}
