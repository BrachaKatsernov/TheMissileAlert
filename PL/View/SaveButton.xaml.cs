using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL
{
    public partial class SaveButton : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(String), typeof(SaveButton), new PropertyMetadata(default(String)));
        /// <summary>
        /// the text on the button
        /// </summary>
        public String Text
        {
            get { return (String)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof(String), typeof(SaveButton), new PropertyMetadata(default(String)));
 
        public String Icon
        {
            get { return (String)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
            "State", typeof(String), typeof(SaveButton), new PropertyMetadata(default(String)));

        public String State
        {
            get { return (String)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public new static readonly DependencyProperty StyleProperty = DependencyProperty.Register(
            "Style", typeof(object), typeof(SaveButton), new PropertyMetadata(default(object)));
    
        public new object Style
        {
            get { return (object)GetValue(StyleProperty); }
            set { SetValue(StyleProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", typeof(ICommand), typeof(SaveButton), new PropertyMetadata(default(ICommand)));
        /// <summary>
        /// the command
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
            "CommandParameter", typeof(object), typeof(SaveButton), new PropertyMetadata(default(object)));

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public event EventHandler ButtonClick;

        protected void Button_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            ButtonClick?.Invoke(this, e);
        }

        public SaveButton()
        {
            InitializeComponent();
            DataContext = this;

        }
    }
}
