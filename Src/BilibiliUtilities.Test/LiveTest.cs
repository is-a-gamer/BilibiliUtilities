using System;
using BilibiliUtilities.Live;
namespace BilibiliUtilities.Test
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("直播间房间号:");
            Start();
            Console.ReadLine();
        }

        private static async void Start()
        {
            var liveHandler = new LiveLib.LiveHandler();
            var sroomid = Console.ReadLine();
            var roomid = int.Parse(sroomid);
            //第一个参数是直播间的房间号
            //第二个参数是自己实现的处理器
            //第三个参数是可选的,可以是默认的消息分发器,也可以是自己实现的消息分发器
            LiveRoom room = new LiveRoom(roomid, liveHandler);
            //等待连接,该方法会反回是否连接成功
            //或者使用room.Connected,该属性会反馈连接状态
            if (!await room.ConnectAsync())
            {
                Console.WriteLine("连接失败");
                return;
            }
            Console.WriteLine("连接成功");
            Console.WriteLine("按回车结束");
            //消息由Dispatcher分发到对应的MessageHandler中对应方法
            await room.ReadMessageLoop();
        }
    }
}