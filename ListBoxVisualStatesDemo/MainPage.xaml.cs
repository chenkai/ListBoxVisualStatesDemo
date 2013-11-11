using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Controls.Primitives;
using System.Collections;

namespace ListBoxVisualStatesDemo
{
    public partial class MainPage : PhoneApplicationPage
    {
        private TextBlock _activeTxb = null;
        private ScrollBar sb = null;
        private ScrollViewer sv = null;
        private bool _isBouncy = false;
        private bool alreadyHookedScrollEvents = false;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

        }        

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            if (alreadyHookedScrollEvents)
                return;

            alreadyHookedScrollEvents = true;
            MainListBox.AddHandler(ListBox.ManipulationCompletedEvent, (EventHandler<ManipulationCompletedEventArgs>)LB_ManipulationCompleted, true);

            sb = (ScrollBar)FindElementRecursive(MainListBox, typeof(ScrollBar));
            sv = (ScrollViewer)FindElementRecursive(MainListBox, typeof(ScrollViewer));

            if (sv != null)
            {
                // Visual States are always on the first child of the control template 
                FrameworkElement element = VisualTreeHelper.GetChild(sv, 0) as FrameworkElement;
                if (element != null)
                {
                    VisualStateGroup group = FindVisualState(element, "ScrollStates");
                    if (group != null)
                    {
                        group.CurrentStateChanging += new EventHandler<VisualStateChangedEventArgs>(group_CurrentStateChanging);
                    }
                    VisualStateGroup vgroup = FindVisualState(element, "VerticalCompression");
                    VisualStateGroup hgroup = FindVisualState(element, "HorizontalCompression");
                    if (vgroup != null)
                    {
                        vgroup.CurrentStateChanging += new EventHandler<VisualStateChangedEventArgs>(vgroup_CurrentStateChanging);
                    }
                    if (hgroup != null)
                    {
                        hgroup.CurrentStateChanging += new EventHandler<VisualStateChangedEventArgs>(hgroup_CurrentStateChanging);
                    }
                }
            }           

        }

        private void LB_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            if (_isBouncy)
            {
                ReleaseBounce();
            }
            //isScrollingTxb.Foreground = new SolidColorBrush(Colors.White);
            VCompressionTxb.Foreground = new SolidColorBrush(Colors.White);
            HCompressionTxb.Foreground = new SolidColorBrush(Colors.White);
        }
        private void hgroup_CurrentStateChanging(object sender, VisualStateChangedEventArgs e)
        {
            if (e.NewState.Name == "CompressionLeft")
            {
                ProcessBounce();
                HCompressionTxb.Foreground = new SolidColorBrush(Colors.White);
                LeftTxb.Foreground = new SolidColorBrush(Colors.Green);
            }

            if (e.NewState.Name == "CompressionRight")
            {
                ProcessBounce();
                HCompressionTxb.Foreground = new SolidColorBrush(Colors.White);
                RightTxb.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (e.NewState.Name == "NoHorizontalCompression")
            {
                ReleaseBounce();
                LeftTxb.Foreground = new SolidColorBrush(Colors.White);
                RightTxb.Foreground = new SolidColorBrush(Colors.White);
                HCompressionTxb.Foreground = new SolidColorBrush(Colors.Green);
            }
        }
        private void vgroup_CurrentStateChanging(object sender, VisualStateChangedEventArgs e)
        {
            if (e.NewState.Name == "CompressionTop")
            {
                ProcessBounce();
                VCompressionTxb.Foreground = new SolidColorBrush(Colors.White);
                TopTxb.Foreground = new SolidColorBrush(Colors.Green);
            }

            if (e.NewState.Name == "CompressionBottom")
            {
                ProcessBounce();
                VCompressionTxb.Foreground = new SolidColorBrush(Colors.White);
                BottomTxb.Foreground = new SolidColorBrush(Colors.Green);

                /*
                 * As an example, this is where you can add code to load new items, have the progress bar animation and so on
                 *                  
                 */
            }
            if (e.NewState.Name == "NoVerticalCompression")
            {
                ReleaseBounce();
                TopTxb.Foreground = new SolidColorBrush(Colors.White);
                BottomTxb.Foreground = new SolidColorBrush(Colors.White);
                VCompressionTxb.Foreground = new SolidColorBrush(Colors.Green);
            }
        }
        private void group_CurrentStateChanging(object sender, VisualStateChangedEventArgs e)
        {
            if (e.NewState.Name == "Scrolling")
            {
                isScrollingTxb.Foreground = new SolidColorBrush(Colors.Green);
                AnimateText(scrollStartedTxb);
            }
            else
            {
                isScrollingTxb.Foreground = new SolidColorBrush(Colors.White);
                AnimateText(scrollCompletedTxb);
            }
        }
        
        
        private void AnimateText(TextBlock target)
        {
            _activeTxb = target;
            AnimateTextSB.Stop();
            Storyboard.SetTargetName(FontAnimation, target.Name);
            Storyboard.SetTargetName(FontColorAnimation, target.Name);
            FontAnimation.AutoReverse = true;
            AnimateTextSB.Begin();
        }
        private void ReleaseBounce()
        {
            _isBouncy = false;
            isBouncyTxb.Foreground = new SolidColorBrush(Colors.White);
        }
        private void ProcessBounce()
        {
            _isBouncy = true;
            isBouncyTxb.Foreground = new SolidColorBrush(Colors.Green);
        }
        private UIElement FindElementRecursive(FrameworkElement parent, Type targetType)
        {
            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            UIElement returnElement = null;
            if (childCount > 0)
            {
                for (int i = 0; i < childCount; i++)
                {
                    Object element = VisualTreeHelper.GetChild(parent, i);
                    if (element.GetType() == targetType)
                    {
                        return element as UIElement;
                    }
                    else
                    {
                        returnElement = FindElementRecursive(VisualTreeHelper.GetChild(parent, i) as FrameworkElement, targetType);
                    }
                }
            }
            return returnElement;
        }
        private VisualStateGroup FindVisualState(FrameworkElement element, string name)
        {
            if (element == null)
                return null;

            IList groups = VisualStateManager.GetVisualStateGroups(element);
            foreach (VisualStateGroup group in groups)
                if (group.Name == name)
                    return group;

            return null;
        }
        private void AnimateTextSB_Completed(object sender, EventArgs e)
        {
            _activeTxb.FontSize = 30;
            _activeTxb.Foreground = new SolidColorBrush(Colors.White);
        }
    }
}