using System;
using LitJson;

namespace BilibiliUtilities.Live.Message
{
    public class WelcomeGuardMessage : BaseMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public long UserId;

        /// <summary>
        /// 
        /// </summary>
        public string Username;

        /// <summary>
        /// 
        /// </summary>
        public int GuardLevel;

        /// <summary>
        /// 
        /// </summary>
        public int MockEffect;

        public static WelcomeGuardMessage JsonToWelcomeGuardMessage(JsonData json)
        {
            return new WelcomeGuardMessage
            {
                UserId = long.Parse(json["data"]["uid"].ToString()),
                Username = json["data"]["username"].ToString(),
                GuardLevel = int.Parse(json["data"]["guard_level"].ToString()),
                MockEffect = int.Parse(json["data"]["mock_effect"].ToString()),
                Metadata = JsonMapper.ToJson(json)
            };
        }
        
        public static WelcomeGuardMessage JsonToWelcomeGuardMessage(string jsonStr)
        {
            try
            {
                var json = JsonMapper.ToObject(jsonStr);
                return JsonToWelcomeGuardMessage(json);
            }
            catch (Exception)
            {
                throw new AggregateException("JSON字符串没有成功转换成Json对象");
            }
        }
    }
}