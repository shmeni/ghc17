﻿using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_Qualification
{
    public class Rides : IndexedObject
    {
        public Rides(int index) : base(index)
        {
        }

        public int StartTime { get; set; }

        public Coordinate Start {get; set;}

        public Coordinate End { get; set;}
    }
}