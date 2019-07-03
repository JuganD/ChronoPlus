﻿using System.Net.Http;

namespace ChronoPlus.Console
{
    public class Program
    {
        private static readonly HttpClient Client = new HttpClient();

        public static void Main(string[] args)
        {
            var controller = new ChronoControl();
            var info = controller.CheckUser();

            //System.Console.WriteLine(info.Chest.RewardValue + info.Chest.RewardBonus);
            //System.Console.WriteLine(info.Quest.RewardValue + info.Chest.RewardBonus);
            //Console.WriteLine(controller.HttpContext.Model.CoinSpinModel().QuestName);
            System.Console.WriteLine(controller.HttpContext.Response.ToString());
            var jsonResponse = controller.HttpContext.JsonResponse;
            System.Console.WriteLine(controller.ResponseResult);


            //var testString =
            //"{\"quest\":{\"_id\":-1,\"name\":\"default\",\"earns\":\"coins\",\"kind\":\"daily\",\"value\":20,\"bonus\":6},\"chest\":{\"base\":125,\"bonus\":31,\"kind\":3}}";


            //{"quest":{"_id":-1,"name":"default","earns":"coins","kind":"daily","value":20,"bonus":6},"chest":{}}
        }
    }
}