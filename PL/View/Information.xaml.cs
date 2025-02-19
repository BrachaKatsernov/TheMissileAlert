﻿using BE;
using com.sun.jdi;
using PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL
{
  
    public partial class Information : UserControl
    {
        public string fallLocation { get; set; }
        public string CalculatedLocation { get; set; }
        public int ReportsNumber { get; set; }
        public ReportVM CurrentReportVM { get; set; }
        public AssessmentVM CurrentFallPredictionVM { get; set; }
        public Information()
        {
            InitializeComponent();
            CurrentReportVM = new ReportVM();
            CurrentFallPredictionVM = new AssessmentVM();
            DataContext = this;
            fallLocation = "";
            CalculatedLocation = "";
            ReportsNumber = 0;
        }
        public Information(Fall CurrentFall)
        {
            InitializeComponent();
            CurrentReportVM = new ReportVM();
            CurrentFallPredictionVM = new AssessmentVM();
            Location_ Assessmentlocation = GetAssessmentLocationOfFall(CurrentFall);
            DataContext = this;
            fallLocation = CurrentFall.location.latitude.ToString() + " " + "," + " " + CurrentFall.location.longitude.ToString();
            CalculatedLocation = Assessmentlocation.latitude.ToString() + " " + "," + " " + Assessmentlocation.longitude.ToString();
            ReportsNumber = CalculateReportNumber(CurrentFall);
        }
        private int CalculateReportNumber(Fall CurrentFall)
        {
            List<Assessment> assessments = CurrentFallPredictionVM.Assessments.ToList();
            Assessment currentAssessment = (from a in assessments
                                            from f in a.Falls
                                            where f.id == CurrentFall.id
                                            select a).ToList()[0];//if null test


            return (currentAssessment.Reports.Count());

        }
        private Location_ GetAssessmentLocationOfFall(Fall CurrentFall)
        {
            List<Assessment> assessments = CurrentFallPredictionVM.Assessments.ToList();
            // List<Report> report = CurrentReportVM.Reports.ToList();
            List<Assessment> currentAssessment = (from a in assessments
                                                  from f in a.Falls
                                                  where f.id == CurrentFall.id
                                                  select a).ToList();
            if (currentAssessment.Count == 0)
            {
                return null;
            }

            GeoCoordinate location2 = new GeoCoordinate(CurrentFall.location.latitude, CurrentFall.location.longitude);
            double min = double.MaxValue;
            Location_ returnLocation = new Location_();
            
            foreach (Location_ location1 in currentAssessment[0].Locations)//getalllocation
            {
                double cur = new GeoCoordinate(location1.latitude, location1.longitude).GetDistanceTo(location2);
                if (cur < min)
                {
                    min = cur;
                    returnLocation = location1;
                }
            }
            return returnLocation;

        }
        public void Update(Fall CurrentFall)
        {
            CurrentReportVM = new ReportVM();
            CurrentFallPredictionVM = new AssessmentVM();
            Location_ assessmentLocation = GetAssessmentLocationOfFall(CurrentFall);
            DataContext = this;
            if (fallLocation != null)
                fallLocation = CurrentFall.location.latitude.ToString() + " " + "," + " " + CurrentFall.location.longitude.ToString();
            if (CalculatedLocation != "")
                CalculatedLocation = assessmentLocation.latitude.ToString() + " " + "," + " " + assessmentLocation.longitude.ToString();
            ReportsNumber = CalculateReportNumber(CurrentFall);

        }



    }
}
