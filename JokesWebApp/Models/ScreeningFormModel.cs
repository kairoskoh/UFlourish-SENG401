using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using System;

namespace JokesWebApp.Models
{
    public class ScreeningFormModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your date of birth.")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter your symptoms.")]
        public string Symptoms { get; set; }

        public string TravelHistory { get; set; }

        public string ContactWithConfirmedCase { get; set; }
    }
}