﻿using AllPet.Pipeline;
using SimpleDb.Common.Message;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SimpleDb.Server.Actor
{
    public class PutUInt64Actor : Module
    {
        public PutUInt64Actor() : base(false)
        {
        }
        public override void OnStart()
        {
        }
        public override void OnTell(IModulePipeline from, byte[] data)
        {
            Console.WriteLine("Remote :PutUInt64Actor");
            MemoryStream mStream = new MemoryStream();
            mStream.Write(data, 0, data.Length);
            mStream.Flush();
            mStream.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            if (mStream.Capacity > 0)
            {
                PutUInt64Command command = (PutUInt64Command)bf.Deserialize(mStream);
                ServerDomain domain = new ServerDomain();
                domain.ExcuteCommand(command);
                domain.Dispose();
            }
        }
    }
}
