﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Reflection;
using GenerateJSModelFromSQL;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace GenerateJSModelFromSQL
{
    class Program
    {

        static void Main(string[] args)
        {
            StartForm();
        }

        static void StartForm()
        {
            Thread t = new Thread((ThreadStart)(() =>
            {
                MainForm mainForm = new MainForm();

                mainForm.settings = new clsSettings();

                System.Windows.Forms.Application.Run(mainForm);
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
                
        }
    }
}