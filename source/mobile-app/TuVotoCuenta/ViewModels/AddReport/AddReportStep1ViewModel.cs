﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Plugin.DeviceInfo;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace TuVotoCuenta.ViewModels
{
    public class AddReportStep1ViewModel : BaseViewModel
    {
        INavigation navigation = null;

        public AddReportStep1ViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            InitializeViewModel();
        }

        void InitializeViewModel()
        {
            Title = "Registro de casilla";

            Task.Run(() =>
            {
                using(var sha256 = SHA256.Create())  
                {
                    var dh = sha256.ComputeHash(Encoding.UTF8.GetBytes(CrossDeviceInfo.Current.Id));
                    DeviceHash = System.BitConverter.ToString(dh).Replace("-", "").ToLower();  
                }  
            });

            Task.Run(() => {
                if (IsLocationAvailable())
                {
                    StartLocationAsync();
                }
            });
        }

        bool IsLocationAvailable()
        {
            if (!CrossGeolocator.IsSupported)
                return false;

            return CrossGeolocator.Current.IsGeolocationAvailable;
        }

        async void StartLocationAsync()
        {
            var locator = CrossGeolocator.Current;
            try
            {
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(2));

                if (position != null)
                {
                    LocationLatitude = position.Latitude;
                    LocationLongitude = position.Longitude;
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("TuVotoCuenta", "Es necesario que actives la localización desde tu dispositivo móvil para poder usar la funcionalidad de mapas y geolocalización.", "Aceptar");
                    });
                }
            }
            catch
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("TuVotoCuenta", "Es necesario que actives la localización desde tu dispositivo móvil para poder usar la funcionalidad de mapas y geolocalización.", "Aceptar");
                });
            }
        }

        #region Commands

        #endregion

        #region Binding attributes

		int id;
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        string boxNumber;
        public string BoxNumber
        {
            get { return boxNumber; }
            set { SetProperty(ref boxNumber, value); }
        }

        string boxSection;
        public string BoxSection
        {
            get { return boxSection; }
            set { SetProperty(ref boxSection, value); }
        }
        
        double locationLongitude;
        public double LocationLongitude
        {
            get { return locationLongitude; }
            set { SetProperty(ref locationLongitude, value); }
        }

        double locationLatitude;
        public double LocationLatitude
        {
            get { return locationLatitude; }
            set { SetProperty(ref locationLatitude, value); }
        }

		string locationDetails;
        public string LocationDetails
        {
            get { return locationDetails; }
            set { SetProperty(ref locationDetails, value); }
        }

        string state;
        public string State
        {
            get { return state; }
            set { SetProperty(ref state, value); }
        }

		string city;
        public string City
        {
            get { return city; }
            set { SetProperty(ref city, value); }
        }

        string municipality;
        public string Municipality
		{
			get { return municipality; }
			set { SetProperty(ref municipality, value); }
		}
        
        string town;
        public string Town
        {
            get { return town; }
            set { SetProperty(ref town, value); }
        }

		string photoTimestamp;
        public string PhotoTimestamp
        {
            get { return photoTimestamp; }
            set { SetProperty(ref photoTimestamp, value); }
        }

        string deviceHash;
        public string DeviceHash
        {
            get { return deviceHash; }
            set { SetProperty(ref deviceHash, value); }
        }
        
        /* COUNTERS */

		int partyPAN = -1;
		public int PartyPAN
        {
			get { return partyPAN; }
			set { SetProperty(ref partyPAN, value); }
        }
  
        int partyPRI = -1;
        public int PartyPRI
        {
			get { return partyPRI; }
			set { SetProperty(ref partyPRI, value); }
        }

        int partyPRD = -1;
        public int PartyPRD
        {
            get { return partyPRD; }
            set { SetProperty(ref partyPRD, value); }
        }
        
        int partyVerde = -1;
        public int PartyVerde
        {
			get { return partyVerde; }
			set { SetProperty(ref partyVerde, value); }
        }

        int partyPT = -1;
        public int PartyPT
        {
            get { return partyPT; }
            set { SetProperty(ref partyPT, value); }
        }

        int partyMC = -1;
        public int PartyMC
        {
            get { return partyMC; }
            set { SetProperty(ref partyMC, value); }
        }

        int partyNA = -1;
        public int PartyNA
        {
            get { return partyNA; }
            set { SetProperty(ref partyNA, value); }
        }

        int partyMOR = -1;
        public int PartyMOR
        {
            get { return partyMOR; }
            set { SetProperty(ref partyMOR, value); }
        }

        int partyES = -1;
        public int PartyES
        {
            get { return partyES; }
            set { SetProperty(ref partyES, value); }
        }
        
        int partyIND= -1;
        public int PartyIND
        {
            get { return partyIND; }
            set { SetProperty(ref partyIND, value); }
        }

        #endregion
    }
}