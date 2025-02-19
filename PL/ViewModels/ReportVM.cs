﻿using BE;
using com.sun.org.apache.regexp.@internal;
using PL.Commands;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.ViewModels
{
    public class ReportVM 
    {

        public ObservableCollection<Report> Reports { get; set; }
        public ManageFallReportModel CurrentModel { get; set; }
        public AddReportCommand Add { get; set; }
        public AssessmentAndlFallsVM AssessmentAndRealFalls { get; set; }

        public ReportVM()
        {
            AssessmentAndRealFalls = AssessmentAndlFallsVM.Instance;
            CurrentModel = new ManageFallReportModel();
            Reports = new ObservableCollection<Report>(CurrentModel.AllFallReports());
            Add = new AddReportCommand(this);
            Reports.CollectionChanged += Reports_CollectionChanged;
        }
        private void Reports_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                //add
                CurrentModel.AddFallReport(e.NewItems[0] as Report);
                AssessmentAndRealFalls.AddReport((e.NewItems[0] as Report).location);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                //remove
                var oldId = (e.OldItems[0] as Report).id;
                CurrentModel.RemoveFallReport(oldId);

            }

        }
        public void AddReport(Report report)
        {
            //tests
            if (report.reporterName == "" ||
                report.location == null ||
                report.intensity <= 0 || report.intensity > 10 ||
                report.numOfExplosions == 0 || report.time > DateTime.Now)
                return;

            
            Reports.Add(report);
            
        }

    }
}
