﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class ObjTurmaDS
    {
        [DataMember]
        public string TurmaDS { get; set; }
    }
}