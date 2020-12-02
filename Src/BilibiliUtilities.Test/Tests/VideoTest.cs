using System;
using BilibiliUtilities.Utils.CentralUtils;
using Xunit;

namespace BilibiliUtilities.Test.Tests
{
    public class VideoTest
    {
        [Fact]
        public static async void TestAvToBv()
        {
            var BvId = await VideoUtil.AvToBv(170001);
            Console.WriteLine(BvId);
        }

        [Fact]
        public static async void TestBvToAv()
        {
            var AvId = await VideoUtil.BvToAv("BV17x411w7KC");
            Console.WriteLine(AvId);
        }
    }
}