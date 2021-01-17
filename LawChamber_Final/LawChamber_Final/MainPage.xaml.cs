using LawChamber_Final.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LawChamber_Final
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        CaseRepsitory repo;
        public MainPage()
        {
            this.InitializeComponent();
            this.cType.ItemsSource =
                new List<string> { "Civil", "Criminal", "Appeal", "Writ" };
            repo = new CaseRepsitory();
            this.DataContext = repo;
        }
    private void Next_Click(object sender, RoutedEventArgs e)
    {
        this.repo.Next();
    }

    private void First_Click(object sender, RoutedEventArgs e)
    {
        this.repo.First();

    }

    private void Prev_Click(object sender, RoutedEventArgs e)
    {
        this.repo.Previous();
    }

    private void Last_Click(object sender, RoutedEventArgs e)
    {
        this.repo.Last();
    }

    private void Edit_Click(object sender, RoutedEventArgs e)
    {
        this.repo.BeginEdit();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        this.repo.Cancel();
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        this.repo.AddNew();
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        this.repo.Save();
    }
}
}
