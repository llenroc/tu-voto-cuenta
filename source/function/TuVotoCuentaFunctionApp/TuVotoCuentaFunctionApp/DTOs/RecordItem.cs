﻿using Newtonsoft.Json;
using System;

namespace TuVotoCuentaFunctionApp.DTOs
{
    public class RecordItem
    {
        [JsonProperty("id")]
        public string UID { get; set; }
        public string DeviceHash { get; set; }
        public string BoxNumber { get; set; }
        public string BoxSection { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LocationDetails { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Municipality { get; set; }
        public string Town { get; set; }
        public int PartyPAN { get; set; }
        public int PartyPRI { get; set; }
        public int PartyPRD { get; set; }
        public int PartyVerde { get; set; }
        public int PartyPT { get; set; }
        public int PartyMC { get; set; }
        public int PartyNA { get; set; }
        public int PartyMOR { get; set; }
        public int PartyES { get; set; }
        public int PartyINDMar { get; set; }
        public int PartyINDJai { get; set; }
        public int PartyOtro { get; set; }
        public string Image { get; set; }
        public string RecordHash { get; set; }
        public string BlockchainTransaction { get; set; }
        public string CreatedDate { get; set; }
    }
}