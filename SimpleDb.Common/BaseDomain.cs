﻿using System;
using AllPet.db.simple;

namespace SimpleDb.Common
{
    public class BaseDomain
    {
        public BaseDomain()
        {
            
        }

        protected void ApplyChange(ICommand command)
        {
            dynamic d = this;

            d.Handle(Converter.ChangeTo(command, command.GetType()));
        }
    }
}
