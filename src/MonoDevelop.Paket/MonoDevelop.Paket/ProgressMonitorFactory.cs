﻿//
// ProgressMonitorFactory.cs
//
// Author:
//       Matt Ward <ward.matt@gmail.com>
//
// Copyright (c) 2015 Matthew Ward
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
using MonoDevelop.Core;
using MonoDevelop.Core.Execution;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Core.ProgressMonitoring;

namespace MonoDevelop.Paket
{
	public class ProgressMonitorFactory
	{
		public ProgressMonitor CreateProgressMonitor (string title)
		{
			OutputProgressMonitor consoleMonitor = CreatePaketConsoleOutputMonitor ();

			Pad pad = IdeApp.Workbench.ProgressMonitors.GetPadForMonitor (consoleMonitor);

			ProgressMonitor statusMonitor = IdeApp.Workbench.ProgressMonitors.GetStatusProgressMonitor (
				title,
				Stock.StatusSolutionOperation,
				false,
				false,
				false,
				pad);

			return new AggregatedProgressMonitor (consoleMonitor, statusMonitor);
		}

		OutputProgressMonitor CreatePaketConsoleOutputMonitor ()
		{
			return IdeApp.Workbench.ProgressMonitors.GetOutputProgressMonitor (
				"PaketConsole",
				GettextCatalog.GetString ("Paket Console"),
				Stock.Console,
				false,
				true);
		}
	}
}

