using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace car_management.Tools
{
	public class ErrorPopupManager
	{
		// SINGLETON

		public static ErrorPopupManager Instance
		{
			get
			{
				if (instance == null)
					instance = new ErrorPopupManager();
				return instance;
			}
		}

		private static ErrorPopupManager instance = null;



		// PROPERTIES

		public Popup Popup { get; set; }


		// METHODS


		public void ShowPopup(string text, FrameworkElement parent)
		{
			if (Popup == null)
			{
                return;
			}

			TextBlock errorPopupText = Popup.FindName("PART_Text") as TextBlock;
			if (errorPopupText == null)
				throw new InvalidOperationException("No textblock found in error popup!");

			Binding parentBinding = new Binding();
			parentBinding.Source = parent;
			Popup.SetBinding(Popup.PlacementTargetProperty, parentBinding);

			Binding widthBinding = new Binding("ActualWidth");
			widthBinding.Source = parent;
			Popup.SetBinding(Popup.HorizontalOffsetProperty, widthBinding);


			errorPopupText.Text = text;

			Popup.IsOpen = true;
			Popup.StaysOpen = false;
		}

	    
		public void HidePopup ()
		{
			if (Popup == null)
			{
			    return;
			}
			Popup.IsOpen = false;
		}
	}
}
