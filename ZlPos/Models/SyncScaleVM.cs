﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZlPos.Models
{
    public class SyncScaleVM
    {
        public string ip { get; set; }
        public List<PluMessageEntity> pluMessageEntityList { get; set; }
        public int clean { get; set; }
        //add 2018年10月18日
        public string brand { get; set; }

    }
}
