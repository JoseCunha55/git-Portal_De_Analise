using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class EvasaoCursoAno:INotifyPropertyChanged
    {
        [DataMember]
        public int Ano { get; set; }

        private string curso;
        [DataMember]
        public string Curso
        {
            get { return curso; }
            set
            {
                curso = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Curso"));
            }
        }
            
        [DataMember]
        public int Evadidos { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
