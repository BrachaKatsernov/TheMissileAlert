﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for ImageWpf.xaml
    /// </summary>
    public partial class ImageWpf : Window
    {
        public ImageWpf()
        {
            InitializeComponent();
        }
        public ImageWpf(System.Windows.Media.ImageSource path)
        {
            InitializeComponent();
            this.mainImage.Source = path;
        }
    }
    
}
