﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.IoC
{
    public sealed class Singleton<T> where T : class, new()
    {
        private static T instance;

        public static T Instance()
        {
            lock (typeof(T))
                if (instance == null) instance = new T();

            return instance;
        }
    }
}
