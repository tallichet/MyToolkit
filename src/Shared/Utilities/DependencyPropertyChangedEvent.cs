﻿//-----------------------------------------------------------------------
// <copyright file="DependencyPropertyChangedEvent.cs" company="MyToolkit">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>http://mytoolkit.codeplex.com/license</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System;

#if WINRT
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#else
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
#endif 

namespace MyToolkit.Utilities
{
    /// <summary>Provides methods to register to dependency property handler events. </summary>
	public static class DependencyPropertyChangedEvent
	{
		private static List<DependencyPropertyRegistration> _dependencyPropertyRegistrations;

        /// <summary>Registers an event callback on a given dependency property. </summary>
        /// <param name="frameworkElement">The source framework element. </param>
        /// <param name="property">The property to register the callback for. </param>
        /// <param name="handler">The event handler. </param>
		public static void Register(FrameworkElement frameworkElement, DependencyProperty property, Action<object, object> handler)
		{
			if (_dependencyPropertyRegistrations == null)
				_dependencyPropertyRegistrations = new List<DependencyPropertyRegistration>();

			var helper = new DependencyPropertyRegistration(
                frameworkElement, property, handler, frameworkElement.GetValue(property));
			
            var binding = new Binding();
			binding.Path = new PropertyPath("Property");
			binding.Source = helper;
			binding.Mode = BindingMode.TwoWay;
			
            frameworkElement.SetBinding(property, binding);
			
			_dependencyPropertyRegistrations.Add(helper);
		}

        /// <summary>Deregisters an event callback from a given dependency property. </summary>
        /// <param name="frameworkElement">The source framework element. </param>
        /// <param name="property">The property to register the callback for. </param>
        /// <param name="handler">The event handler. </param>
        public static void Deregister(FrameworkElement frameworkElement, DependencyProperty property, Action<object, object> handler)
		{
			var helper = _dependencyPropertyRegistrations
                .Single(h => 
                    h.FrameworkElement == frameworkElement && 
                    h.DependencyProperty == property && 
                    h.ChangedAction == handler);

			helper.ChangedAction = null; 
		}

        internal class DependencyPropertyRegistration
        {
            private object _currentValue;

            public DependencyPropertyRegistration(FrameworkElement frameworkElement, DependencyProperty dependencyProperty, Action<object, object> changedAction, object currentValue)
            {
                FrameworkElement = frameworkElement;
                DependencyProperty = dependencyProperty;
                ChangedAction = changedAction;

                _currentValue = currentValue;
            }

            public FrameworkElement FrameworkElement { get; private set; }
            public DependencyProperty DependencyProperty { get; private set; }
            public Action<object, object> ChangedAction { get; set; }

            public object Property
            {
                get { return _currentValue; }
                set
                {
                    if (ChangedAction != null)
                        ChangedAction(FrameworkElement, value);
                    _currentValue = value;
                }
            }
        }
	}
}