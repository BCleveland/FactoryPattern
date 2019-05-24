using FactoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FactoryPattern
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ObservableCollection<WindowData> windowDatas = new ObservableCollection<WindowData>();
		private int currIndex = -1;

		public MainWindow()
		{
			InitializeComponent();
		}

		private WindowData InputWindowData()
		{
			WindowData newData = new WindowData();
			newData.ElementType = ComboboxType.Text;
			newData.ContentText = TextboxContent.Text;

			int numberData;
			Int32.TryParse(TextboxHeight.Text, out numberData);
			newData.HeightLength = numberData;

			Int32.TryParse(TextboxWidth.Text, out numberData);
			newData.WidthLength = numberData;

			Int32.TryParse(TextboxTop.Text, out numberData);
			newData.TopPosition = numberData;

			Int32.TryParse(TextboxLeft.Text, out numberData);
			newData.LeftPosition = numberData;

			return newData;
		}

		private void Add_Click(object sender, RoutedEventArgs e)
		{
			windowDatas.Add(InputWindowData());
			currIndex++;
			ListboxMain.ItemsSource = windowDatas;
		}

		private void Undo_Click(object sender, RoutedEventArgs e)
		{
			if (currIndex != -1)
			{
				windowDatas.RemoveAt(currIndex);
				currIndex--;
				ListboxMain.Items.Refresh();
			}
		}

		private void Build_Click(object sender, RoutedEventArgs e)
		{
			ExportFactory.Export(ComboLanguage.SelectionBoxItem.ToString(), windowDatas.ToList());
		}
	}
}
