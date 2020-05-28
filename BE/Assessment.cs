using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Device.Location;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Assessment : INotifyPropertyChanged
    {
        #region Properties
        private int Id;
        private DateTime Start;
        private DateTime End;
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Fall> Falls { get; set; }
        //  According to KMeans algorithm
        public virtual ICollection<Location_> Locations { get; set; }

        #endregion


        #region public get/set
        public int id
        {
            get
            {
                return Id;
            }
            set
            {
                if (Id != value)
                {
                    Id = value;
                    OnPropertyChanged("id");
                }
            }
        }
        public DateTime start
        {
            get
            {
                return Start;
            }
            set
            {
                if (Start != value)
                {
                    Start = value;
                    OnPropertyChanged("start");
                }
            }
        }
        public DateTime end
        {
            get
            {
                return End;
            }
            set
            {
                if (End != value)
                {
                    End = value;
                    OnPropertyChanged("end");
                }
            }
        }
        #endregion

        #region Constructor
        public Assessment(Report report)
        {
           // Start = new DateTime(report.time.Day, report.time.Hour, report.time.Minute);
            Start = new DateTime(report.time.Ticks);
            End = start.AddMinutes(10);
            Reports = new List<Report>();
            Reports.Add(report);
            Locations = new List<Location_>();
        }


        public Assessment()
        {
            Start = new DateTime();
            End = start.AddMinutes(10);
            Reports = new List<Report>();
            Locations = new List<Location_>();
        }
        #endregion
        
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
