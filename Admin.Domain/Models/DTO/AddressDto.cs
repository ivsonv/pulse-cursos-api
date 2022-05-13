﻿namespace Admin.Domain.Models.DTO
{
    public class AddressDto
    {
        public string zipcode { get; set; }
        public string uf  { get; set; }
        public string city  { get; set; }
        public string neighborhood  { get; set; }
        public string address  { get; set; }
        public string country  { get; set; }
        public string ibge { get; set; }
        public string complement { get; set; }
        public string number { get; set; }
        public string siafi { get; set; }
    }
}
