using System;
using LitJson;

namespace BilibiliUtilities.Live.Message
{
    public class RoomRankMessage : BaseMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public int RoomId;

        /// <summary>
        /// 
        /// </summary>
        public string RankDesc;

        /// <summary>
        /// 
        /// </summary>
        public string Color;

        /// <summary>
        /// 给手机端用的URL
        /// </summary>
        public string H5Url;

        /// <summary>
        /// 给电脑端用的URL
        /// </summary>
        public string WebUrl;

        /// <summary>
        /// 排名信息的发布时间
        /// </summary>
        public DateTime Time;

        public static RoomRankMessage JsonToRoomRankMessage(JsonData json)
        {
            return new RoomRankMessage
            {
                RoomId = int.Parse(json["data"]["roomid"].ToString()),
                RankDesc = json["data"]["rank_desc"].ToString(),
                Color = json["data"]["red_notice"].ToString(),
                H5Url = json["data"]["h5_url"].ToString(),
                WebUrl = json["data"]["web_url"].ToString(),
                // Time = ,
                Metadata = JsonMapper.ToJson(json)
            };
        }

        public static RoomRankMessage JsonToRoomRankMessage(string jsonStr)
        {
            try
            {
                return JsonToRoomRankMessage(JsonMapper.ToObject(jsonStr));
            }
            catch (Exception)
            {
                throw new AggregateException("JSON字符串没有成功转换成Json对象");
            }
        }
    }
}