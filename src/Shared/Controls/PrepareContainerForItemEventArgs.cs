//-----------------------------------------------------------------------
// <copyright file="PrepareContainerForItemEventArgs.cs" company="MyToolkit">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>http://mytoolkit.codeplex.com/license</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System;
#if !WINRT
using System.Windows;
#else
using Windows.UI.Xaml;
#endif

namespace MyToolkit.Controls
{
	public class PrepareContainerForItemEventArgs : EventArgs
	{
		public PrepareContainerForItemEventArgs(DependencyObject element, object item)
		{
			Element = element;
			Item = item;
		}

		public DependencyObject Element { get; private set; }
		public object Item { get; private set; }
	}
}