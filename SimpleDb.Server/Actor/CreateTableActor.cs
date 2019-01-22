﻿using AllPet.Pipeline;
using Newtonsoft.Json;
using SimpleDb.Common;
using SimpleDb.Common.Message;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SimpleDb.Server.Actor
{
    public class CreateTableActor : Pipeline
    {
        public CreateTableActor(IPipelineSystem system) : base(system)
        {
        }
        public override void OnTell(IPipelineRef from, byte[] data)
        {
            Console.WriteLine("Remote :CreateTableActor");
            
            //var message = ConvertMessage.ConvertMessageObj(data, Method.CreateTable);
            MemoryStream mStream = new MemoryStream();            
            mStream.Write(data, 0, data.Length);
            mStream.Flush();
            mStream.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            if (mStream.Capacity > 0)
            {
                CreatTableCommand command = (CreatTableCommand)bf.Deserialize(mStream);
                ServerDomain domain = new ServerDomain();
                domain.ExcuteCommand(command);
                domain.Dispose();
            }
            
        }
    }
}