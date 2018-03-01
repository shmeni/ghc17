﻿using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_Qualification
{
    public class Car : IndexedObject
    {
        public Car(int index) : base(index)
        {
        }

        public bool IsOnRide { get; set; }

        public List<Ride> RidesTaken { get; set; }
    }
}