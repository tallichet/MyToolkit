﻿//-----------------------------------------------------------------------
// <copyright file="IDispatcher.cs" company="MyToolkit">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>http://mytoolkit.codeplex.com/license</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System;

namespace MyToolkit.Mvvm
{
    /// <summary>Interface for a UI dispatcher. </summary>
    public interface IDispatcher
    {
        /// <summary>Invokes an action on the dispatcher thread. </summary>
        /// <param name="action">The action. </param>
        void InvokeAsync(Action action);
    }
}