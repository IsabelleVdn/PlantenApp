﻿using System;
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
using Microsoft.EntityFrameworkCore;
using PlantenApplicatie.DATA.Models;

namespace PlantenApplicatie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static Planten2021Context context = new Planten2021Context();
        public MainWindow()
        {
            //Jelle
            InitializeComponent();
            addItemsToComboBox(cbxType);
            addItemsToComboBox(cbxFamilie);
            addItemsToComboBox(cbxVariant);
            addItemsToComboBox(cbxSoort);
            addItemsToComboBox(cbxGeslacht);

        }

        public void addItemsToComboBox(ComboBox plant)
        {
            //Jelle
            switch (plant.Name)
            {
                case "cbxType":
                    var types = context.TfgsvType.ToList();
                    foreach (TfgsvType type in types)
                    {
                        plant.Items.Add(type.Planttypenaam);
                    }
                    break;
                case "cbxFamilie":
                    var families = context.TfgsvFamilie.ToList();
                    foreach (TfgsvFamilie familie in families)
                    {
                        plant.Items.Add(familie.Familienaam);
                    }
                    break;
                case "cbxVariant":
                    var varianten = context.TfgsvVariant.ToList();
                    foreach (TfgsvVariant variant in varianten)
                    {
                        plant.Items.Add(variant.Variantnaam);
                    }
                    break;
                case "cbxSoort":
                    var soorten = context.TfgsvSoort.ToList();
                    foreach (TfgsvSoort soort in soorten)
                    {
                        plant.Items.Add(soort.Soortnaam);
                    }
                    break;
                case "cbxGeslacht":
                    var geslachten = context.TfgsvGeslacht.ToList();
                    foreach (TfgsvGeslacht geslacht in geslachten)
                    {
                        plant.Items.Add(geslacht.Geslachtnaam);
                    }
                    break;

                default:
                    break;
            }


        }

        private void cbxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Maarten
            if (cbxType.SelectedItem != null)
            {
                lstResult.Items.Clear();
                cbxFamilie.Items.Clear();
                cbxGeslacht.Items.Clear();
                cbxSoort.Items.Clear();
                cbxVariant.Items.Clear();

                var selectedType = context.TfgsvType.FirstOrDefault(s => s.Planttypenaam == cbxType.SelectedItem.ToString());
                var selectedFamilie = context.TfgsvFamilie.FirstOrDefault(s => s.TypeTypeid == selectedType.Planttypeid);
                var selectedgeslacht = context.TfgsvGeslacht.FirstOrDefault(s => s.FamilieFamileId == selectedFamilie.FamileId);
                var selectedSoort = context.TfgsvSoort.FirstOrDefault(s => s.GeslachtGeslachtId == selectedgeslacht.GeslachtId);
                foreach (TfgsvFamilie familie in context.TfgsvFamilie.ToList())
                {
                    if (selectedType.Planttypeid == familie.TypeTypeid)
                    {
                        cbxFamilie.Items.Add(familie.Familienaam);
                    }
                }
                foreach (TfgsvGeslacht geslacht in context.TfgsvGeslacht.ToList())
                {
                    if (selectedFamilie.FamileId == geslacht.FamilieFamileId)
                    {

                        cbxGeslacht.Items.Add(geslacht.Geslachtnaam);
                    }

                }
                foreach (TfgsvSoort soort in context.TfgsvSoort.ToList())
                {
                    if (selectedgeslacht.GeslachtId == soort.GeslachtGeslachtId)
                    {
                        cbxSoort.Items.Add(soort.Soortnaam);
                    }
                }
                foreach (TfgsvVariant variant in context.TfgsvVariant.ToList())
                {
                    if (selectedSoort.Soortid == variant.SoortSoortid)
                    {
                        cbxVariant.Items.Add(variant.Variantnaam);
                    }
                }
                //Maarten, Hermes & Jelle
                foreach (Plant plant in context.Plant.ToList())
                {
                    if (selectedType.Planttypeid.ToString() == plant.Type)
                    {
                        lstResult.Items.Add(plant.Fgsv);
                    }
                }

            }
            
        }
        private void cbxFamilie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Maarten
            if (cbxFamilie.SelectedItem != null)
            {
                lstResult.Items.Clear();
                cbxGeslacht.Items.Clear();
                cbxSoort.Items.Clear();
                cbxVariant.Items.Clear();

                var selectedFamilie = context.TfgsvFamilie.FirstOrDefault(s => s.Familienaam == cbxFamilie.SelectedItem.ToString());
                var selectedgeslacht = context.TfgsvGeslacht.FirstOrDefault(s => s.FamilieFamileId == selectedFamilie.FamileId);
                var selectedSoort = context.TfgsvSoort.FirstOrDefault(s => s.GeslachtGeslachtId == selectedgeslacht.GeslachtId);
                foreach (TfgsvGeslacht geslacht in context.TfgsvGeslacht.ToList())
                {
                    if (selectedFamilie.FamileId == geslacht.FamilieFamileId)
                    {

                        cbxGeslacht.Items.Add(geslacht.Geslachtnaam);
                    }

                }
                foreach (TfgsvSoort soort in context.TfgsvSoort.ToList())
                {
                    if (selectedgeslacht.GeslachtId == soort.GeslachtGeslachtId)
                    {
                        cbxSoort.Items.Add(soort.Soortnaam);
                    }
                }
                foreach (TfgsvVariant variant in context.TfgsvVariant.ToList())
                {
                    if (selectedSoort.Soortid == variant.SoortSoortid)
                    {
                        cbxVariant.Items.Add(variant.Variantnaam);
                    }
                }
                //Maarten, Hermes & Jelle
                foreach (Plant plant in context.Plant.ToList())
                {
                    if (selectedFamilie.FamileId.ToString() == plant.Familie)
                    {
                        lstResult.Items.Add(plant.Fgsv);
                    }
                }
            }
        }
        private void cbxSoort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Jelle
            if (cbxSoort.SelectedItem != null)
            {
                cbxVariant.Items.Clear();
                lstResult.Items.Clear();
                foreach (TfgsvVariant variant in context.TfgsvVariant.ToList())
                {
                    var selectedSoort = context.TfgsvSoort.FirstOrDefault(s => s.Soortnaam == cbxSoort.SelectedItem.ToString());
                    if (selectedSoort.Soortid == variant.SoortSoortid)
                    {
                        cbxVariant.Items.Add(variant.Variantnaam);
                    }
                }
                //Maarten, Hermes & Jelle
                foreach (Plant plant in context.Plant.ToList())
                {
                    var selectedSoort = context.TfgsvSoort.FirstOrDefault(s => s.Soortnaam == cbxSoort.SelectedItem.ToString());
                    if (selectedSoort.Soortid.ToString() == plant.Soort)
                    {
                        lstResult.Items.Add(plant.Fgsv);
                    }
                }
            }
        }

        

        private void cbxVariant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbxGeslacht_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Hemen
            if (cbxGeslacht.SelectedItem != null)
            {
                lstResult.Items.Clear();
                cbxSoort.Items.Clear();
                cbxVariant.Items.Clear();

                var selectedgeslacht = context.TfgsvGeslacht.FirstOrDefault(s => s.Geslachtnaam == cbxGeslacht.SelectedItem.ToString());
                var selectedSoort = context.TfgsvSoort.FirstOrDefault(s => s.GeslachtGeslachtId == selectedgeslacht.GeslachtId);
                foreach (TfgsvSoort soort in context.TfgsvSoort.ToList())
                {
                    if (selectedgeslacht.GeslachtId == soort.GeslachtGeslachtId)
                    {
                        cbxSoort.Items.Add(soort.Soortnaam);
                    }
                }
                foreach (TfgsvVariant variant in context.TfgsvVariant.ToList())
                {
                    if (selectedSoort.Soortid == variant.SoortSoortid)
                    {
                        cbxVariant.Items.Add(variant.Variantnaam);
                    }
                }
                //Maarten, Hermes & Jelle
                foreach (Plant plant in context.Plant.ToList())
                {
                    if (selectedgeslacht.GeslachtId.ToString() == plant.Geslacht)
                    {
                        lstResult.Items.Add(plant.Fgsv);
                    }
                }
            }
        }


        private void btnStartOpnieuw_Click(object sender, RoutedEventArgs e)
        {
            //jelle & maarten
            lstResult.Items.Clear();
            cbxFamilie.Items.Clear();
            cbxGeslacht.Items.Clear();
            cbxSoort.Items.Clear();
            cbxType.Items.Clear();
            cbxVariant.Items.Clear();

            addItemsToComboBox(cbxType);
            addItemsToComboBox(cbxFamilie);
            addItemsToComboBox(cbxVariant);
            addItemsToComboBox(cbxSoort);
            addItemsToComboBox(cbxGeslacht);

        }
    }
}
