﻿using PlantenApplicatie.Data;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;

namespace PlantenApplicatie.UI.ViewModel
{
    class LoginSchermViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; set; }
        private PlantenDataService _plantenDataService;
        private string _emailInput;
        private string _wachtwoordInput;
        public LoginSchermViewModel(PlantenDataService plantenDataService)
        {
            LoginCommand = new DelegateCommand(LogIn);
            this._plantenDataService = plantenDataService;
        }
        public string EmailInput
        {
            get { return _emailInput; }
            set
            {
                _emailInput = value.Trim();
            }
        }
        public string WachtwoordInput
        {
            get { return _wachtwoordInput; }
            set
            {
                _wachtwoordInput = value;
            }
        }

        private void LogIn()
        {
            using (var sha256 = SHA256.Create())
            {
                var gebruiker = _plantenDataService.getGebruikerViaEmail(EmailInput);
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(WachtwoordInput));
                if (gebruiker.HashPaswoord == hashedBytes)
                {
                    //open zoekscherm
                }
            }
        }
    }
}
