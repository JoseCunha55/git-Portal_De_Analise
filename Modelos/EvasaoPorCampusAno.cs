using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class EvasaoPorCampusAno:INotifyPropertyChanged
    {
        [DataMember]
        public string Campus { get; set; }
        [DataMember]
        public int Ano { get; set; }
        [DataMember]
        public string Situacao { get; set; }
        [DataMember]
        public int Total_Situacao { get; set; }
        [DataMember]
        public int Total_Aluno { get; set; }
        [DataMember]
        public Decimal Percentual { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}