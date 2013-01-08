﻿//-------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Author: Ian Davis (ian@innovatian.com)
//
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   you may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace WindowsTimeService
{
    using System;
    using System.Reflection;
    using Ninject;

    /// <summary>
    /// The application main.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main()
        {
#if SERVICE
            var ServicesToRun = new System.ServiceProcess.ServiceBase[]
                                {
                                    kernel.Get<WindowsTimeService>()
                                };
            System.ServiceProcess.ServiceBase.Run( ServicesToRun );
#else
            var service = new WindowsTimeService();
            try
            {
                service.Start(new string[] { });
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
            finally
            {
                service.Stop();
            }
#endif
        }
    }
}