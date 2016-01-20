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
using WordsCounter.Utils;

namespace WordsCounter.Controls
{
	/// <summary>
	/// Lógica de interacción para CounterItem.xaml
	/// </summary>
	public partial class CounterItem : UserControl
	{
		public CounterItem()
		{
			InitializeComponent();

			InputText.KeyUp += InputText_KeyUp;
		}

		void InputText_KeyUp(object sender, KeyEventArgs e)
		{
			OutputText.Text = string.Empty;
			var counter = new Counter();
			var wordsAppearences = counter.CountWords(InputText.Text);

			foreach (var word in wordsAppearences)
			{
				OutputText.Text = string.Format("{0} {1} \n", OutputText.Text, word);
			}
		}
	}
}