﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DomainModel;
using DataTransferObject;
using System.Globalization;
using System.Windows;
using System.Configuration;

namespace Client
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public MainForm()
        {
            InitializeComponent();
        }

        private void testBarButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            var formSets = new ClientsForms.ClientsSetupForm();
            formSets.ShowDialog();
        }

        private void testeesBarButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            TesteesListForm f = new TesteesListForm();
            FormManager.Instance.OpenChildForm(f, "Testees");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ProvideAccessToMenuItems();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }

        private void trainingsBarButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            TrainingsListForm.TrainingListForm trainingsform = new TrainingsListForm.TrainingListForm();
            FormManager.Instance.OpenChildForm(trainingsform, "Trainings");
            FormManager.childForms.Add(trainingsform);
        }

        private void loginBarButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new ClientsForms.LoginForm.UserLoginForm();
            f.ShowDialog();
        }

        private void questionBarButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new QuestionForm(new TesteeDTO() { Id = Guid.NewGuid() });
            f.ShowDialog();
        }

        private void Localized(string language) 
        {
            var resources = new ComponentResourceManager(typeof(MainForm));
            CultureInfo newCultureInfo = new CultureInfo(language);
            resources.ApplyResources(testeesBarButton, "testeesBarButton", newCultureInfo);
            resources.ApplyResources(trainingsBarButton, "trainingsBarButton", newCultureInfo);
            resources.ApplyResources(settingsBarButton, "settingsBarButton", newCultureInfo);
            resources.ApplyResources(languageBarSubItem, "languageBarSubItem", newCultureInfo);
            resources.ApplyResources(russianBarButtonItem, "russianBarButtonItem", newCultureInfo);
            resources.ApplyResources(englishBarButtonItem, "englishBarButtonItem", newCultureInfo);
        }

        private void russianBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormManager.Instance.LocalizedForms("ru-RU");
            Localized("ru-RU");
            Program.currentLang = "ru-RU";
        }

        private void englishBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormManager.Instance.LocalizedForms("en-US");
            Localized("en-US");
            Program.currentLang = "en-US";
        }

        //TODO: implement visibility of menu item depends on users role
        private void ProvideAccessToMenuItems()
        {
            //"menu item name".Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove("Lang");
            config.AppSettings.Settings.Add("Lang", Program.currentLang);
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // TODO: uncommit after implementation of authentication

            //var timeToStart = Program.currentTestee.UserSetting.TimeOfStart;
            //if (DateTime.Now.TimeOfDay > new TimeSpan(timeToStart.Hour, timeToStart.Minute, timeToStart.Second))
            //{
            //    QuestionForm f = new QuestionForm(Program.currentTestee);
            //    f.Show();
            //    timer.Stop();
            //}
        }
    }
}