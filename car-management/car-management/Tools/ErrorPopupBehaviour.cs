using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace car_management.Common.Tools
{
	public static class ErrorPopupBehaviour
	{
		public static void SetErrorMessage(FrameworkElement elem, string value)
		{
			elem.SetValue(ErrorMessageProperty, value);
		}
        
		public static bool GetErrorMessage(FrameworkElement elem)
		{
			return (bool)elem.GetValue(ErrorMessageProperty);
		}

		/// <summary>
		/// Property which has to be bound to the ErrorMessage from the ViewModel. Set to empty string or null to hide Message
		/// </summary>
		public static readonly DependencyProperty ErrorMessageProperty =
			DependencyProperty.RegisterAttached("ErrorMessage", typeof(string), typeof(ErrorPopupBehaviour), new UIPropertyMetadata(null, OnPropChanged));

        
		private static void OnPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			string message = e.NewValue as string;
			if (!String.IsNullOrEmpty(message))
				ErrorPopupManager.Instance.ShowPopup(message, d as FrameworkElement);
			else
				ErrorPopupManager.Instance.HidePopup();
		}
	}
}
