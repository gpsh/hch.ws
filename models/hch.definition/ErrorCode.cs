using System;
using System.Collections.Generic;
using System.Text;

namespace hch.definition
{
    public static class ErrorCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        public static int OK = 0;

        #region -5100 ~ -5199 方法调用/参数错误
        /// <summary>
        /// 方法调用失败
        /// </summary>
        public static int FAILED_CALL = -5100;
        /// <summary>
        /// 参数为空
        /// </summary>
        public static int PARAM_NULL = -5101;
        /// <summary>
        /// 参数无效
        /// </summary>
        public static int PARAM_INVALID = -5102;
        /// <summary>
        /// 非法请求
        /// </summary>
        public static int INVALID_REQUEST = -5103;
        /// <summary>
        /// 权限不足
        /// </summary>
        public static int PERMISSION_DENIED = -5104;
        #endregion

        #region -5200 ~ -5299 数据库错误
        /// <summary>
        /// 数据库未连接
        /// </summary>
        public static int DB_NOTCONNECTED = -5200;
        /// <summary>
        /// 数据库操作超时
        /// </summary>
        public static int DB_TIMEOUT = -5201;
        /// <summary>
        /// 数据库保存错误
        /// </summary>
        public static int DB_SAVE_FAILED = -5202;
        /// <summary>
        /// 数据已存在
        /// </summary>
        public static int DB_EXISTED = -5203;
        /// <summary>
        /// 数据不存在
        /// </summary>
        public static int DB_NOTEXISTED = -5204;
        /// <summary>
        /// 数据库事务执行失败
        /// </summary>
        public static int DB_TRANSACTION_FAIL = -5205;
        /// <summary>
        /// 删除失败
        /// </summary>
        public static int DB_DELETE_FAIL = -5206;
        #endregion

        #region -5400~-5499 文件系统错误
        /// <summary>
        /// 文件上传配置路径错误
        /// </summary>
        public static int FILE_CONFIG_PATH_ERROR = -5400;
        /// <summary>
        /// 文件上传配置更新错误
        /// </summary>
        public static int FILE_CONFIG_UPDATE_ERROR = -5401;
        /// <summary>
        /// 文件上传配置保存失败
        /// </summary>
        public static int FILE_CONFIG_SAVE_ERROR = -5402;
        /// <summary>
        /// 出现异常
        /// </summary>
        public static int FILE_EXCEPTION = -5403;
        /// <summary>
        /// 图片的base64码为空
        /// </summary>
        public static int FILE_BASE64_NULL = -5404;
        /// <summary>
        /// 文件的名称为空
        /// </summary>
        public static int FILE_NAME_NULL = -5405;
        /// <summary>
        /// 文件不存在
        /// </summary>
        public static int FILE_NOTEXISTED = -5406;
        /// <summary>
        /// 文件保存失败
        /// </summary>
        public static int FILE_SAVE_FILED = -5407;
        #endregion

        #region -5500~-5599 用户信息错误

        /// <summary>
        /// 用户未审核
        /// </summary>
        public static int USER_UNCHECK = -5500;

        /// <summary>
        /// 用户不可用、禁用
        /// </summary>
        public static int USER_DISABLE = -5501;

        #endregion
    }
}
